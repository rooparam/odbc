using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rocket.RDVQA.Tools.Core.DB
{
    class TableManager
    {

        public static TableManager RDVQADBTables = new TableManager();

        private TableManager()
        {
            //dsRDVQADB = new DataSet();
            //DefineConnectionsTable();
            //DefineDESelectHashTable();
            //DefineDESelectTable();
            //DefineDSTypesTable();
        }
        /// <summary>
        /// Define Datatable for RDVQADB.CONNECTIONS
        /// 
        /// </summary>
        public DataTable DTConnections()
        {
            DataTable dt = new DataTable("RDVQADB.CONNECTIONS");
            DataColumn column;
            DataRow row;

            // Create data column : ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            dt.Columns.Add(column);

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
            dt.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Connection_String",
                Caption = "Connection String",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Create data column : SSL
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int16"),
                ColumnName = "SSL",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Create data column : TSID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "TSID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Create data column : KSID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "KSID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            DataColumn[] _ = new DataColumn[1];
            _[0] = dt.Columns["ID"];
            dt.PrimaryKey = _;

            return dt;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DataTable DTDeSelect()
        {
            DataTable dt = new DataTable("RDVQADB.DE_Select"); 


            DataColumn column;

            // Create data column : ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            dt.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "DSTYPE_ID",
                Caption = "Datasource Type ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "QUERY",
                Caption = "Sql Select Query",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Creat data column  : Description
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "TAGS",
                Caption = "Search Tags",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = dt.Columns["ID"];
            dt.PrimaryKey = _;
            
            return dt;
        } 
        
        /// <summary>
        /// 
        /// </summary>
        public DataTable DTDeSelectHash()
        {
            DataTable dt = new DataTable("RDVQADB.DESELECT_HASH"); 


            DataColumn column;

            // Create data column : ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            dt.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "CONN_ID",
                Caption = "Connection ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "QUERY_ID",
                Caption = "Sql Select Query",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);

            // Creat data column  : Description
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "RESULT_HASH",
                Caption = "Search Tags",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            dt.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = dt.Columns["ID"];
            dt.PrimaryKey = _;

            // add table to dataset
            return dt;
        } /// <summary>
        /// 
        /// </summary>
        private DataTable DTDSTypes()
        {
            DataTable dt = new DataTable("RDVQADB.DSTYPES"); 


            DataColumn column;

            // Create data column : ID
            column = new DataColumn
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "ID",
                AutoIncrement = false,
                ReadOnly = true,
                Unique = true
            };
            dt.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "Name",
                Caption = "Datasource Name",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            dt.Columns.Add(column);

            
            DataColumn[] _ = new DataColumn[1];
            _[0] = dt.Columns["ID"];
            dt.PrimaryKey = _;

            return dt;
        }
    }
}
