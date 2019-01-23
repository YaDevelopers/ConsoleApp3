using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp3 
{
    public class BOokRack : Rack   //книжный стеллаж
    {
        public static int ID = 0;
        public int id { get; set; }
        //private int id = 1;
        public string Name { get; set; }
        public string Firma { get; set; }
        public int IdRack { get; set; }

        
        
                          
        public BOokRack(LinkedList<Models.BookRack> list,Positionable positionable, int price, string name,  string Firma) : base(positionable, price, Firma)
        {
            Name = name;
            this.Firma = Firma;
            id = ID;
            ID++;

            RackDB RDB = new RackDB(Name, 1, id);
            RDB.InDB();

            IdRack = RDB.id;

            //   Console.WriteLine("создается книжный стеллаж");
            Models.BookRack BR = new Models.BookRack {ID = ID - 1, Name = Name, Firma = Firma, Price = Convert.ToString(price) };
            InXML IX = new InXML("D:\\obj.xml",BR, true);
            positionable.changePos();
        }

       

        public override string ToString()
        {
            return $" BookRack - \t Name : {Name} ;\t Firma : {Firma} ;\t Price : {price} ";
        }

        

    }

        public class JournalInfo
    {
        public int ID;
        public TypeEvents TEv;//тип события 
        public DateTime TimeEvent;
        public BOokRack Sender;
        
        public JournalInfo()
        {
            Sender = null;
            TimeEvent = DateTime.Now;         
        }

        public override string ToString()
        {
            return string.Format($"{Sender.ToString()}\t{TEv.ToString()}\t{TimeEvent.ToString()}");
        }
    }

    
}
