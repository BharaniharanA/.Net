using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{

    public class TrainDAL
    {
        string conStr = "Data Source=ICS-LT-HD53YS3;Initial Catalog=TrainReservationDB;Integrated Security=True";

        public bool IsTrainExists(int trainNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Train WHERE TrainNo = @TrainNo AND IsDeleted = 0", con);

                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }

        public void GetStationsByTrain(int trainNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT tr.StationId, s.StationName, tr.StopOrder FROM TrainRoute tr
                JOIN Station s ON tr.StationId = s.StationId WHERE tr.TrainNo = @TrainNo
                ORDER BY tr.StopOrder", con);

                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine("\nStations for selected train:");
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["StationId"]} - {dr["StationName"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }

        public void GetAllStations()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("Select * from station", con);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["StationId"]} - {dr["StationName"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No stations found.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }
        }

        public void GetAvailableTrains()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("GetAvailableTrains", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        Console.WriteLine("\nAVAILABLE TRAINS");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("Train No | Train Name           | AC1 | AC3 | Sleeper");
                        Console.WriteLine("----------------------------------------------------------------");

                        while (dr.Read())
                        {

                            Console.WriteLine(
                                    $"{dr["TrainNo"],-8} | " +
                                    $"{dr["Name"],-20} | " +
                                    $"{dr["AC1_Available"],-3} | " +
                                    $"{dr["AC3_Available"],-3} | " +
                                    $"{dr["Sleeper_Available"],-7}"
                                );

                        }
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("Seat Availability shown as: AC1 / AC3 / Sleeper");
                        Console.WriteLine("Please Note the Train No to Book the ticket");
                    }
                    else
                    {
                        Console.WriteLine("No trains available.");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void SearchTrain(int from, int to)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("SearchTrainByRoute", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FromStation", from);
                    cmd.Parameters.AddWithValue("@ToStation", to);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        Console.WriteLine("\nAVAILABLE TRAINS FOR SELECTED ROUTE");
                        Console.WriteLine("--------------------------------------------------------------");
                        Console.WriteLine("Train No | Train Name           | AC1 | AC3 | Sleeper");
                        Console.WriteLine("--------------------------------------------------------------");

                        while (dr.Read())
                        {

                            Console.WriteLine($"{dr["TrainNo"],-8} | " + $"{dr["Name"],-20} | " 
                                + $"{dr["AC1_Available"],-3} | " +
                                $"{dr["AC3_Available"],-3} | " +
                                $"{dr["Sleeper_Available"],-7}");

                        }
                        Console.WriteLine("--------------------------------------------------------------");
                        Console.WriteLine("Please Note the Train No to Book the ticket");

                    }
                    else
                    {
                        Console.WriteLine("No trains found for the given route.");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void AddTrain(string role, int trainNo, string name, int ac1, int ac3, int sleeper, int total)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("AddTrain", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@AC1", ac1);
                    cmd.Parameters.AddWithValue("@AC3", ac3);
                    cmd.Parameters.AddWithValue("@Sleeper", sleeper);
                    cmd.Parameters.AddWithValue("@Total", total);

                    con.Open();
                    int v = cmd.ExecuteNonQuery();
                    if (v > 0)
                    {
                        Console.WriteLine("Train added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add train.");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void AddStation(string role, string name)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("AddStation", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@StationName", name);

                    con.Open();
                    int v = cmd.ExecuteNonQuery();
                    if (v > 0)
                    {
                        Console.WriteLine("Station added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add station.");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void AddRoute(string role, int trainNo, int stationId, int order, int distance, string arrTime, string depTime)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("AddTrainRoute", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);
                    cmd.Parameters.AddWithValue("@StationId", stationId);
                    cmd.Parameters.AddWithValue("@Order", order);
                    cmd.Parameters.AddWithValue("@Distance", distance);
                    cmd.Parameters.AddWithValue("@Arr", arrTime);
                    cmd.Parameters.AddWithValue("@Dep", depTime);

                    con.Open();
                    int v = cmd.ExecuteNonQuery();
                    if (v > 0)
                    {
                        Console.WriteLine("Route added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to add route.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void DeleteTrain(string role, int trainNo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("SoftDeleteTrain", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@TrainNo", trainNo);

                    con.Open();
                    int v = cmd.ExecuteNonQuery();
                    if (v > 0)
                    {
                        Console.WriteLine("Train deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete train.");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }

        public void GetAllData(string role)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("GetAllData", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Role", role);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        Console.WriteLine($"\n===================================================");

                        DataTable dt = ds.Tables[i];

                        // Print column names
                        foreach (DataColumn col in dt.Columns)
                        {
                            Console.Write(col.ColumnName + "\t");
                        }

                        Console.WriteLine();

                        // Print rows
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                Console.Write(item + "\t");
                            }

                            Console.WriteLine();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("error: " + ex.Message);
            }

        }
    }
}
