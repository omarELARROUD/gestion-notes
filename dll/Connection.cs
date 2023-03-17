using MySql.Data.MySqlClient;
using System.Data;
using System.Data.OracleClient;
using System.Xml;

namespace DB
{
    public class Connection
    {
        static IDbConnection con = null;
        static IDbCommand cmd = null;

        
        public static void Connect()
        {
            string filePath = "./env.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);

            // Get the root element
            XmlElement root = xmlDoc.DocumentElement;

            // the DB_CONNECTION attribute
            string dbManager = root.GetAttribute("DB_CONNECTION");

            // the database connection parameters
            string dbHost = root.GetAttribute("DB_HOST");
            string dbPort = root.GetAttribute("DB_PORT");
            string dbName = root.GetAttribute("DB_DATABASE");
            string dbUsername = root.GetAttribute("DB_USERNAME");
            string dbPassword = root.GetAttribute("DB_PASSWORD");

            if (dbManager == "mysql")
            {
                string str_con = $"server={dbHost};uid={dbUsername};pwd={dbPassword};database={dbName}";
                con = new MySqlConnection(str_con);
                cmd = con.CreateCommand();

            }else if (dbManager == "oracle")
            {
                string str_con = $"DATA SOURCE={dbHost}:{dbPort}/{dbName};PASSWORD={dbPassword};USER ID={dbUsername}";
                con = new OracleConnection(str_con);
                cmd = con.CreateCommand();
            }
            try
            {
                con.Open();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                con = null;
                cmd = null;
                throw new Exception("can not connect");

            }


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

        public static void execute_procedure(string proc, Dictionary<string,object> dico)
        {
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach(var kv in dico)
            {
                cmd.Parameters.Add(new MySqlParameter(kv.Key, kv.Value));
            }
            cmd.ExecuteNonQuery();
            cmd=con.CreateCommand();
        }

        public static dynamic execute_function(string func, Dictionary<string, object> dico)
        {
            cmd.CommandText = func;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (var kv in dico)
            {
                cmd.Parameters.Add(new MySqlParameter(kv.Key, kv.Value));
            }
            MySqlParameter returnParam = new MySqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(returnParam);
            cmd.ExecuteNonQuery();
            var res = returnParam.Value;
            cmd = con.CreateCommand();
            return res;
        }

    }
}