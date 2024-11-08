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
                            authorEntity.Names =  dr["names_"].ToString();
                            authorEntity.FirstName = dr["first_surname"].ToString();
                            authorEntity.SecondSurname = dr["second_surname"].ToString();
                            authorEntity.BirthDate = (DateTime)dr["birth_date"];
                            authorEntity.CountryResidence = dr["country_residence"].ToString();
                            authorEntity.Mail = dr["mail"].ToString();
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


        public static List<AuthorEntity> getAuthorList() { 

            List<AuthorEntity> authorList = new List<AuthorEntity>();
            using (SqlConnection connection =  new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_list_author", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read()) {
                            authorList.Add(new AuthorEntity()
                            {
                                Id = Convert.ToInt32(dr["id"]),
                                Names = dr["names_"].ToString(),
                                FirstName = dr["first_surname"].ToString(),
                                SecondSurname = dr["second_surname"].ToString(),
                                BirthDate = dr["birth_date"] != DBNull.Value ? (DateTime)dr["birth_date"] : DateTime.MinValue,
                                CountryResidence = dr["country_residence"].ToString(),
                                Mail = dr["mail"].ToString()
                            });                      
                            
                        }

                    }
                    return authorList;

                } 
                catch (Exception ex)
                {

                    return authorList;
                }


            }


        }

        public static bool delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_delete_author", connection); 
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }

        }


    }
}