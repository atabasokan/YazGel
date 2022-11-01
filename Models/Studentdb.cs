using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;

namespace YazGel.Models
{
    public class Studentdb
    {

        SqlConnection con = new SqlConnection("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");
            
        public string SaveRevord (Student stn)
        {

            try
            {
                SqlCommand com = new SqlCommand("Sp_Student_Add", con);

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
    }
}
