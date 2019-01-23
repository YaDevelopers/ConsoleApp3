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

    public class SToreRack : Rack    //стеллаж для магазинов
    {
        public static  int ID = 0;
        public int Id;
        public string Name;
        public int square;
        public int IdRack { get; set; }

        public SToreRack(Positionable positionable, int price, string name, string manufact, int x, int y, int z) : base(positionable,price,manufact)
        {
            Id = ID;
            this.Name = name;
            ID++;
            positionable.changePos();

            RackDB RDB = new RackDB(Name, 1, Id);
            RDB.InDB();

            IdRack = RDB.id;

            Models.StoreRack BR = new Models.StoreRack {id = ID - 1, name = Name, Firma = manufact,Square = Convert.ToString(x*y), Price = Convert.ToString(price) };
            InXML IX = new InXML("D:\\obj.xml",BR,true);
        }

        public override string ToString()
        {
            return $"СКЛАДСКОЙ СТЕЛЛАЖ\tНаименование - {Name}\tПлощадь основания - {square}\tЦена - {price}\tФирма производства - {manufacturer}";
        }

    }

    public class Journal_Info
    {
        public int ID;
        public TypeEvents TEv;//тип события 
        public DateTime TimeEvent;
        public int IdRack;
        public TypeSender typeSender;//тип объекта

        public Journal_Info(int ID)
        {
            this.ID = ID;
            TimeEvent = DateTime.Now;
            
        }

        public override string ToString()
        {
            return string.Format($"{IdRack.ToString()}\t{TEv.ToString()}\t{TimeEvent.ToString()}\t{typeSender.ToString()}");
        }
    }

}
