using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Rocket.RDVQA.Tools.ODBC.Core.DB;

namespace Rocket.RDVQA.Tools.ODBC.UI.Controls
{
    public partial class TableViewControl : UserControl
    {
        public TableViewControl()
        {
            InitializeComponent();
            this.dataGridView.DataSource = new DBManager().ReadTableConnections();

        }

    }
}
