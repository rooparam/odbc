using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Rocket.RDVQA.Tools.Core.DB
{
    class TableManager
    {
        private DataSet dsRDVQADB;
        public DataTable DTDeSelect { get; private set; }
        public DataTable DTConnections { get; private set; }
        public DataTable DTDeSelectHash { get; private set; }
        public DataTable DTDsTypes { get; private set; }

        public static TableManager RDVQADBTables = new TableManager();

        private TableManager()
        {
            dsRDVQADB = new DataSet();
            DefineConnectionsTable();
            DefineDESelectHashTable();
            DefineDESelectTable();
            DefineDSTypesTable();
        }
        /// <summary>
        /// Define Datatable for RDVQADB.CONNECTIONS
        /// 
        /// </summary>
        private void DefineConnectionsTable()
        {
            DTConnections = new DataTable("ConnectionStrings");
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
            DTConnections.Columns.Add(column);

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
            DTConnections.Columns.Add(column);

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
            DTConnections.Columns.Add(column);

            // Creat data column  : Description
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DESC",
                Caption = "Description",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            DTConnections.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = DTConnections.Columns["ID"];
            DTConnections.PrimaryKey = _;

            // add table to dataset
            dsRDVQADB.Tables.Add(DTConnections);
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void DefineDESelectTable()
        {
            DTConnections = new DataTable("DE_Select"); 


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
            DTConnections.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String"),
                ColumnName = "DSTYPE_ID",
                Caption = "Datasource Type",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            DTConnections.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.String "),
                ColumnName = "QUERY",
                Caption = "Sql Select Query",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            DTConnections.Columns.Add(column);

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
            DTConnections.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = DTConnections.Columns["ID"];
            DTConnections.PrimaryKey = _;

            // add table to dataset
            dsRDVQADB.Tables.Add(DTConnections);
        } 
        
        /// <summary>
        /// 
        /// </summary>
        private void DefineDESelectHashTable()
        {
            DTDeSelectHash = new DataTable("DESelect_Hash"); 


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
            DTDeSelectHash.Columns.Add(column);

            // Create data column : Name
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.Int32"),
                ColumnName = "CONN_ID",
                Caption = "Connection ID",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = true
            };
            DTDeSelectHash.Columns.Add(column);

            // Create data column : Connection_String
            column = new DataColumn()
            {
                DataType = System.Type.GetType("System.Int32 "),
                ColumnName = "QUERY_ID",
                Caption = "Sql Select Query",
                AutoIncrement = false,
                ReadOnly = false,
                Unique = false
            };
            DTDeSelectHash.Columns.Add(column);

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
            DTDeSelectHash.Columns.Add(column);
            DataColumn[] _ = new DataColumn[1];
            _[0] = DTDeSelectHash.Columns["ID"];
            DTDeSelectHash.PrimaryKey = _;

            // add table to dataset
            dsRDVQADB.Tables.Add(DTDeSelectHash);
        } /// <summary>
        /// 
        /// </summary>
        private void DefineDSTypesTable()
        {
            DTDsTypes = new DataTable("DSTYPES"); 


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
            DTDsTypes.Columns.Add(column);

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
            DTDsTypes.Columns.Add(column);

            
            DataColumn[] _ = new DataColumn[1];
            _[0] = DTDsTypes.Columns["ID"];
            DTDsTypes.PrimaryKey = _;

            // add table to dataset
            dsRDVQADB.Tables.Add(DTDsTypes);
        }
    }
}
