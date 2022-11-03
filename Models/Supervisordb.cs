using Microsoft.Data.SqlClient;
using System.Data;
using System;

namespace YazGel.Models
{
    public class Supervisordb
    {
        SqlConnection con = new SqlConnection("server=yazgelkou.mssql.somee.com;database=yazgelkou; User Id=teyavuz_SQLLogin_1; Password=2tyf4vqku5; integrated security=false;");


        public string UpdatePasswordSv(ChangePass sv)
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
        public string SaveRecord(Teacher tch)
        {

            try
            {
                SqlCommand com = new SqlCommand("Add_NewTeacher", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", tch.Name);
                com.Parameters.AddWithValue("@Surname", tch.Surname);
                com.Parameters.AddWithValue("@No", tch.No);
                com.Parameters.AddWithValue("@Pass", tch.Pass);
                com.Parameters.AddWithValue("@Gender", tch.Gender);
                com.Parameters.AddWithValue("@Role", "3");
                com.Parameters.AddWithValue("@Type",tch.Type);
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
        public string DeleteSupervisor(Supervisor sv)
        {

            try
            {
                SqlCommand com = new SqlCommand("Delete_Supervisors", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id", sv.Id);
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
        public string DeleteTeacher(Teacher tch)
        {

            try
            {
                SqlCommand com = new SqlCommand("Delete_Teacher", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id", tch.Id);
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
        public string DeleteStudent(Student st)
        {

            try
            {
                SqlCommand com = new SqlCommand("Delete_Student", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id",st.Id);
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
        public string EditTeacher(Teacher tch)
        {
            try
            {
                SqlCommand com = new SqlCommand("Edit_Teacher", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", tch.Name);
                com.Parameters.AddWithValue("@Surname", tch.Surname);
                com.Parameters.AddWithValue("@No", tch.No);
                com.Parameters.AddWithValue("@Pass", tch.Pass);
                com.Parameters.AddWithValue("@Gender", tch.Gender);
                com.Parameters.AddWithValue("@Type", tch.Type);
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
        public string SaveSupervisor(Supervisor sv)
        {

            try
            {
                SqlCommand com = new SqlCommand("Add_NewSupervisor", con);

                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Name", sv.Name);
                com.Parameters.AddWithValue("@Surname", sv.Surname);
                com.Parameters.AddWithValue("@No", sv.No);
                com.Parameters.AddWithValue("@Pass", sv.Pass);
                com.Parameters.AddWithValue("@Gender", sv.Gender);
                com.Parameters.AddWithValue("@Role", sv.role);
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
