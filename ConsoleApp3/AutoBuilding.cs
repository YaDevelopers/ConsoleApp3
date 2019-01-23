using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public delegate void DelBuilding(string message);
    public delegate void EventStoreRack(Journal_Info EvStoreRack);

    class AutoBuilding
    {
        public int id = 0;
        public event DelBuilding builded;
        public event EventStoreRack StoreRackBuilded;                 //отвечает за добавление в журнал
        //public int CountBoxs { get; set; }
        public bool Active { get; set; }                        //показатель выполнения события создания
        public bool ActiveBuild { get; set; }
        int Orders;                                               //количество заказов
        int timeBuilding;                                           //время создания
        SToreRack StoreRackBuild;                                    //записывается временное значение при создание стеллажа
        Queue<SToreRack> StoreRacks;                                  //список стеллажей
        LinkedList<Journal_Info> journals;                                 //журнал событий
        public AutoBuilding(int count, int timeBuild)
        {
            this.Orders = count;                                  //план по созданию стеллажей
            Active = false;
            this.timeBuilding = timeBuild;
            StoreRacks = new Queue<SToreRack>();
            journals = new LinkedList<Journal_Info>();
            StoreRackBuilded += OnEventStoreRack;                     //добавление события в список событий
            /*Thread thr1;
            thr1 = new Thread(new ThreadStart(start));            //добавляем функцию в делегат
            thr1.Start();*/
        }

        public void Close()
        {
            Active = false;
            if (builded != null)
                builded("AutoBuilded close");
        }

        public void Open()                                          //начало работы с событиями
        {
            Active = true;                                          //показательная активация действий
            if (builded != null)
                builded("AutoCreating Open");
            Thread thr;
            thr = new Thread(new ThreadStart(Building));            //добавляем функцию в делегат
            thr.Start();                                            //запускаем делегат
            
        }

        public void OnEventStoreRack(Journal_Info JI)
        {
            journals.Add(JI);
        }

        public void Building()
        {
            while (Active)
            {
                if (Orders > 0 && StoreRacks.Count > 0)
                {
                    Orders--;
                    StoreRackBuild = StoreRacks.Dequeue();
                    //Thread.Sleep(timeBuilding*1000);
                    /*Thread threadBuild1 = new Thread(new ThreadStart(Build));
                    threadBuild1.Start();*/
                    Journal_Info JIo = new Journal_Info(id);
                    Console.WriteLine("АЙДИШНИК " + id);
                    id++;

                    JIo.IdRack = StoreRackBuild.IdRack;
                    JIo.TEv = TypeEvents.OutBuild;
                    JIo.TimeEvent = DateTime.Now;
                    JIo.typeSender = TypeSender.StoreRack;
                    StoreRackBuilded(JIo);
                    if (builded != null)
                    {
                        builded($"{StoreRackBuild.ToString()} OUT BUILD, BEGIN CHECK");
                    }
                    Thread threadBuild = new Thread(new ThreadStart(CheckStoreRack));
                    threadBuild.Start();

                }

            }
            if (builded != null)
            {
                builded("END BUILDED");
            }
        

        }

        public void Build()
        {
            
            Journal_Info JIo = new Journal_Info(id);
            Console.WriteLine("АЙДИШНИК " + id);
            id++;
            
            JIo.IdRack = StoreRackBuild.IdRack;
            JIo.TEv = TypeEvents.OutBuild;
            JIo.TimeEvent = DateTime.Now;
            JIo.typeSender = TypeSender.StoreRack;
            StoreRackBuilded(JIo);
            if (builded != null)
            {
                builded($"{StoreRackBuild.ToString()} OUT BUILD, BEGIN CHECK");
            }
            Thread threadBuild = new Thread(new ThreadStart(CheckStoreRack));
            threadBuild.Start();
        }

        public void CheckStoreRack()
        {
            SToreRack storeRack = StoreRackBuild;
            Journal_Info JInf = new Journal_Info(id);
            JInf.TEv = TypeEvents.InCheck;
            Console.WriteLine("АЙДИШНИК " + id);
            id++;
            JInf.typeSender = TypeSender.StoreRack;
            
            JInf.IdRack = storeRack.IdRack;
            if (StoreRackBuilded != null)                            //если оно не пустое
                StoreRackBuilded(JInf);
            if (storeRack.Name != "")
            {
                Journal_Info JIo = new Journal_Info(id);
                
                JIo.TEv = TypeEvents.OutCheck;
                Console.WriteLine("АЙДИШНИК " + id);
                JIo.typeSender = TypeSender.StoreRack;
                id++;
                JIo.IdRack = storeRack.IdRack;
                // JIo.TimeEvent = DateTime.Now;
                if (StoreRackBuilded != null)
                {
                    StoreRackBuilded(JIo);
                }
                if (builded != null)
                {

                    builded($"{storeRack.ToString()} OUT CHECK");
                }
            }
            else
            {

                Journal_Info JIo1 = new Journal_Info(id);
                JIo1.IdRack = storeRack.IdRack;
                Console.WriteLine("АЙДИШНИК " + id);
                JIo1.typeSender = TypeSender.StoreRack;
                id++;
                JIo1.TEv = TypeEvents.ErrorCheck;
                JIo1.TimeEvent = DateTime.Now;
                StoreRackBuilded(JIo1);
                if (builded != null)
                {
                    builded($"{storeRack.ToString()} ERROR CHECK");
                }
            }
            
            
            
        }

        public void AddStoreRack(SToreRack current)
        {
            StoreRacks.Enqueue(current);
            Journal_Info JI = new Journal_Info(id);
            JI.TEv = TypeEvents.InBuild;
            Console.WriteLine("АЙДИШНИК " + id);
            JI.typeSender = TypeSender.StoreRack;
            id++;
            JI.IdRack = current.IdRack;
            JI.TimeEvent = DateTime.Now;
            if (StoreRackBuilded != null)
            {
                StoreRackBuilded(JI);
            }
            if (builded != null)
            {
                builded($"{current.ToString()} IN BUILD");
            }
        }



        public void ViewEvents()                                                        //вывод журнала
        {
            Console.WriteLine("View Journal");
            foreach (Journal_Info curJI in journals)
            {
                
                Models.Journal_Info JI = new Models.Journal_Info {ID = curJI.ID , TEv = curJI.TEv.ToString(), TimeEvent = (curJI.TimeEvent), IdRack = (curJI.IdRack), ts = curJI.typeSender };
                InXML IX = new InXML("D:\\obj.xml", JI,true);
                
                Console.WriteLine(curJI.ToString());

            }
           

        }
    }
}
