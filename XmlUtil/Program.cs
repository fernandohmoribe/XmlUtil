﻿using XmlUtil.Classes;
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
            var ConnectionStringSqlServer = @"Server=mga-sql010;Database=TesteNEventStore;User Id=des;Password=benner;";
            /*var ConnectionStringOracle = @"Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 192.168.3.236)(PORT = 1521)))
                                            (CONNECT_DATA =(SERVICE_NAME = mgaora13)));User ID=DESENVMG;Password=bsaude4;";*/

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
    }
}