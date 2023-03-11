using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public abstract class Model
    {
        private int id = 0;

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
        public int save()
        {
            var table_name = this.GetType().Name;
            if (id == 0)
            {
                var columns = string.Join(",", ObjectToDictionary(this).Keys);
                //var values = string.Join(",", ObjectToDictionary(this).Values.Select(v => v is string ? "'" + v.ToString() + "'" : v.ToString()));
                var values = string.Join(",", ObjectToDictionary(this).Values.Select(v => "'" + v.ToString() + "'"));
                var sql = $"INSERT INTO {table_name} ({columns}) VALUES ({values})";
                return Connection.IUD(sql);
            }
            else
            {
                //var sets = string.Join(",", ObjectToDictionary(this).Select(kvp => kvp.Value is string ? $"{kvp.Key}='{kvp.Value}'" : $"{kvp.Key}={kvp.Value}"));
                var sets = string.Join(",", ObjectToDictionary(this).Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
                var sql = $"UPDATE {table_name} SET {sets} WHERE id={id}";
                return Connection.IUD(sql);
            }


        }


        public dynamic find()
        {
            var table_name = this.GetType().Name;
            var sql = $"SELECT * FROM {table_name} WHERE id={id}";
            var reader = Connection.Select(sql);
            reader.Read();
            var dict = new Dictionary<string, object>();
            for (var i = 0; i < reader.FieldCount; i++)
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
            var table_name = this.GetType().Name;
            var sql = $"DELETE FROM {table_name} WHERE id={id}";
            return Connection.IUD(sql);
        }
        public List<dynamic> all()
        {
            var table_name = this.GetType().Name;
            var sql = $"SELECT * FROM {table_name}";
            var reader = Connection.Select(sql);
            var list = new List<dynamic>();
            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
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
            var table_name = this.GetType().Name;
            var sql = $"SELECT * FROM {table_name} WHERE ";
            sql += string.Join(" AND ", dico.Select(kvp => $"{kvp.Key}='{kvp.Value}'"));
            var reader = Connection.Select(sql);
            var list = new List<dynamic>();
            while (reader.Read())
            {
                var dict = new Dictionary<string, object>();
                for (var i = 0; i < reader.FieldCount; i++)
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
    }
}
