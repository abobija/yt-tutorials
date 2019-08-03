using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlConnTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = string.Format(
                    "server={0};uid={1};pwd={2};database={3}",
                    "localhost",
                    "root",
                    "00000000",
                    "wiattend"
                );

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand("SELECT first_name, last_name FROM tag", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var fname = reader.GetString(0);
                            var lname = reader.GetString(1);

                            Console.WriteLine($"{fname} {lname}");
                        }
                    }
                }
            }

            Console.ReadKey(true);
        }
    }
}
