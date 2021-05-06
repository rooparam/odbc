using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Rocket.RDVQA.Tools.Core;
using Rocket.RDVQA.Tools.Core.Data;
using Rocket.RDVQA.Tools.Core.Data.Extensions;
using Rocket.RDVQA.Tools.ODBC;

namespace Rocket.RDVQA.Tools.UI.Controls
{
    public partial class NewSQLSelectTestCase : UserControl
    {
        LogWriter logWriter;
        public NewSQLSelectTestCase()
        {
            InitializeComponent();
            logWriter = new LogWriter(txtLog);
            //
            // initialize cmbConnections
            //
            cmbConnections.DataSource = DBManager.DataTables.DTConnections;
            cmbConnections.DisplayMember = "name";
            cmbConnections.ValueMember = "connection_string";
            //
            // initalize cmbDatasources
            //
            cmbDatasources.DataSource = DBManager.DataTables.DTDsTypes;
            cmbDatasources.DisplayMember = "name";
            cmbDatasources.ValueMember = "ID";
        }

        private void pnlInputFieldsContainer_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnTestQueries_Click(object sender, EventArgs e)
        {
            
            RDVQAQueryManager queryManager = new RDVQAQueryManager();
            DataSet ds = RDVQAQueryManager.ExecuteBatchSelect(txtQueries.Lines, cmbConnections.SelectedValue.ToString());
            Console.SetOut(logWriter);
            foreach(DataTable dt in ds.Tables)
            {
                
            }
            PrintDataExtensions.Print(ds);
        }

        private void btnAddTCs_Click(object sender, EventArgs e)
        {
            //Task insertTask = new Task(Db2D)
        }
    }
}
