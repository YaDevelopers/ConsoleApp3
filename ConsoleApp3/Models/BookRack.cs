using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleApp3.Models
{
    

    //[XmlRoot("Имя_Корневого_Элемента")]
    public class BookRack
    {
      //  [XmlAttribute]
        public int ID;
     //   [XmlAttribute("Наименование")]
        public string Name;
      //  [XmlAttribute("Фирма")]
        public string Firma;
      //  [XmlAttribute("Цена")]
        public string Price;

        
    }

   

}
