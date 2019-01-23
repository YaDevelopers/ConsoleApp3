using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp3
{
    public class InXML
    {
        public InXML(string pathname, Models.BookRack br, bool qw)
        {
            if (qw)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(pathname);
                XmlElement xRoot = xDoc.DocumentElement;
                // создаем новый элемент user
                XmlElement userElem = xDoc.CreateElement("user");
                // создаем атрибут name
                XmlAttribute nameAttr = xDoc.CreateAttribute("name");

                XmlElement IdElem = xDoc.CreateElement("Id");
                XmlElement companyElem = xDoc.CreateElement("company");
                XmlElement priceElem = xDoc.CreateElement("price");
                // создаем текстовые значения для элементов и атрибута
                XmlText idText = xDoc.CreateTextNode(Convert.ToString(br.ID));
                XmlText nameText = xDoc.CreateTextNode(br.Name + Convert.ToString(br));
                XmlText companyText = xDoc.CreateTextNode(br.Firma);
                XmlText priceText = xDoc.CreateTextNode(Convert.ToString(br.Price));

                //добавляем узлы
                nameAttr.AppendChild(nameText);
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

            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='C:\Users\nikit\source\repos\ConsoleApp3\ConsoleApp3\Rack.mdf'; Integrated Security = True");
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");

                int ID = br.ID;
                string Name = br.Name;
                string Firma = br.Firma;
                string Price = br.Price;


                string sql = string.Format("Insert Into BOokRack" +
                       "(ID, Name, Firma, Price) Values(@ID, @Name, @Firma, @Price)");

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Firma", Firma);
                    cmd.Parameters.AddWithValue("@Price", Price);

                    cmd.ExecuteNonQuery();
                }

                

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }

        public InXML(string pathname, Models.StoreRack br, bool qw)
        {
            if (qw)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(pathname);
                XmlElement xRoot = xDoc.DocumentElement;
                // создаем новый элемент user
                XmlElement userElem = xDoc.CreateElement("user");
                // создаем атрибут name
                XmlAttribute nameAttr = xDoc.CreateAttribute("name");

                XmlElement IdElem = xDoc.CreateElement("Id");
                XmlElement companyElem = xDoc.CreateElement("company");
                XmlElement squareElem = xDoc.CreateElement("square");
                XmlElement priceElem = xDoc.CreateElement("price");
                // создаем текстовые значения для элементов и атрибута
                XmlText idText = xDoc.CreateTextNode(Convert.ToString(br.id));
                XmlText nameText = xDoc.CreateTextNode(br.name + Convert.ToString(br));
                XmlText companyText = xDoc.CreateTextNode(br.Firma);
                XmlText squareText = xDoc.CreateTextNode(Convert.ToString(br.Square));
                XmlText priceText = xDoc.CreateTextNode(Convert.ToString(br.Price));

                //добавляем узлы
                nameAttr.AppendChild(nameText);
                IdElem.AppendChild(idText);
                companyElem.AppendChild(companyText);
                priceElem.AppendChild(priceText);
                userElem.Attributes.Append(nameAttr);
                userElem.AppendChild(IdElem);
                userElem.AppendChild(companyElem);
                userElem.AppendChild(squareElem);
                userElem.AppendChild(priceElem);
                xRoot.AppendChild(userElem);
                xDoc.Save(pathname);
            }
            // string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=BetekBash;Integrated Security=True";

            // Создание подключения
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='C:\Users\nikit\source\repos\ConsoleApp3\ConsoleApp3\Rack.mdf'; Integrated Security = True");
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто");

                int ID = br.id;
                string Name = br.name;
                string Firma = br.Firma;
                string Square = br.Square;
                string Price = br.Price;


                string sql = string.Format("Insert Into StoreRack" +
                       "(ID, Name, Firma, Square, Price) Values(@ID, @Name, @Firma, @Square, @Price)");

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Firma", Firma);
                    cmd.Parameters.AddWithValue("@Square", Square);
                    cmd.Parameters.AddWithValue("@Price", Price);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }

        public InXML(string pathname, Models.Journal_Info br, bool qw)
        {
            if (qw)
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(pathname);
                XmlElement xRoot = xDoc.DocumentElement;
                // создаем новый элемент user
                XmlElement userElem = xDoc.CreateElement("user");
                // создаем атрибут name
                XmlAttribute nameAttr = xDoc.CreateAttribute("name");

                XmlElement IdElem = xDoc.CreateElement("Id");
                XmlElement typeElem = xDoc.CreateElement("типCобытия");
                XmlElement timeElem = xDoc.CreateElement("время");

                // создаем текстовые значения для элементов и атрибута
                XmlText idText = xDoc.CreateTextNode(Convert.ToString(br.ID));
                XmlText nameText = xDoc.CreateTextNode(Convert.ToString(br.ts));
                XmlText typeText = xDoc.CreateTextNode(br.TEv.ToString());
                XmlText timeText = xDoc.CreateTextNode(Convert.ToString(br.TimeEvent));
                // XmlText priceText = xDoc.CreateTextNode(Convert.ToString(br.Price));

                //добавляем узлы
                nameAttr.AppendChild(nameText);
                IdElem.AppendChild(idText);
                typeElem.AppendChild(typeText);
                timeElem.AppendChild(timeText);
                userElem.Attributes.Append(nameAttr);
                userElem.AppendChild(IdElem);
                userElem.AppendChild(typeElem);
                userElem.AppendChild(timeElem);
                // userElem.AppendChild(priceElem);
                xRoot.AppendChild(userElem);
                xDoc.Save(pathname);
            }

            // Создание подключения
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='C:\Users\nikit\source\repos\ConsoleApp3\ConsoleApp3\Rack.mdf'; Integrated Security = True");
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто для журнала");

                // DateTime dt1 = new DateTime(2018, 12, 24);
                // DateTime dt2 = dt1.Subtract(new TimeSpan(, 0, 0, 0));
                DateTime date1 = new DateTime(2018, 12, 24);
                DateTime date2 = new DateTime(2018, 12, 21);

                

                SqlDataAdapter daAuthors = new SqlDataAdapter(
                    "select Journal_Info1.TimeEvent, Journal_Info1.TEv,Rack.Name, from Journal_Info1, Rack.TypeRack, SToreRack.Firma, SToreRack.Square,  SToreRack.Price where Journal_Info1.TimeEvent > date2 and Journal_Info1.TimeEvent < date1 and (Journal_Info1.IdRack = 1) and (SToreRack.Id = Rack.IdTypeRack)  ", connection);
                //данные за определенный период 
                //по типу объекта
                DataSet dsPubs = new DataSet("Rack");
                daAuthors.FillSchema(dsPubs, SchemaType.Source, "Journal_Info1");
                daAuthors.Fill(dsPubs, "Journal_Info1");

                DataTable tblAuthors;
                tblAuthors = dsPubs.Tables["Journal_Info1"];

                foreach (DataRow drCurrent in tblAuthors.Rows)
                {
                    Console.WriteLine("{0} {1}",
                    drCurrent["ID"].ToString(),
                    drCurrent["ts"].ToString());
                }


                int ID = br.ID;
                string TEv = br.TEv.ToString();
                DateTime TimeEvent = br.TimeEvent;
                int IdRack = br.IdRack;
                string ts = br.ts.ToString();


                string sql = string.Format("Insert Into Journal_Info1" +
                       "(ID, TEv, TimeEvent, IdRack, ts) Values(@ID, @TEv, @TimeEvent, @IdRack, @ts)");

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@TEv", TEv);
                    cmd.Parameters.AddWithValue("@TimeEvent", TimeEvent);
                    cmd.Parameters.AddWithValue("@IdRack", IdRack);
                    cmd.Parameters.AddWithValue("@ts", ts);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // закрываем подключение
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }

           

        }
    }
}
