using BloggingSite_RazorPages_StoredProcedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BloggingSite_RazorPages_StoredProcedure.DataAccess
{
    public class PostDA
    {
        string connectionString = "Data Source =.\\sqlexpress;Initial Catalog = BlogSiteRazorSP; Integrated Security = True";

        public IEnumerable<Post> GetAllPost()
        {
            List<Post> posts = new List<Post>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllPost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Post post = new Post();

                    post.PostId = Convert.ToInt32(dataReader["PostId"]);
                    post.Title = dataReader["Title"].ToString();
                    post.Description = dataReader["Description"].ToString();
                    post.CreatedOn = Convert.ToDateTime(dataReader["CreadtedOn"].ToString());
                    post.UpdatedOn = Convert.ToDateTime(dataReader["UpdatedOn"].ToString() == "" ? DateTime.Now.ToString() : dataReader["UpdatedOn"]);
                    post.UserName = dataReader["UserName"].ToString();
                    post.UserId = Convert.ToInt32(dataReader["UserId"]);

                    posts.Add(post);

                }
                con.Close();
            }
            return posts;
        }
        public void AddPost(Post post)
        {
            List<Post> posts = new List<Post>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("AddPost", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Description", post.Description);
                cmd.Parameters.AddWithValue("@UserName", post.UserName);
                cmd.Parameters.AddWithValue("@UserId", post.UserId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    



       //Get the details of a particular post
       public Post GetPostData(int? id)
        {
            Post post = new Post();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //string sqlQuery = "GetPostData";
                //SqlCommand cmd = new SqlCommand(sqlQuery, con);
                //cmd.Parameters.AddWithValue("@PostId", post.PostId);

                string sqlQuery = "SELECT * FROM Posts WHERE PostId= " +id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    post.PostId = Convert.ToInt32(rdr["PostId"]);
                    post.Title = rdr["Title"].ToString();
                    post.Description = rdr["Description"].ToString();
                    post.UserName = rdr["UserName"].ToString();
                   
                }
            }
            return post;
        }

        public void UpdatePost(Post post)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdatePost", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PostId", post.PostId);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                
                cmd.Parameters.AddWithValue("@Description", post.Description);
                cmd.Parameters.AddWithValue("@UserName", post.UserName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public Post DeletePost(int? id)
        {
            Post post = new Post();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand("DeletePost", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@Id", id);

                connection.Open();
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
            return post;

        }

    }
}
