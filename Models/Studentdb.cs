using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;

namespace YazGel.Models
{
    public class Studentdb
    {

        SqlConnection con = new SqlConnection("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");
            
        public string SaveRecord (Student stn)
        {

            try
            {
                SqlCommand com = new SqlCommand("Student_Add", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", stn.Name);
                com.Parameters.AddWithValue("@Surname", stn.Surname);
                com.Parameters.AddWithValue("@No", stn.No);
                com.Parameters.AddWithValue("@Pass", stn.Pass);
                com.Parameters.AddWithValue("@Gender", stn.Gender);
                com.Parameters.AddWithValue("@Role", "4");
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("Ok");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }

        public string UpdatePassword (ChangePass stn)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update_Pass_Student", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@NewPass", stn.NewPass);
                com.Parameters.AddWithValue("@StudentId", stn.studentId);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("Ok");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
        public string CreateInternship (Internship intern)
        {
            try
            {
                SqlCommand com = new SqlCommand("Internship_Create", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", intern.Name);
                com.Parameters.AddWithValue("@Surname", intern.Surname);
                com.Parameters.AddWithValue("@TC", intern.TC);
                com.Parameters.AddWithValue("@PhoneNumber", intern.PhoneNumber);
                com.Parameters.AddWithValue("@Mail", intern.Mail);
                com.Parameters.AddWithValue("@Address", intern.Address);
                com.Parameters.AddWithValue("@Start", intern.Start);
                com.Parameters.AddWithValue("@EndDate", intern.EndDate);
                com.Parameters.AddWithValue("@SSK", intern.SSK);
                com.Parameters.AddWithValue("@GSS", intern.GSS);
                com.Parameters.AddWithValue("@Age", intern.Age);
                com.Parameters.AddWithValue("@Gov", intern.Gov);
                com.Parameters.AddWithValue("@ComName", intern.ComName);
                com.Parameters.AddWithValue("@ComBuss", intern.ComBuss);
                com.Parameters.AddWithValue("@ComAddress", intern.ComAddress);
                com.Parameters.AddWithValue("@ComPhoneNumber", intern.ComPhoneNumber);
                com.Parameters.AddWithValue("@ComMail", intern.ComMail);
                com.Parameters.AddWithValue("@ComAdmin", intern.ComAdmin);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                return ("Ok");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}
