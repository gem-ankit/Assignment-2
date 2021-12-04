using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Assignment2.Models
{
    public class UserDBcontext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<User> GetUsers()
        {
            List<User> UserList = new List<User>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User us = new User();
                us.id = Convert.ToInt32(dr.GetValue(0).ToString());
                us.FirstName = dr.GetValue(1).ToString();
                us.LastName = dr.GetValue(2).ToString();
                us.DoB = dr.GetValue(3).ToString();
                us.Gender = dr.GetValue(4).ToString();
                us.Email = dr.GetValue(5).ToString();
                UserList.Add(us);
            }
            con.Close();


            return UserList;
        }

        public bool AddUsers(User us)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", us.FirstName);
            cmd.Parameters.AddWithValue("@LastName", us.LastName);
            cmd.Parameters.AddWithValue("@DoB", us.DoB);
            cmd.Parameters.AddWithValue("@Gender", us.Gender);
            cmd.Parameters.AddWithValue("@Email", us.Email);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }

        public bool UpdateUsers(User us)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", us.id);
            cmd.Parameters.AddWithValue("@FirstName", us.FirstName);
            cmd.Parameters.AddWithValue("@LastName", us.LastName);
            cmd.Parameters.AddWithValue("@DoB", us.DoB);
            cmd.Parameters.AddWithValue("@Gender", us.Gender);
            cmd.Parameters.AddWithValue("@Email", us.Email);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }

        public bool DeleteUsers(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spDeleteUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }
    } 
}