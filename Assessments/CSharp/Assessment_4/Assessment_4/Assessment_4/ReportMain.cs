using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4
{
    public class ReportMain
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter report type (chart/tabular/summary):");
            string input = Console.ReadLine();
            ReportFactory.CreateReport(input);
        }
    }
}
