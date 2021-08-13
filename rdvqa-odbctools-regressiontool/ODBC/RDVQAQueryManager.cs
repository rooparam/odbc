using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.Data;
using Rocket.RDVQA.Tools.ODBC.Utils;
using Microsoft.Win32;
using System.Globalization;
using System.Threading;

namespace Rocket.RDVQA.Tools.ODBC
{


    // Provides a task scheduler that ensures a maximum concurrency level while
    // running on top of the thread pool.
    public class LimitedConcurrencyLevelTaskScheduler : TaskScheduler
    {
        // Indicates whether the current thread is processing work items.
        [ThreadStatic]
        private static bool _currentThreadIsProcessingItems;

        // The list of tasks to be executed
        private readonly LinkedList<Task> _tasks = new LinkedList<Task>(); // protected by lock(_tasks)

        // The maximum concurrency level allowed by this scheduler.
        private readonly int _maxDegreeOfParallelism;

        // Indicates whether the scheduler is currently processing work items.
        private int _delegatesQueuedOrRunning = 0;

        // Creates a new instance with the specified degree of parallelism.
        public LimitedConcurrencyLevelTaskScheduler(int maxDegreeOfParallelism)
        {
            if (maxDegreeOfParallelism < 1) throw new ArgumentOutOfRangeException("maxDegreeOfParallelism");
            _maxDegreeOfParallelism = maxDegreeOfParallelism;
        }

        // Queues a task to the scheduler.
        protected sealed override void QueueTask(Task task)
        {
            // Add the task to the list of tasks to be processed.  If there aren't enough
            // delegates currently queued or running to process tasks, schedule another.
            lock (_tasks)
            {
                _tasks.AddLast(task);
                if (_delegatesQueuedOrRunning < _maxDegreeOfParallelism)
                {
                    ++_delegatesQueuedOrRunning;
                    NotifyThreadPoolOfPendingWork();
                }
            }
        }

        // Inform the ThreadPool that there's work to be executed for this scheduler.
        private void NotifyThreadPoolOfPendingWork()
        {
            ThreadPool.UnsafeQueueUserWorkItem(_ =>
            {
                // Note that the current thread is now processing work items.
                // This is necessary to enable inlining of tasks into this thread.
                _currentThreadIsProcessingItems = true;
                try
                {
                    // Process all available items in the queue.
                    while (true)
                    {
                        Task item;
                        lock (_tasks)
                        {
                            // When there are no more items to be processed,
                            // note that we're done processing, and get out.
                            if (_tasks.Count == 0)
                            {
                                --_delegatesQueuedOrRunning;
                                break;
                            }

                            // Get the next item from the queue
                            item = _tasks.First.Value;
                            _tasks.RemoveFirst();
                        }

                        // Execute the task we pulled out of the queue
                        base.TryExecuteTask(item);
                    }
                }
                // We're done processing items on the current thread
                finally { _currentThreadIsProcessingItems = false; }
            }, null);
        }

        // Attempts to execute the specified task on the current thread.
        protected sealed override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            // If this thread isn't already processing a task, we don't support inlining
            if (!_currentThreadIsProcessingItems) return false;

            // If the task was previously queued, remove it from the queue
            if (taskWasPreviouslyQueued)
                // Try to run the task.
                if (TryDequeue(task))
                    return base.TryExecuteTask(task);
                else
                    return false;
            else
                return base.TryExecuteTask(task);
        }

        // Attempt to remove a previously scheduled task from the scheduler.
        protected sealed override bool TryDequeue(Task task)
        {
            lock (_tasks) return _tasks.Remove(task);
        }

        // Gets the maximum concurrency level supported by this scheduler.
        public sealed override int MaximumConcurrencyLevel { get { return _maxDegreeOfParallelism; } }

