using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace OracleRoles
{
    class Program
    {
        static void Main(string[] args)
        {


            var context = new Entities();
          
            context.Database.ExecuteSqlCommand("set role lims_user");
            for (int i = 0; i < 55555555; i++)
            {
                Thread.Sleep(5000);

                var aa = context.Database.SqlQuery<string>("select * from session_roles").ToList();
                Console.WriteLine(DateTime.Now + " " + aa[0]);

            }
            return;
            OracleConnection oraCon = new OracleConnection();
            oraCon.ConnectionString = "data source=PATHOLAB;password=aa;user id=Ashi";
            oraCon.Open();
            OracleCommand cmd = new OracleCommand("set role lims_user", oraCon);
            cmd.ExecuteNonQuery();
            for (int i = 0; i < 1200000; i++)
            {

                Thread.Sleep(5000);
                cmd.CommandText = "select * from session_roles";
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    var s = (res[0].ToString());
                    Console.WriteLine(s);

                    if (s == "LIMS_READONLY")
                    {
                        Console.WriteLine(s);
                        Console.WriteLine("sinish");
                        Console.Read();
                        break;
                    }

                    {

                    }
                }

            }
            oraCon.Close();
        }

        public static void WriteLogFile(string exception)
        {
            try
            {



                using (FileStream file = new FileStream("C:\\BB.txt", FileMode.Append, FileAccess.Write))
                {
                    var streamWriter = new StreamWriter(file);
                    streamWriter.WriteLine(DateTime.Now);
                    streamWriter.WriteLine(exception);
                    streamWriter.WriteLine("///////////////////////////////////////////");

                    streamWriter.Close();
                }
            }
            catch
            {
            }


        }

    }
}
