using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rocket.RDVQA.Tools.ODBC.Core.DB
{
    class TableManager
    {
        private static DataSet dsRDVQADB;
        private static DataTable dtConnectionString;
        private static List<String> Tables;

        public static void DefineDataTables()
        {
            dsRDVQADB = new DataSet();
            DefineConnectionStringTable();
        }
        /// <summary>
        /// Define Datatable for RDVQADB.CONNECTIONS
        /// 
        /// </summary>
        private static void DefineConnectionStringTable()
        {
            dtConnectionString = new DataTable("ConnectionStrings");
            DataColumn column;
            DataRow row;

            // Create data column : ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dtConnectionString.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Name",
                AutoIncrement = false,
                ReadOnly = false,
                Caption = "Connection DSN",
                Unique = true
            };
            dtConnectionString.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String "),
                ColumnName = "Connection_String",
                Caption = "Connection String",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dtConnectionString.Columns.Add(column);

            // Creat data column  : Description
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Desciption",
                Caption = "Description",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dtConnectionString.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = dtConnectionString.Columns["ID"];
            dtConnectionString.PrimaryKey = _;

            // add table to dataset
            dsRDVQADB.Tables.Add(dtConnectionString);
        }
    }
}
