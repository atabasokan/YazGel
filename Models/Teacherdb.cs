using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace YazGel.Models
{
    public class Teacherdb
    {
        SqlConnection con = new SqlConnection("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");


        public string UpdatePassword(ChangePass tch)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update_Pass_T", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@New_Pass", tch.NewPass);
                com.Parameters.AddWithValue("@Id", tch.Id);
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
        public string UpdatePasswordCom(ChangePass tch)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update_Pass_C", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@NewPass", tch.NewPass);
                com.Parameters.AddWithValue("@Id", tch.Id);
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
