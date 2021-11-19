using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.RDVQA.Tools.Core.TestManagement
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class SQLTestCase
    {
        private string _id;
        private string _sql;
        private string _hash;
        private SQLType _sqlType;

        /// <summary>
        /// 
        /// </summary>
        public SQLTestCase()
        {
            Id = null;
            Sql = null;
            Hash = null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sql"></param>
        public SQLTestCase(string id, string sql)
        {
            Id = id;
            Sql = sql;
            Hash = null;
            SqlType = SQLTestCase.GetType(Sql);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="sql"></param>
        /// <param name="hash"></param>
        public SQLTestCase(string id, string sql, string hash)
        {
            Id = id;
            Sql = sql;
            Hash = hash;
            SqlType = SQLTestCase.GetType(Sql);
        }

        public string Id { get => _id; set => _id = value; }
        public string Sql { get => _sql; set => _sql = value; }
        public string Hash { get => _hash; set => _hash = value; }
        public SQLType SqlType { get => _sqlType; set => _sqlType = value; }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }

        public static SQLType GetType(string sql)
        {
            string keyword = sql.Trim().Trim('(').Trim().Split()[0];
            return keyword.ToLower() switch
            {
                "select" => SQLType.SELECT,
                "insert" => SQLType.INSERT,
                "delete" => SQLType.DELETE,
                "update" => SQLType.UPDATE,
                "set" => SQLType.CONFIG,
                _ => SQLType.OTHER
            };
        }
        override public string ToString()
        { return Id + ";" + SqlType.ToString() + ";" + Hash + ";" + Sql.Trim(';') + ";"; }
    }
}
