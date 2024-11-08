using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiAuthor.Models;

namespace WebApiAuthor.Data.Repositories
{
    public class AuthorRepository
    {
        public static bool registerAuthor(AuthorEntity authorEntity) {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_insert_author", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@names_", authorEntity.Names);
                cmd.Parameters.AddWithValue("@first_surname", authorEntity.FirstName);
                cmd.Parameters.AddWithValue("@second_surname", authorEntity.SecondSurname);
                cmd.Parameters.AddWithValue("@birth_date", authorEntity.BirthDate);
                cmd.Parameters.AddWithValue("@country_residence", authorEntity.CountryResidence);
                cmd.Parameters.AddWithValue("@mail", authorEntity.Mail);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    return false;
                }

            }

        }

        public static bool updateAuthor(AuthorEntity authorEntity)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_update_author", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@@id", authorEntity.Id);
                cmd.Parameters.AddWithValue("@names_", authorEntity.Names);
                cmd.Parameters.AddWithValue("@first_surname", authorEntity.FirstName);
                cmd.Parameters.AddWithValue("@second_surname", authorEntity.SecondSurname);
                cmd.Parameters.AddWithValue("@birth_date", authorEntity.BirthDate);
                cmd.Parameters.AddWithValue("@country_residence", authorEntity.CountryResidence);
                cmd.Parameters.AddWithValue("@mail", authorEntity.Mail);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public static AuthorEntity getFindId(int id)
        {
            AuthorEntity authorEntity = new AuthorEntity();
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource)) {
                SqlCommand cmd = new SqlCommand("sp_get_author", connection);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            authorEntity.Id = Convert.ToInt32(dr["id"]);
                            authorEntity.Names =  (string)dr["names_"];
                            authorEntity.FirstName = (string)dr["first_surname"];
                            authorEntity.SecondSurname = (string)dr["second_surname"];
                            authorEntity.BirthDate = (DateTime)dr["birth_date"];
                            authorEntity.CountryResidence = (string)dr["country_residence"];
                            authorEntity.Mail = (string)dr["mail"];
                        }
                    }
                    return authorEntity;
                }
                catch (Exception)
                {
                    return authorEntity;
                }
            }

        }




    }
}