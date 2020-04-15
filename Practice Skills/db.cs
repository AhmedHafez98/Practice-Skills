using System.Data;
using System.Data.Common;

namespace Practice_Skills
{
    public class db
    {

        private string TableName;
        static DbProviderFactory fact;
        DbDataAdapter adapter;
        DbDataAdapter adp;
        public db(string _tn)
        {
            TableName = _tn;
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("InvariantName");
            dt.Columns.Add("AssemblyQualifiedName");
            dt.Rows.Add("ADO.NET Provider for SQLite", "ADO.NET Provider for SQLite ", "System.Data.SQLite",
                            "System.Data.SQLite.SQLiteFactory, System.Data.SQLite");
            fact = DbProviderFactories.GetFactory(dt.Rows[0]);
            DbConnection conn = fact.CreateConnection();
            conn.ConnectionString = "data source=db.db";
            adapter = fact.CreateDataAdapter();
            adapter.SelectCommand = conn.CreateCommand();
            adp = fact.CreateDataAdapter();
            adp.SelectCommand = conn.CreateCommand();
            DbCommand com = fact.CreateCommand();
            conn.Open();
            com.Connection = conn;

            com.CommandText = "CREATE TABLE IF NOT EXISTS 'Skills' ('Skills'  TEXT NOT NULL ,'Num' int,PRIMARY KEY('Skills'));";
            com.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable Get()
        {

            adapter.SelectCommand.CommandText = "select * from " + TableName;
            DbCommandBuilder cb = fact.CreateCommandBuilder();
            cb.DataAdapter = adapter;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dt.Constraints.Add("pk_sno", dt.Columns[0], true);
            return dt;
        }
        public void UDT(DataTable dt)
        {
            adapter.Update(dt);
        }

    }
}
