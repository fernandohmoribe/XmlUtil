using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableWatcher
{
    public class TableWatcherStrategy<T> where T : class
    {
        private ITableWatcher<T> TableWatcherAbstract;

        public TableWatcherStrategy(ITableWatcher<T> pTableWatcherAbstract)
        {
            TableWatcherAbstract = pTableWatcherAbstract;
        }

        public void InitializeTableWatcher()
        {
            TableWatcherAbstract.InitializeTableWatcher();
        }

        public void StartTableWatcher()
        {
            TableWatcherAbstract.StartTableWatcher();
        }

        public void StopTableWatcher()
        {
            TableWatcherAbstract.StopTableWatcher();
        }
    }
}
