using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using practica_30_09_2022.Properties;
using System.Configuration;

namespace practica_30_09_2022.DAL
{
    public class Database
    {
        public static string getStrConnection()
        {
            return Settings.Default.ConnectionString;
        }

        public SqlConnection getConnection()
        {
            SqlConnection Con = new SqlConnection(getStrConnection());
            return Con;
        }
        
        public bool testConnection()
        {
            SqlConnection Con = this.getConnection();
            Con.Open();
            if (Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
                return true;
            }
            else
            {
                return false;
            }
            public bool testInsert(string nombre, string ubicacion)
            {
                try
                {
                    SqlConnection Con = this.getConnection();
                    using (SqlCommand cmd = Con.CreateCommand())
                    {
                        Con.Open();
                        cmd.CommandText = "INSERT INTO Sedes (nombre, ubicacion) VALUES (@nom, @ub);";
                        cmd.Parameters.AddWithValue("@nom", nombre);
                        cmd.Parameters.AddWithValue("@ub", ubicacion);
                        cmd.ExecuteNonQuery();
                        Con.Close();

                        return true;


                    }


                }
                catch
                {
                    return false;
                }
            }

                


            
            
        }

    }
}
