using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DB
{
    public abstract class Model
    {
        private int id = 0;
        private static Boolean log=false;
        protected static List<string> Tlog=new List<string>();

        public int Id { get => id; set => id = value; }

        private static Dictionary<string, object> ObjectToDictionary(object obj)
        {
            var dictionary = new Dictionary<string, object>();
            foreach (var property in obj.GetType().GetProperties())
            {
                dictionary.Add(property.Name.ToLower(), property.GetValue(obj));
            }
            return dictionary;
        }
        private dynamic DictionaryToObject(Dictionary<string, object> dico)
        {
            var obj = Activator.CreateInstance(this.GetType());
            foreach (var property in obj.GetType().GetProperties())
            {
                property.SetValue(obj, dico[property.Name.ToLower()]);
            }
            return obj;
        }
        public static int maxid(string table_name, string func_maxid = null)
        {
            if (func_maxid != null)
            {
                var dico=new Dictionary<string, object>();
                dico.Add("table_name", table_name);
                return Connection.execute_function(func_maxid, dico);
            }
            var sql = $"SELECT count(id) FROM {table_name}";
            var reader = Connection.Select(sql);
            reader.Read();
            if (reader.GetInt32(0)==0)
            {
                reader.Close();
                return 0;
            }
            reader.Close();
            sql = $"SELECT max(id) FROM {table_name}";
            reader = Connection.Select(sql);
            reader.Read();
            int res = reader.GetInt32(0);
            reader.Close();
            return res;
        }
        public int save(string func_save=null,string func_maxeid=null)
        {
            var table_name = this.GetType().Name +"s";
            var oldobj = this.find();
            var res = 0;
            if(func_save != null)
            {
                var dico = ObjectToDictionary(this);
                id= Connection.execute_function(func_save, dico);
                res = 1;
            }
            else if (id == 0)
            {
                id = maxid(table_name, func_maxeid) +1;
                var columns = string.Join(",", ObjectToDictionary(this).Keys);
                //var values = string.Join(",", ObjectToDictionary(this).Values.Select(v => v is string ? "'" + v.ToString() + "'" : v.ToString()));
                var values = string.Join(",", ObjectToDictionary(this).Values.Select(v => "'" + v.ToString() + "'"));
                var sql = $"INSERT INTO {table_name} ({columns}) VALUES ({values})";
                res=Connection.IUD(sql);
            }
            else
            {
                //var sets = string.Join(",", ObjectToDictionary(this).Select(kvp => kvp.Value is string ? $"{kvp.Key}='{kvp.Value}'" : $"{kvp.Key}={kvp.Value}"));
                var sets = string.Join(",", ObjectToDictionary(this).Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
                var sql = $"UPDATE {table_name} SET {sets} WHERE id={id}";
                res= Connection.IUD(sql);
            }

            if (oldobj == null)
            {
                insertxmlline("insert");
            }
            else
            {
                insertxmlline("update", oldobj);
            }
            return res;


        }


        public dynamic find()
        {
            var table_name = this.GetType().Name+"s";
            var sql = $"SELECT * FROM {table_name} WHERE id={id}";
            var reader = Connection.Select(sql);
            if (!reader.Read())
            {
                reader.Close();
                return null;
            }
            var dict = new Dictionary<string, object>();
            dict.Add(reader.GetName(0).ToLower(), reader.GetInt32(0));
            for (var i = 1; i < reader.FieldCount; i++)
            {
                dict.Add(reader.GetName(i).ToLower(), reader.GetValue(i));
            }
            reader.Close();
            return DictionaryToObject(dict);

            
        }
        public static dynamic find<T>(int id) where T : Model
        {
            var obj = Activator.CreateInstance(typeof(T));
            T objT=(T)obj;
            objT.id = id;
            return objT.find();

            //var table_name = typeof(T).Name.ToLower();
            //var sql = $"SELECT * FROM {table_name} WHERE id={id}";
            //var reader = Connection.Select(sql);
            //reader.Read();
            //var dict = new Dictionary<string, object>();
            //for (var i = 0; i < reader.FieldCount; i++)
            //{
            //    dict.Add(reader.GetName(i).ToLower(), reader.GetValue(i));
            //}
            //reader.Close();
            //var temp = Activator.CreateInstance(typeof(T));
            //T tempT = (T)temp;
            //return tempT.DictionaryToObject(dict);
        }
        public int delete()
        {
            var table_name = this.GetType().Name + "s";
            var sql = $"DELETE FROM {table_name} WHERE id={id}";
            var obj = find();
            var res= Connection.IUD(sql);
            if(obj!=null)obj.insertxmlline("delete");
            return res;
        }
        public List<dynamic> all()
        {
            var table_name = this.GetType().Name + "s";
            var sql = $"SELECT * FROM {table_name}";
            var reader = Connection.Select(sql);
            var list = new List<dynamic>();
            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                dict.Add(reader.GetName(0).ToLower(), reader.GetInt32(0));
                for (var i = 1; i < reader.FieldCount; i++)
                {
                    dict.Add(reader.GetName(i).ToLower(), reader.GetValue(i));
                }
                list.Add(DictionaryToObject(dict));
            }
            reader.Close();
            return list;
        }
        public static List<dynamic> all<T>() where T : Model
        {
            var obj = Activator.CreateInstance(typeof(T));
            T objT = (T)obj;
            return objT.all();

            //var table_name = typeof(T).Name;
            //var sql = $"SELECT * FROM {table_name}";
            //var reader = DB.Connection.Select(sql);
            //var list = new List<dynamic>();
            //while (reader.Read())
            //{
            //    var dict = new Dictionary<string, object>();
            //    for (var i = 0; i < reader.FieldCount; i++)
            //    {
            //        dict.Add(reader.GetName(i).ToLower(), reader.GetValue(i));
            //    }
            //    var temp = Activator.CreateInstance(typeof(T));
            //    T tempT = (T)temp;
            //    list.Add(tempT.DictionaryToObject(dict));
            //}
            //reader.Close();
            //return list;
        }
        public List<dynamic> Select(Dictionary<string, object> dico)
        {
            var table_name = this.GetType().Name + "s";
            var sql = $"SELECT * FROM {table_name} WHERE ";
            sql += string.Join(" AND ", dico.Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
            var reader = Connection.Select(sql);
            var list = new List<dynamic>();
            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                dict.Add(reader.GetName(0).ToLower(), reader.GetInt32(0));
                for (var i = 1; i < reader.FieldCount; i++)
                {
                    dict.Add(reader.GetName(i).ToLower(), reader.GetValue(i));
                }
                list.Add(DictionaryToObject(dict));
            }
            reader.Close();
            return list;
        }
        public static List<dynamic> select<T>(Dictionary<string, object> dico) where T : Model
        {
            var obj = Activator.CreateInstance(typeof(T));
            T objT = (T)obj;
            return objT.Select(dico);


            //var table_name = typeof(T).Name;
            //var sql = $"SELECT * FROM {table_name} WHERE ";
            //sql += string.Join(" AND ", dico.Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
            //var reader = DB.Connection.Select(sql);
            //var list = new List<dynamic>();
            //while (reader.Read())
            //{
            //    var dict = new Dictionary<string, object>();
            //    for (var i = 0; i < reader.FieldCount; i++)
            //    {
            //        dict.Add(reader.GetName(i), reader.GetValue(i));
            //    }
            //    var temp = Activator.CreateInstance(typeof(T));
            //    T tempT = (T)temp;
            //    list.Add(tempT.DictionaryToObject(dict));
            //}
            //reader.Close();
            //return list;
        }

        public  static Boolean initializelog()
        {
            if(log)return true;
            try
            {
                string path = "./xmllog";
                Directory.CreateDirectory(path);
                log = true;
                return true;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            
        }

        public Boolean activatelog()
        {
            if (log)
            {
                if (Tlog.Contains(this.GetType().Name.ToLower()))return true;
                var xml_name = this.GetType().Name.ToLower() + "s";
                string filePath = "./xmllog/" + xml_name + ".xml";
                if (!File.Exists(filePath))
                {
                    var doc = new XDocument(new XDeclaration("1.0", "utf-8", "no"), new XElement(xml_name));
                    doc.Save(filePath);
                }
                Tlog.Add(this.GetType().Name.ToLower());
                return true;
            }
            return false;

            
        }
        public Boolean insertxmlline(string iud,dynamic oldobj=null)
        {
            var element_name = this.GetType().Name.ToLower();
            var xml_name = element_name + "s";
            var path = "./xmllog/" + xml_name + ".xml";
            if (log && Tlog.Contains(element_name))
            {
                
                var doc = XDocument.Load(path);
                var root = doc.Root;
                var objelm = new XElement(element_name);
                objelm.SetAttributeValue("opr", iud);
                objelm.SetAttributeValue("timestamp", DateTime.Now.ToString());
                var dico = ObjectToDictionary(this);
                
                if (iud == "insert" || iud == "delete")
                {
                    foreach (var kv in dico)
                    {
                        objelm.Add(new XElement(kv.Key, kv.Value));
                    }
                }else if(iud=="update" && oldobj != null)
                {
                    var olddico= ObjectToDictionary(oldobj);
                    foreach (var k in dico.Keys)
                    {
                        objelm.Add(new XElement(k, new XElement("oldValue", olddico[k]), new XElement("newValue", dico[k])));
                    }
                }
                
                root.Add(objelm);
                doc.Save(path);
                return true;

            }
            return false;
        }
    }
}
