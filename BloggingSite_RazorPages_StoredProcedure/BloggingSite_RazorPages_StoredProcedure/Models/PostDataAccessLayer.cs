using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSite_RazorPages_StoredProcedure.Models
{
    public class PostDataAccessLayer
    {
        string connectionString = ".\\sqlexpress;Initial Catalog=BlogSiteRazorSP;Integrated Security=True";

        //To View all Posts details    
    //    public IEnumerable<Post> GetAllPost()
    //    {
    //        List<Post> posts = new List<Post>();

    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("spGetAllPosts", con);
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            con.Open();
    //            SqlDataReader rdr = cmd.ExecuteReader();

    //            while (rdr.Read())
    //            {
    //                Post post = new Post();

    //                post.PostId = Convert.ToInt32(rdr["PostId"]);
    //                post.PostTitle = rdr["PostTitle"].ToString();
    //                post.DatePosted = Convert.ToDateTime(rdr["DatePosted"]);
    //                post.DateEdited = Convert.ToDateTime(rdr["DateEdited"]);
    //                post.PostContent = rdr["PostContent"].ToString();
    //                post.PostAuthor = rdr["PostAuthor"].ToString();
    //                post.Name = rdr["Name"].ToString();
    //                post.CommentDate = Convert.ToDateTime(rdr["CommentDate"]);
    //                post.Comment = rdr["Comment"].ToString();

    //                posts.Add(post);
    //            }
    //            con.Close();
    //        }
    //        return posts;
    //    }

    //    //To Add new employee record    
    //    public void AddEmployee(Post post)
    //    {
    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("spAddPosts", con);
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@pTitle", post.PostTitle);
    //            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
    //            cmd.Parameters.AddWithValue("@Department", employee.Department);
    //            cmd.Parameters.AddWithValue("@City", employee.City);

    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }

    //    //To Update the records of a particluar employee  
    //    public void UpdateEmployee(Employee employee)
    //    {
    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@EmpId", employee.ID);
    //            cmd.Parameters.AddWithValue("@Name", employee.Name);
    //            cmd.Parameters.AddWithValue("@Gender", employee.Gender);
    //            cmd.Parameters.AddWithValue("@Department", employee.Department);
    //            cmd.Parameters.AddWithValue("@City", employee.City);

    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }

    //    //Get the details of a particular employee  
    //    public Employee GetEmployeeData(int? id)
    //    {
    //        Employee employee = new Employee();

    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
    //            SqlCommand cmd = new SqlCommand(sqlQuery, con);

    //            con.Open();
    //            SqlDataReader rdr = cmd.ExecuteReader();

    //            while (rdr.Read())
    //            {
    //                employee.ID = Convert.ToInt32(rdr["EmployeeID"]);
    //                employee.Name = rdr["Name"].ToString();
    //                employee.Gender = rdr["Gender"].ToString();
    //                employee.Department = rdr["Department"].ToString();
    //                employee.City = rdr["City"].ToString();
    //            }
    //        }
    //        return employee;
    //    }

    //    //To Delete the record on a particular employee  
    //    public void DeleteEmployee(int? id)
    //    {

    //        using (SqlConnection con = new SqlConnection(connectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
    //            cmd.CommandType = CommandType.StoredProcedure;

    //            cmd.Parameters.AddWithValue("@EmpId", id);

    //            con.Open();
    //            cmd.ExecuteNonQuery();
    //            con.Close();
    //        }
    //    }
    }
}
