using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TableDependency;
using TableDependency.Enums;
using TableDependency.SqlClient;
using TableWatcher.Base;

namespace TableWatcher
{
    public class TableWatcherSqlServer<T> : ITableWatcher<T> where T : class
    {
        public readonly String ConnectionString;
        private SqlTableDependency<T> Dependency;

        private ModelToTableMapper<T> mapper;

        public TableWatcherSqlServer(String connectionString)
        {
            ConnectionString = connectionString;
            MapearEntidade();
        }

        public void InitializeTableWatcher()
        {
            Dependency = new SqlTableDependency<T>(ConnectionString, typeof(T).Name, mapper);
            Dependency.OnChanged += OnChanged;
            Dependency.OnError += OnError;
        }

        public void StartTableWatcher()
        {
            Dependency.Start();
        }

        public void StopTableWatcher()
        {
            Dependency.Stop();
        }

        public void OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {
            throw e.Error;
        }

        public void OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<T> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                PropertyInfo propInfo = e.Entity.GetType().GetProperty("GuidID");
                object itemValue = propInfo.GetValue(e.Entity, null);

                switch (e.ChangeType)
                {
                    case ChangeType.Delete:
                        Console.WriteLine($"Deletou Id:{ itemValue }");
                        break;
                    case ChangeType.Insert:
                        Console.WriteLine($"Inseriu Id:{ itemValue }");
                        break;
                    case ChangeType.Update:
                        Console.WriteLine($"Atualizou Id:{ itemValue }");
                        break;
                }
            }
        }

        private void MapearEntidade()
        {
            mapper = new ModelToTableMapper<T>();

            foreach (var prop in GetValues())
            {
                mapper.AddMapping(prop.Key, prop.Value);
            }
        }

        public static Dictionary<PropertyInfo, string> GetValues()
        {
            Dictionary<PropertyInfo, string> valores = new Dictionary<PropertyInfo, string>();

           
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    var authAttr = attr as AtributoBanco;
                    if (authAttr != null)
                    {
                        var auth = authAttr.NomeBanco;
                        valores.Add(prop, auth);
                    }
                }
            }

            return valores;
        }

    }
}
