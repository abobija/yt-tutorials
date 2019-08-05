using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLInsertDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string uid;
            string fname;
            string lname;

            Console.Write("UID: ");
            uid = Console.ReadLine();

            Console.Write("First Name: ");
            fname = Console.ReadLine();

            Console.Write("Last Name: ");
            lname = Console.ReadLine();

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

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO tag(uid, first_name, last_name) " +
                        "VALUES (@uid, @fname, @lname)";

                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@lname", lname);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
