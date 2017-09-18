using XmlUtil.Classes;
using System;
using TableWatcher;

namespace XmlUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            WatcherSqlOracle();
            //WatcherSqlServer();
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
            var ConnectionStringOracle = @"Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 192.168.3.236)(PORT = 1521)))
                                          (CONNECT_DATA =(SERVICE_NAME = mgaora13)));User ID=DESENVMG;Password=bsaude4;";
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
