using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1_ADO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            display();
            InsertEmp();
            display();
        }

        public static void InsertEmp()
        {
            Console.Write("Enter your name:");
            string name= Console.ReadLine();
            Console.Write("Enter your sal:");
            decimal sal = decimal.Parse(Console.ReadLine());
            Console.Write("Enter your Employee type:");
            string type = Console.ReadLine();
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-HD53YS3;Initial Catalog=Employeemanagement;Integrated Security=True;");


            SqlCommand cmd = new SqlCommand("sp_InsertEmp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // Input parameters
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Sal", sal);
            cmd.Parameters.AddWithValue("@type", type);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Console.WriteLine("Employee Inserted Successfully");

        }
        static void display()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-HD53YS3;Initial Catalog=Employeemanagement;Integrated Security=True;");


            SqlCommand cmd = new SqlCommand("SELECT * FROM Employee_Details", con);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(
                    dr["Empno"] + " " +
                    dr["EmpName"] + " " +
                    dr["Empsal"] + " " +
                    dr["Emptype"]);
            }

            con.Close();

        }
    }
}
