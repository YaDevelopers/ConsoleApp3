using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{


    public abstract class Rack                                                  //стеллаж
    {
        public int price;                                                       //цена
        public string manufacturer;                                             //производитель
        
        public Positionable positionable { get; set; }                          //указывает на интерфейс
        public Rack(Positionable positionable, int price, string manufacturer)
        {
            
            this.manufacturer = manufacturer;
            this.price = price;
            this.positionable = positionable;
          
        }

        public Rack()
        {
            manufacturer = null;
            price = 0;
            positionable = null;
        }
        
        public virtual void doWork()                                            //работа с интерфейсом
        {
            positionable.changePos();
        }
        
       
    }
}
