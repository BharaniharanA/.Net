using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4.product
{
    public class TabularReport:IReport
    {
        public void Generate()
        {
            Console.WriteLine("Tabular Report is Generated.....");
        }
        public void Generatefile()
        {
            string path = "tabular.txt";
            FileStream fs = new FileStream(path, FileMode.Create);
            Console.WriteLine($"Report is created in {path}");
        }
    }
}
