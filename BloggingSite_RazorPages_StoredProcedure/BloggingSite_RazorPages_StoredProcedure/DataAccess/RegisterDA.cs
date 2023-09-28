using BloggingSite_RazorPages_StoredProcedure.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingSite_RazorPages_StoredProcedure.DataAccess
{
    public class RegisterDA
    {
        string connectionString = "Data Source =.\\sqlexpress;Initial Catalog = BlogSiteRazorSP; Integrated Security = True";
        

        public void AddRegister(Register register)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", register.FirstName);
                cmd.Parameters.AddWithValue("@LastName", register.LastName);
                cmd.Parameters.AddWithValue("@Email", register.Email);
                cmd.Parameters.AddWithValue("@Password", register.Password);
                

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                
            }
        }

        public Register Login(Register register)
        {
            Register registerModel = new Register();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", register.Email);
                cmd.Parameters.AddWithValue("@Password", register.Password);

                var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    registerModel.Id = Convert.ToInt32(rdr["Id"]);
                    registerModel.FirstName = rdr["FirstName"].ToString();
                    registerModel.LastName = rdr["LastName "].ToString();
                    registerModel.Email = rdr["Email"].ToString();

                }
                con.Close();

            }
            return registerModel;
        }


        public IEnumerable<Register> GetAllProfiles()
        {
            List<Register> registers = new List<Register>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetAllProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Register register = new Register();

                    register.Id = Convert.ToInt32(dataReader["Id"]);
                    register.FirstName = dataReader["FirstName"].ToString();
                    register.LastName = dataReader["LastName"].ToString();
                    register.Email = dataReader["Email"].ToString();
                    
                    register.ToString();

                }
                con.Close();
            }
            return registers;
        }

        public Register GetRegData(int? id)
        {
            Register register = new Register();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                

                string sqlQuery = "SELECT * FROM [User] WHERE Id = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    register.Id = Convert.ToInt32(rdr["Id"]);
                    register.FirstName = rdr["FirstName"].ToString();
                    register.LastName = rdr["LastName "].ToString();
                    register.Email = rdr["Email"].ToString();

                }
            }
            return register;
        }

        public void UpdateRegister(Register register)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("UpdateReg", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", register.Id);
                cmd.Parameters.AddWithValue("@FirstName", register.FirstName);

                cmd.Parameters.AddWithValue("@LastName", register.LastName);
                cmd.Parameters.AddWithValue("@Email", register.Email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
