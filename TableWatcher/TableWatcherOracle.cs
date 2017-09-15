using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.Enums;
using TableDependency.SqlClient;
using TableWatcher.Base;

namespace TableWatcher
{
    public class TableWatcherOracle<T> : ITableWatcher<T> where T : class
    {
        public readonly String ConnectionString; 
        public TableWatcherOracle(String connectionString)
        {
            ConnectionString = connectionString;
        }

        public void InitializeTableWatcher()
        {
            
        }

        public void StartTableWatcher()
        {
           
        }

        public void StopTableWatcher()
        {
          
        }

        public void OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {
      
        }

        public void OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<T> e)
        {
           
        }

       
    }
}
