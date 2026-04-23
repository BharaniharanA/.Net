using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4.product
{
    public class ChartReport:IReport
    {
        public void Generate()
        {
            Console.WriteLine("Chart Report is Generated.....");
        }
        public void Generatefile()
        {
            string path="chart.txt";
            FileStream fs = new FileStream(path, FileMode.Create);
            Console.WriteLine($"Report is created in {path}");
        }
    }
}
