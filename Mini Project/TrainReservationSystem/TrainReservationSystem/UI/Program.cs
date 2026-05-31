using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainReservationSystem.BAL;
using TrainReservationSystem.DAL;

namespace TrainReservationSystem.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartApplication();
        }

        // Start of the application
        static void StartApplication()
        {

            UserBAL userBal = new UserBAL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=========================================");
                Console.WriteLine("     TRAIN RESERVATION SYSTEM");
                Console.WriteLine("=========================================");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("0. Exit");


                Console.Write("Choose: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.Write("Enter any key to Continue......");
                    Console.ReadKey();
                    continue;
                }

                //  LOGIN
                if (choice == 1)
                {
                    try
                    {
                        Console.Write("Username: ");
                        string user = Console.ReadLine();

                        Console.Write("Password: ");
                        string pass = Console.ReadLine();

                        string role = userBal.Login(user, pass);

                        if (role == null)
                        {
                            Console.WriteLine("Invalid Login,Please check username or password");
                            Console.Write("Enter any key to Continue......");
                            Console.ReadKey();
                        }
                        else if (role == "Admin")
                        {
                            AdminMenu();
                        }
                        else
                        {
                            UserMenu();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.Write("Enter any key to Continue......");
                        Console.ReadKey();
                    }
                }

                //  REGISTER
                else if (choice == 2)
                {
                    try
                    {
                        Console.Write("Username: ");
                        string user = Console.ReadLine();

                        Console.Write("Password: ");
                        string pass = Console.ReadLine();

                       int i= userBal.AddUser(user, pass);
                        if (i == 0)
                        {
                            Console.WriteLine("Registration Failed!");
                        }
                        else
                        {

                            Console.WriteLine("Registered Successfully!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    Console.Write("Enter any key to Continue......");
                    Console.ReadKey();
                }

                else if (choice == 0)
                {
                    return; 
                }

            }
        }

        // USER MENU
        static void UserMenu()
        {
            TrainBAL trainBal = new TrainBAL();
            BookingBAL bookingBal = new BookingBAL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- USER MENU ---");
                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Search Train");
                Console.WriteLine("3. Book Ticket");
                Console.WriteLine("4. Cancel Ticket");
                Console.WriteLine("0. Logout");

                Console.Write("Choose: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.Write("Enter any key to Continue......");
                    Console.ReadKey();

                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            trainBal.GetAvailableTrains();
                            break;

                        case 2:
                            Console.WriteLine("Available stations:");
                            trainBal.GetallStations();
                            Console.Write("From StationId: ");
                            int from = int.Parse(Console.ReadLine());

                            Console.Write("To StationId: ");
                            int to = int.Parse(Console.ReadLine());

                            trainBal.SearchTrain(from, to);
                            break;

                        case 3:
                            Console.Write("Train No: ");
                            int t = int.Parse(Console.ReadLine());

                            if (!trainBal.IsTrainExists(t))
                            {
                                Console.WriteLine(" Invalid Train Number. Please select a valid train.");
                                Console.Write("Enter any key to Continue......");
                                Console.ReadKey();
                                continue;
                            }

                            trainBal.GetStationsByTrain(t);

                            Console.Write("From: ");
                            int f = int.Parse(Console.ReadLine());

                            Console.Write("To: ");
                            int tt = int.Parse(Console.ReadLine());

                            Console.Write("Passengers: ");
                            int count = int.Parse(Console.ReadLine());

                            bookingBal.BookTicket(t, f, tt, count);
                            break;

                        case 4:
                            Console.Write("Passenger Id: ");
                            int pid = int.Parse(Console.ReadLine());

                            bookingBal.CancelTicket(pid);
                            break;

                        case 0:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.Write("Enter any key to Continue......");
                Console.ReadKey();

            }
        }

        // ADMIN MENU
        static void AdminMenu()
        {
            TrainBAL trainBal = new TrainBAL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- ADMIN MENU ---");
                Console.WriteLine("1. Add Train");
                Console.WriteLine("2. Add Station");
                Console.WriteLine("3. Add Route");
                Console.WriteLine("4. Delete Train");
                Console.WriteLine("5. View All Data");
                Console.WriteLine("6. User Menu");
                Console.WriteLine("0. Logout");

                Console.Write("Choose: ");
                int choice;

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    Console.Write("Enter any key to Continue......");
                    Console.ReadKey();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Train No: ");
                            int no = int.Parse(Console.ReadLine());

                            Console.Write("Name: ");
                            string name = Console.ReadLine();

                            Console.Write("AC1: ");
                            int a1 = int.Parse(Console.ReadLine());

                            Console.Write("AC3: ");
                            int a3 = int.Parse(Console.ReadLine());

                            Console.Write("Sleeper: ");
                            int sl = int.Parse(Console.ReadLine());

                            int tot = a1+a3 + sl;
                            Console.Write($"Total: {tot} ");

                            trainBal.AddTrain(no, name, a1, a3, sl, tot);
                            break;

                        case 2:
                            Console.Write("Station Name: ");
                            string s = Console.ReadLine();

                            trainBal.AddStation(s);
                            break;

                        case 3:
                            Console.Write("Train No: ");
                            int tn = int.Parse(Console.ReadLine());

                            Console.Write("Station ID: ");
                            int sid = int.Parse(Console.ReadLine());

                            Console.Write("Order: ");
                            int order = int.Parse(Console.ReadLine());

                            Console.Write("Distance: ");
                            int dist = int.Parse(Console.ReadLine());

                            Console.Write("Arrival Time: ");
                            string arrTime = Console.ReadLine();

                            Console.Write("Departure Time: ");
                            string depTime = Console.ReadLine();

                            trainBal.AddRoute(tn, sid, order, dist, arrTime, depTime);
                            break;

                        case 4:
                            Console.Write("Train No: ");
                            int d = int.Parse(Console.ReadLine());

                            trainBal.DeleteTrain(d);
                            break;

                        case 5:
                            trainBal.GetAllData();
                            break;
                        case 6:
                            UserMenu();
                            break;

                        case 0:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.Write("Enter any key to Continue......");
                Console.ReadKey();

            }

        }

    }
}

