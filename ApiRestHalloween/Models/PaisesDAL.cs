using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiRestHalloween.Models
{
    public class PaisesDAL
    {

        public PaisesDAL() { }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public List<Pais> GetPaises()
        {
            List<Pais> lista = new List<Pais>();
            string sql = "SELECT * FROM PAIS";


            using (SqlConnection connection = new
            SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader =

                    command.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())

                    {

                        Pais category = new Pais();
                        category.IdPais = reader["IdPais"].ToString();
                        category.Nombre = reader["Nombre"].ToString();


                        lista.Add(category);
                    }

                    reader.Close();

                }
            }
            return lista;
        }
    }
}