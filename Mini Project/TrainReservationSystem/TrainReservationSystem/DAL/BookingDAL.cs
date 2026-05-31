using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservationSystem.DAL
{
    public class BookingDAL
    {
        string conStr = "Data Source=ICS-LT-HD53YS3;Initial Catalog=TrainReservationDB;Integrated Security=True";


        public void BookTicket(int trainNo, int from, int to, int count)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    decimal totalAmount = 0;
                    List<string> passengerNames = new List<string>();
                    List<string> passengerClasses = new List<string>();
                    List<decimal> passengerFares = new List<decimal>();

                    // 1. PASSENGER INPUT & FARE CALCULATION

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"\nPassenger {i + 1}");

                        Console.Write("Name: ");
                        string pname = Console.ReadLine();

                        Console.Write("Class (AC1/AC3/Sleeper): ");
                        string cls = Console.ReadLine();
                    

                        SqlCommand fareCmd = new SqlCommand("CalculateFare", con);
                        fareCmd.CommandType = CommandType.StoredProcedure;
                        fareCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        fareCmd.Parameters.AddWithValue("@FromStation", from);
                        fareCmd.Parameters.AddWithValue("@ToStation", to);
                        fareCmd.Parameters.AddWithValue("@Class", cls);

                        decimal fare = Convert.ToDecimal(fareCmd.ExecuteScalar());

                        Console.WriteLine("Fare: " + fare);

                        totalAmount += fare;
                        passengerNames.Add(pname);
                        passengerClasses.Add(cls);
                        passengerFares.Add(fare);
                    }

                    Console.WriteLine("\nTotal Amount: " + totalAmount);

                    // 2. CREATE BOOKING

                    SqlCommand bookCmd = new SqlCommand("CreateBooking", con);
                    
                        bookCmd.CommandType = CommandType.StoredProcedure;
                        bookCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        bookCmd.Parameters.AddWithValue("@FromStation", from);
                        bookCmd.Parameters.AddWithValue("@ToStation", to);
                        bookCmd.Parameters.AddWithValue("@Amount", totalAmount);

                        int bookingId = Convert.ToInt32(bookCmd.ExecuteScalar());
                    
                    // 3. ADD PASSENGERS + UPDATE SEATS

                    for (int j = 0; j < count; j++)
                    {
                        // Add Passenger
                        SqlCommand passCmd = new SqlCommand("AddPassengers", con);
                        passCmd.CommandType = CommandType.StoredProcedure;
                        passCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        passCmd.Parameters.AddWithValue("@Name", passengerNames[j]);
                        passCmd.Parameters.AddWithValue("@Class", passengerClasses[j]);
                        passCmd.Parameters.AddWithValue("@Price", passengerFares[j]);
                        passCmd.ExecuteNonQuery();

                        // Update Seat Availability
                        SqlCommand seatCmd = new SqlCommand("UpdateSeatOnBooking", con);
                        seatCmd.CommandType = CommandType.StoredProcedure;
                        seatCmd.Parameters.AddWithValue("@TrainNo", trainNo);
                        seatCmd.Parameters.AddWithValue("@Class", passengerClasses[j]);
                        seatCmd.ExecuteNonQuery();
                    }

                    //calling payment making
                    MakePayment(bookingId);


                    Console.WriteLine("\n Booking Successful");
                    GetBookingDetails(bookingId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }
        }

        private void MakePayment(int bookingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    Console.Write("\nPayment Type (CASH/UPI): ");
                    string paymentType = Console.ReadLine();

                    SqlCommand getPassCmd = new SqlCommand(
                        "SELECT PassengerId, SeatNo,Price FROM PassengerDetails WHERE BookingId = @BookingId", con);
                    getPassCmd.Parameters.AddWithValue("@BookingId", bookingId);

                    SqlDataReader dr = getPassCmd.ExecuteReader();

                    List<int> passengerIds = new List<int>();
                    List<string> seatNos = new List<string>();
                    List<decimal> fares = new List<decimal>();

                    while (dr.Read())
                    {
                        passengerIds.Add(Convert.ToInt32(dr["PassengerId"]));
                        seatNos.Add(dr["SeatNo"].ToString());
                        fares.Add(Convert.ToDecimal(dr["Price"]));
                    }
                    dr.Close();

                    for (int i = 0; i < passengerIds.Count; i++)
                    {
                        SqlCommand payCmd = new SqlCommand("MakePayment", con);
                        payCmd.CommandType = CommandType.StoredProcedure;
                        payCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        payCmd.Parameters.AddWithValue("@PassengerId", passengerIds[i]);
                        payCmd.Parameters.AddWithValue("@SeatNo", seatNos[i]);
                        payCmd.Parameters.AddWithValue("@Type", paymentType);
                        payCmd.Parameters.AddWithValue("@Amount", fares[i]);

                        payCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" error: " + ex.Message);
            }
        }
        public void CancelTicket(int passengerId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("CancelPassenger", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PassengerId", passengerId);

                    con.Open();
                    int v = cmd.ExecuteNonQuery();
                    if (v > 0)
                    {
                        Console.WriteLine("Cancelled Successfully");
                        // CALL REFUND
                        SqlCommand refundCmd = new SqlCommand("ProcessRefund", con);
                        refundCmd.CommandType = CommandType.StoredProcedure;

                        refundCmd.Parameters.AddWithValue("@PassengerId", passengerId);

                        refundCmd.ExecuteNonQuery();

                        Console.WriteLine("Refund Processed");
                    }
                    else
                    {
                        Console.WriteLine("Cancellation Failed");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }

        }

        public void GetBookingDetails(int bookingId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("GetBookingFullDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@BookingId", bookingId);

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        Console.WriteLine("Booking Details:");


                        while (dr.Read())
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine("Booking ID : " + dr["BookingId"]);
                            Console.WriteLine("Train Name : " + dr["Name"]);
                            Console.WriteLine("Passenger ID : " + dr["PassengerId"]);
                            Console.WriteLine("Passenger  : " + dr["PassengerName"]);
                            Console.WriteLine("Class      : " + dr["Class"]);
                            Console.WriteLine("Seat No    : " + dr["SeatNo"]);
                            Console.WriteLine("Price      : " + dr["Price"]);
                            Console.WriteLine("--------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Booking Found");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Database error: " + ex.Message);
            }

        }
    }

}
