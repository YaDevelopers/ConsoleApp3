using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class RackDB
    {
        public static int ID = 0;
        public int id { get; set; }
        public string Name { get; set; }
        public int TypeRack { get; set; }
        public int IdTypeRack { get; set; }

        public RackDB(string Name, int TR, int IDR)
        {
            id = ID;
            ID++;
            this.Name = Name;
            TypeRack = TR;
            IdTypeRack = IDR;
        }

        public void InDB()
        {
            SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ='C:\Users\nikit\source\repos\ConsoleApp3\ConsoleApp3\Rack.mdf'; Integrated Security = True");
            try
            {
                // Открываем подключение
                connection.Open();
                Console.WriteLine("Подключение открыто для журнала");


              


                int Id = this.id;
                string Name = this.Name;
                int TypeRack = this.TypeRack;
                int IdTypeRack = this.IdTypeRack;


                string sql = string.Format("Insert Into [Rack]" +
                       "(Id, Name, TypeRack, IdTypeRack) Values(@Id, @Name, @TypeRack, @IdTypeRack)");

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@TypeRack", TypeRack);
                    cmd.Parameters.AddWithValue("@IdTypeRack", IdTypeRack);
                   

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
