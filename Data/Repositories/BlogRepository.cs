using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApiAuthor.Models.Entities;

namespace WebApiAuthor.Data.Repositories
{
    public class BlogRepository
    {
        public static bool registerBlog(BlogEntity blogEntity)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_blog_create", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", blogEntity.title);
                cmd.Parameters.AddWithValue("@thema", blogEntity.thema);
                cmd.Parameters.AddWithValue("@content", blogEntity.content);
                cmd.Parameters.AddWithValue("@periodicity", blogEntity.periodicity);
                cmd.Parameters.AddWithValue("@allow_comments", blogEntity.allowComments);
                cmd.Parameters.AddWithValue("@creation_date", blogEntity.creationDate);
                cmd.Parameters.AddWithValue("@update_date", blogEntity.updatedDate);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool updateBlog(BlogEntity blogEntity)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_blog_update", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", blogEntity.id);
                cmd.Parameters.AddWithValue("@title", blogEntity.title);
                cmd.Parameters.AddWithValue("@thema", blogEntity.thema);
                cmd.Parameters.AddWithValue("@content", blogEntity.content);
                cmd.Parameters.AddWithValue("@periodicity", blogEntity.periodicity);
                cmd.Parameters.AddWithValue("@allow_comments", blogEntity.allowComments);
                cmd.Parameters.AddWithValue("@creation_date", blogEntity.creationDate);
                cmd.Parameters.AddWithValue("@update_date", blogEntity.updatedDate);
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


        public static BlogEntity findBlog(int id)
        {
            BlogEntity blogEntity = new BlogEntity();
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_blog_get", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogEntity.id = Convert.ToInt32(dr["id"]);
                            blogEntity.title = dr["title"].ToString();
                            blogEntity.thema = dr["thema"].ToString();
                            blogEntity.content = dr["content"].ToString();
                            blogEntity.periodicity = dr["periodicity"].ToString();
                            blogEntity.allowComments = Convert.ToBoolean(dr["allow_comments"]);
                            blogEntity.creationDate = (DateTime)dr["creation_date"];
                            blogEntity.updatedDate = (DateTime)dr["updatedDate"];
                        }
                    }
                    return blogEntity;
                }
                catch (Exception ex)
                {
                    return blogEntity;
                }

            }
        }

        public static List<BlogEntity> listBlog()
        {
            List<BlogEntity> blogList = new List<BlogEntity>();
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_blog_list", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            blogList.Add(new BlogEntity()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                title = dr["title"].ToString(),
                                thema = dr["thema"].ToString(),
                                content = dr["content"].ToString(),
                                periodicity = dr["periodicity"].ToString(),
                                allowComments = Convert.ToBoolean(dr["allow_comments"]),
                                creationDate = (DateTime)dr["creation_date"],
                                updatedDate = (DateTime)dr["update_date"]
                            });
                        }

                    }
                    return blogList;
                }
                catch (Exception ex)
                {
                    return blogList;
                }
            }
        }

        public static bool deleteBlog(int id)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.dataSource))
            {
                SqlCommand cmd = new SqlCommand("sp_blog_delete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;

                }

            }

        }
    }
}