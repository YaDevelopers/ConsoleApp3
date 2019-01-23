using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp3
{

    class Program
    {

        public static void OnCreating(string message)
        {
            Console.WriteLine($"Event {message} {DateTime.Now}");
        }

        static void Main(string[] args)
        {



             Random rnd = new Random();
             AutoBuilding build = new AutoBuilding(2, 2000);
             build.builded += OnCreating;
             build.Open();
             for (int i = 0; i <= 10; i++)
             {
                 Thread.Sleep(rnd.Next(3000));
                 if (i % 2 == 0)
                 {
                     build.AddStoreRack(new SToreRack(new StorePos(), 2, "number 1", "firma1", 1, 1, 4));
                 }
                 else

                 {
                     build.AddStoreRack(new SToreRack(new StorePos(), 2, "number 2", "firma2", 1, 2, 4));
                     Console.WriteLine("input else");
                 }
                 Thread.Sleep(5000);
                 build.Close();
                 build.ViewEvents();
                

                 Console.Read();

             }

             

        }
    }
}