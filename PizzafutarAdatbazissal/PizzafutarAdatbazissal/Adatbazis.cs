using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzafutarAdatbazissal
{
    internal class Adatbazis
    {
        private string connectionString;

        public Adatbazis()
        {
            this.connectionString = "server=localhost;database=pizzafutár;user id=root;password=;";
        }

        public List<Rendeles> Feltolt()
        {
            List<Rendeles> rendelesek = new List<Rendeles>();
            Dictionary<int, Pizza> pizzak = new Dictionary<int, Pizza>();
            Dictionary<int, Cim> cimek = new Dictionary<int, Cim>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM cim";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                string utca = reader.GetString("utca");
                                string hazszam = reader.GetString("hsz");
                                Cim cim = new Cim(id, nev, utca, hazszam);
                                cimek.Add(id, cim);
                            }
                        }
                    }

                    query = "SELECT * FROM pizza";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                int meret = reader.GetInt32("meret");
                                int ar = reader.GetInt32("ar");
                                Pizza pizza = new Pizza(id, nev, meret, ar);
                                pizzak.Add(id, pizza);
                            }
                        }
                    }

                    query = "SELECT * FROM rendeles";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                int db = reader.GetInt32("darab");
                                int pizzaId = reader.GetInt32("pizzaid");
                                int cimId = reader.GetInt32("cimid");
                                TimeSpan rendelesIdeje = reader.GetTimeSpan("szallitas");
                                Pizza pizza = pizzak[pizzaId];
                                Cim cim = cimek[cimId];
                                Rendeles rendeles = new Rendeles(id, pizza, db, cim, rendelesIdeje);
                                rendelesek.Add(rendeles);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatok betöltése közben: " + ex.Message);
                Environment.Exit(1);
            }

            return rendelesek;

        }
    }
}
