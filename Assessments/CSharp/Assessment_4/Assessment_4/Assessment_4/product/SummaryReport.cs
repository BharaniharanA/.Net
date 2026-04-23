using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4.product
{
    public class SummaryReport:IReport
    {
        public void Generate()
        {
            Console.WriteLine("Summary Report is Generated.....");
        }

        public void Generatefile()
        {
            string path = "summary.txt";
            FileStream fs = new FileStream(path, FileMode.Create);
            Console.WriteLine($"Report is created in {path}");
        }
    }
}