        // Gets an enumerable of the tasks currently scheduled on this scheduler.
        protected sealed override IEnumerable<Task> GetScheduledTasks()
        {
            bool lockTaken = false;
            try
            {
                Monitor.TryEnter(_tasks, ref lockTaken);
                if (lockTaken) return _tasks;
                else throw new NotSupportedException();
            }
            finally
            {
                if (lockTaken) Monitor.Exit(_tasks);
            }
        }
    }
    class RDVQAQueryManager
    {
        private LogWriter logger;
        private LogWriter tableWriter;
        private LogWriter baselineWriter;
        LimitedConcurrencyLevelTaskScheduler lcts;
        List<Task> tasks;
        TaskFactory factory;
        CancellationTokenSource cts;
        public RDVQAQueryManager(LogWriter logger, LogWriter resultView, LogWriter baselineWriter)
        {
            this.logger = logger;
            this.tableWriter = resultView;
            this.baselineWriter = baselineWriter;


        }
        public DataTable ExecuteQuery(string query, string connectionString)
        {
            String [] queries = { query};
            return ExecuteBatchSelect(queries, connectionString).Tables[0];
        }
        public DataSet ExecuteBatchSelect(string[] queries, string connectionString )
        {
            DataSet resultSet = null;
            try
            {
                OdbcConnection odbcConnection = new(connectionString);
                odbcConnection.Open();
                OdbcCommand odbcCommand;
                resultSet = new();
                int tIdx = 0;
                foreach (String query in queries)
                {
                    odbcCommand = new(query, odbcConnection);
                    int rowsAffected = odbcCommand.ExecuteNonQuery();
                    resultSet.Tables.Add(new DataTable());
                    new OdbcDataAdapter(odbcCommand).Fill(resultSet.Tables[tIdx++]);
                    odbcCommand.Dispose();
                }
                odbcConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return resultSet;
        }

        public DataSet ExecuteBatchSelect(List<SQLDeSelectTestCase> testCases)
        {
            DataSet resultSet = new();
            int tIdx = 0;
            OdbcConnection odbcConnection;
            OdbcCommand odbcCommand;
            // Create a scheduler that uses two threads.
            lcts = new LimitedConcurrencyLevelTaskScheduler(1);
            factory = new TaskFactory(lcts);
            cts = new CancellationTokenSource();
            tasks = new List<Task>();
            Object lockObj = new Object();

            foreach (SQLDeSelectTestCase tc in testCases)
            {
                //tableWriter.WriteLine("Connection String: " + tc.ConnectionString);
                try
                {
                    logger.WriteInfo("Exeuting " + tc.SQL);
                    odbcConnection = new(tc.ConnectionString);
                    odbcConnection.Open();
                    odbcCommand = new(tc.SQL, odbcConnection);
                    int rowsAffected = odbcCommand.ExecuteNonQuery();
                    resultSet.Tables.Add(new DataTable());
                    new OdbcDataAdapter(odbcCommand).Fill(resultSet.Tables[tIdx++]);

                    tc.Hash = HashGenerator.GenerateSha256(resultSet.Tables[tIdx - 1]);
                    
                    logger.WriteInfo(resultSet.Tables[tIdx - 1].Rows.Count+" records fetched." );
                    logger.WriteInfo("Hash : "+tc.Hash);
                    logger.WriteInfo("Execution complete.");
                    Task task = Task.Factory.StartNew(() => {
                        lock (lockObj) { PrintTable(tc, resultSet.Tables[tIdx - 1]); }
                        //tableWriter.WriteLine("Hash : " + tc.Hash);
                    },cts.Token);
                    tasks.Add(task);

                    odbcCommand.Dispose();
                    odbcConnection.Close();
                }
                catch (Exception ex)
                {
                    logger.WriteInfo("[Connection String] "+tc.ConnectionString);
                    logger.WriteInfo("[SQL] "+tc.SQL);
                    logger.WriteError(ex.Message);
                    logger.WriteError(ex.StackTrace);
                }
            }
            cts.Dispose();
            return resultSet;
        }

        private void PrintTable(SQLDeSelectTestCase tc, DataTable dt)
        {
            int[] columnWidth = new int[dt.Columns.Count];
            int idx = 0;
            StringBuilder horizontalSplitter = new StringBuilder("+");
            StringBuilder colHeader = new StringBuilder("|");
            StringBuilder rowData = new StringBuilder();
            DataTableReader dr = dt.CreateDataReader();
            foreach (DataColumn c in dt.Columns)
            {
                if (c.DataType == Type.GetType("System.DateTime"))
                {
                    columnWidth[idx] = 28;
                }               
                else if (dt.Rows.Count > 0)
                {
                    if (c.DataType == Type.GetType("System.Byte[]"))
                    {
                        columnWidth[idx] = Math.Max(c.ColumnName.Length, 2 *((Byte[])dt.Rows[0][c.ColumnName]).Length);
                    }
                    else
                    {
                        columnWidth[idx] = Math.Max(c.ColumnName.Length, dt.AsEnumerable()
                             .Select(row => row[c.ColumnName].ToString())
                             .OrderByDescending(st => st.ToString().Length).FirstOrDefault().Length);
                    }
                    
                }
                else
                {
                    columnWidth[idx] = c.ColumnName.Length;
                }
                //columnWidth[idx] = tmpLength > columnWidth[idx] ? tmpLength : columnWidth[idx];
                horizontalSplitter.Append(new String('-', columnWidth[idx] + 2));
                horizontalSplitter.Append("+");
                idx++;
            }
            // print table name 
            tableWriter.WriteLine("Table             : " + dt.TableName);
            tableWriter.WriteLine("Connection String : " + tc.ConnectionString);
            tableWriter.WriteLine("Query             : " + tc.SQL);
            tableWriter.WriteLine("Hash              : " + tc.Hash);

            if (dt.Rows.Count != 0)
            {
                //tableWriter.WriteLine("           ");
                tableWriter.WriteLine(horizontalSplitter.ToString());
                // write column names
                idx = 0;
                foreach (DataColumn c in dt.Columns)
                {
                    colHeader.Append(" " + c.ColumnName.PadRight(columnWidth[idx++]) + " |");
                }
                tableWriter.WriteLine(colHeader.ToString());
                tableWriter.WriteLine(horizontalSplitter.ToString());
                string tempStr;
                //while (dr.Read())
                //{
                //    rowData.Append(dr.GetValue("CHAR_4") + " " + dr.GetValue("BIT_40") + " ");
                //}

                foreach (DataRow r in dt.Rows)
                {
                    rowData.Append("|");
                    idx = 0;

                    foreach (DataColumn c in dt.Columns)
                    {
                        tempStr = string.Format("{0}", (r[c] == DBNull.Value || r[c] == null ? "null" : r[c]));

                        if (c.DataType == Type.GetType("System.String"))
                        {
                            tempStr = tempStr.Replace((char)0x00, ' ');
                            tempStr = RemoveControlCharacters(tempStr);
                            //byte[] ba = Encoding.Default.GetBytes(tempStr);
                            //System.Windows.Forms.MessageBox.Show(BitConverter.ToString(ba));
                            rowData.Append(" " + tempStr.PadRight(columnWidth[idx++]) + " |");
                        }
                        else if (c.DataType == Type.GetType("System.Byte[]"))
                        {
                            rowData.Append(" " + BitConverter.ToString((byte[])r[c]).Replace("-", "").PadLeft(columnWidth[idx++]) + " |");
                        }
                        else if (c.DataType == Type.GetType("System.DateTime"))
                        {
                            rowData.Append(" " + ((DateTime)r[c]).ToString("yyyy-MM-dd HH:mm:ss.ffffff").PadLeft(columnWidth[idx++]) + " |");
                        }
                        else
                        {
                            rowData.Append(" " + tempStr.PadLeft(columnWidth[idx++]) + " |");
                        }
                    }
                    rowData.Append(Environment.NewLine);
                }

                tableWriter.Write(rowData.ToString());
                tableWriter.WriteLine(horizontalSplitter.ToString());
            }
            else
            {
                tableWriter.WriteLine("*** No Records To Display ***");
            }
            tableWriter.WriteLine(Environment.NewLine);
            rowData.Clear();
        }
        private string RemoveControlCharacters(string arg)
        {
            char[] arrForm = arg.ToCharArray();
            StringBuilder buffer = new StringBuilder(arg.Length);//This many chars at most

            foreach (char ch in arrForm)
            {
                if (!Char.IsControl(ch)) buffer.Append(ch);//Only add to buffer if not a control char
                else buffer.Append('?');
            }

            return buffer.ToString();
        }
        
    }
}
