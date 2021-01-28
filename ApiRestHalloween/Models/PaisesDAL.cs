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

        internal int DeletePais(Pais pais)
        {
            int afectadas;
            string sql = "DELETE FROM Pais " +
            "WHERE IdPais = @IdPais";
            using (SqlConnection connection = new
            SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@CategoryID",
                    pais.IdPais);
                    connection.Open();

                    afectadas = command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            return afectadas;
        }

        internal int UpdatePais(Pais pais)
        {
            int afectadas;
            string sql = "UPDATE Pais " +
            "SET ShortName = @Nombre" +
            "WHERE IdPais = @IdPais";
            using (SqlConnection connection = new
            SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdPais",
                   pais.IdPais);
                    command.Parameters.AddWithValue("@Nombre", pais.Nombre);

                    connection.Open();

                    afectadas = command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            return afectadas;
        }

        internal int InsertarPais(Pais pais)
        {
            int afectadas;
            string sql = "INSERT INTO Pais" +
            "(IdPais, Nombre) " +
            "VALUES (@IdPais, @Nombre)";

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdPais",
                    pais.IdPais);
                    command.Parameters.AddWithValue("@Nombre", pais.Nombre);

                    connection.Open();
                    afectadas = command.ExecuteNonQuery();

                    connection.Close();

                }
            }
            return afectadas;
        }


    }
}