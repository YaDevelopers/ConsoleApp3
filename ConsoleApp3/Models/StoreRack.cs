using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp3.Models
{
   // [XmlRoot("Имя_Корневого_Элемента")]
    public class StoreRack
    {
       // [XmlAttribute]
        public int id;
      //  [XmlAttribute("Наименование")]
        public string name;
       // [XmlAttribute("Фирма")]
        public string Firma;
      //  [XmlAttribute("Площадь")]
        public string Square;
      //  [XmlAttribute("Цена")]
        public string Price;


    }
}
