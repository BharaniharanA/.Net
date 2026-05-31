using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{

    public class UserDAL
    {
        string conStr = "Data Source=ICS-LT-HD53YS3;Initial Catalog=TrainReservationDB;Integrated Security=True";

        public string Login(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("UserLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    var result = cmd.ExecuteScalar();

                    return result == null ? null : result.ToString();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }

        }

        public int AddUser(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(" error: " + ex.Message);
            }

        }
    }
}
