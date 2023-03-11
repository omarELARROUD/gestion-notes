using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OracleClient;

namespace DB
{
    public class Connection
    {
        static IDbConnection con = null;
        static IDbCommand cmd = null;

        
        public static void Connect(string sgbd="mysql" ,string str_con= "server=localhost;uid=root;pwd='';database=ginf2")
        {

            if (sgbd == "mysql")
            {
                //string str_con = "server=localhost;uid=root;pwd='';database=ginf2";
                con = new MySqlConnection(str_con);
                cmd = con.CreateCommand();

                try
                {
                    con.Open();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                //str_con = "DATA SOURCE=localhost:1521/orcl;PASSWORD=123;USER ID=optim21";
                con = new OracleConnection(str_con);
                cmd = con.CreateCommand();

                try
                {
                    con.Open();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            con = null;
            cmd = null;
            throw new Exception("can not connect");
            

        }
        public static int IUD(string req)
        {
            if (con == null) Connect();
            cmd.CommandText = req;
            return cmd.ExecuteNonQuery();
        }
        public static IDataReader Select(string req)
        {
            if (con == null) Connect();
            cmd.CommandText = req;
            return cmd.ExecuteReader();

        }
        public static Dictionary<string, string> getChamps_table(string table)
        {
            var champs= new Dictionary<string, string>();
            if (con == null) Connect();

            IDbDataAdapter da;
            if(con is MySqlConnection)da= new MySqlDataAdapter("select * from "+ table + "", (MySqlConnection)con);
            else da = new OracleDataAdapter("select * from " + table + "", (OracleConnection)con);
            var ds = new DataSet();
            da.FillSchema(ds, SchemaType.Source);
            for(int i= 0; i < ds.Tables[0].Columns.Count;i++)
            {
                string nom = ds.Tables[0].Columns[i].ColumnName;
                string type = ds.Tables[0].Columns[i].DataType.ToString().Split('.').Last<string>();
                champs.Add(nom,type);
            }
            
            return champs;
        }

    }
}