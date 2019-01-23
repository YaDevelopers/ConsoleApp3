using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp3
{
    public delegate void DelCreating(string message);
    public delegate void EventBookRack(JournalInfo EvBookRack);

    class AutoCreating
    {
        public int id = 0;
        public event DelCreating created;
        public event EventBookRack BookRackCreated;                 //отвечает за добавление в журнал
        //public int CountBoxs { get; set; }
        public bool Active { get; set; }                            //показатель выполнения события создания
        int FreeBoxs;                                               //количество объектов в "очереди"
        int timeCreating;                                           //время создания
        BOokRack BookRackCreate;                                    //записывается временное значение при создание стеллажа
        Queue<BOokRack> BookRacks;                                  //список стеллажей
        List<JournalInfo> journals;                                 //журнал событий
        public AutoCreating(int count, int timeCreate)
        {
            this.FreeBoxs = count;                                  //план по созданию стеллажей
            Active = false;
            this.timeCreating = timeCreate;
            BookRacks = new Queue<BOokRack>();
            journals = new List<JournalInfo>();
            BookRackCreated += OnEventBookRack;                     //добавление события в список событий
        }

        public void Open()                                          //начало работы с событиями
        {
            Active = true;                                          //показательная активация действий
            if (created != null)
                created("AutoCreating Open");
            Thread thr;
            thr = new Thread(new ThreadStart(Creating));            //добавляем функцию в делегат
            thr.Start();                                            //запускаем делегат
        }

        public void OnEventBookRack(JournalInfo argevBookRack)      //добавляет список в журнал
        {
            journals.Add(argevBookRack);
        }

        public void CreateBookRack()                                //создает стеллаж
        {
            BOokRack current = BookRackCreate;                      //обработка через временную переменную
            FreeBoxs--;                                             //уменьшается количество стелажей на событие в очереди
            JournalInfo JInf = new JournalInfo();
            JInf.ID = id;
            id++;
            JInf.TEv = TypeEvents.StartCreate;
            JInf.Sender = current;                                  //запись в журнал объекта 
            if (BookRackCreated != null)                            //если оно не пустое
                BookRackCreated(JInf);                              //выполнение функций в событии 

        }

        public void Close()
        {
            Active = false;
            if (created != null)
                created("AutoCreated close");
        }

        public void AddBookRack(BOokRack currentBookRack)                               //добавление в список стеллажа
        {
            BookRacks.Enqueue(currentBookRack);                                         //добавляет элемент в конец очереди
            JournalInfo JInf = new JournalInfo();
            JInf.ID = id;
            id++;
            JInf.TEv = TypeEvents.InRepare;
            JInf.Sender = currentBookRack;
            if (BookRackCreated != null)
                BookRackCreated(JInf);                                                 //идет заполнение в журнал
            if (created != null)
                created(currentBookRack.ToString() + " in Repare");                     //выводит инфу
        }

        public void Creating()                                                         
        {
            while (Active)                                                              //пока события течет
            {
                if (FreeBoxs > 0 && BookRacks.Count > 0)                                                     //если очередь не пуста
                {
                    BookRackCreate = BookRacks.Dequeue();                               //удаляет первый помещенный элемент и возвращает их
                    if (created != null)
                        created(BookRackCreate.ToString() + " begin create");          //таким способом идет выборка из списка стеллажей
                    Thread threadCreate = new Thread(new ThreadStart(CreateBookRack));  //открывается поток(записывается в делегат)
                    threadCreate.Start();                                               //запускается
                }
            }
            if (created != null)                                                        //описание события и времени
                created("AutoCreating end job");
        }

        public void ViewEvents()                                                        //вывод журнала
        {
            Console.WriteLine("View Journal");
            
            foreach (JournalInfo curJI in journals)                                 
            {
                Console.WriteLine(curJI);
                Models.Journal_Info JI = new Models.Journal_Info {ID = curJI.ID + id, TEv = curJI.TEv.ToString(), TimeEvent = (curJI.TimeEvent) };
                InXML IX = new InXML("D:\\obj.xml", JI,true);
                id++;
            } 
            
          
            }
        /*
        public void InputBD(List<JournalInfo> journals, string pathname)
        {
            foreach (JournalInfo e in journals)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(pathname);
                XmlElement xRoot = xDoc.DocumentElement;
                // создаем новый элемент user
                XmlElement userElem = xDoc.CreateElement("object");
                // создаем атрибут name
                XmlAttribute nameAttr = xDoc.CreateAttribute("name");
                // создаем элементы company и age
                XmlElement IdElem = xDoc.CreateElement("Id");
                XmlElement companyElem = xDoc.CreateElement("company");
                XmlElement priceElem = xDoc.CreateElement("price");
                // создаем текстовые значения для элементов и атрибута
                XmlText idText = xDoc.CreateTextNode(Convert.ToString(e.TEv));
                XmlText nameText = xDoc.CreateTextNode(Name);
                XmlText companyText = xDoc.CreateTextNode(Firma);
                XmlText priceText = xDoc.CreateTextNode(Convert.ToString(Price));

                //добавляем узлы
                nameAttr.AppendChild(idText);
                IdElem.AppendChild(idText);
                companyElem.AppendChild(companyText);
                priceElem.AppendChild(priceText);
                userElem.Attributes.Append(nameAttr);
                userElem.AppendChild(IdElem);
                userElem.AppendChild(companyElem);
                userElem.AppendChild(priceElem);
                xRoot.AppendChild(userElem);
                xDoc.Save(pathname);
            }
        }*/
    }

        
    }

