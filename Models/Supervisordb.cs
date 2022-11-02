using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace YazGel.Models
{
    public class Supervisordb
    {
        SqlConnection con = new SqlConnection("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");


        public string UpdatePassword(ChangePass sv)
        {
            try
            {
                SqlCommand com = new SqlCommand("Update_Pass_Sv", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@NewPass", sv.NewPass);
                com.Parameters.AddWithValue("@Id", sv.Id);
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
