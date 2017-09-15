using XmlUtil.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using TableDependency;
using TableDependency.Enums;
using TableDependency.SqlClient;
using TableWatcher;
using XMLSerializeDeserialize;

namespace XmlUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            /*";*/

            WatcherSqlOracle();
            WatcherSqlServer();
        }


        private static void WatcherSqlServer()
        {
            var ConnectionStringSqlServer = @"";
            var TableWatcher = new TableWatcherStrategy<Nota>(new TableWatcherSqlServer<Nota>(ConnectionStringSqlServer));
            try
            {
                TableWatcher.InitializeTableWatcher();
                TableWatcher.StartTableWatcher();
                Console.WriteLine("Esperando para receber notificações...");
                Console.WriteLine("Precione qualquer tecla para sair");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                TableWatcher.StopTableWatcher();
            }
        }

        private static void WatcherSqlOracle()
        {
            var ConnectionStringOracle = @"";
            var TableWatcher = new TableWatcherStrategy<Nota>(new TableWatcherOracle<Nota>(ConnectionStringOracle));
            try
            {
                TableWatcher.InitializeTableWatcher();
                TableWatcher.StartTableWatcher();
                Console.WriteLine("Esperando para receber notificações...");
                Console.WriteLine("Precione qualquer tecla para sair");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                TableWatcher.StopTableWatcher();
            }
        }
    }
}
