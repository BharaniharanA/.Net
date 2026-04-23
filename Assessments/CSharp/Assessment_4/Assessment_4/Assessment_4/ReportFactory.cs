using Assessment_4.product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_4
{
    public class ReportFactory
    {
        public static void CreateReport(string type)
        {
            switch(type.ToUpper())
            {
                case "CHART":
                    ChartReport chartReport = new ChartReport();
                    chartReport.Generate();
                    chartReport.Generatefile();
                    break;
                case "TABULAR":
                    TabularReport tabularReport = new TabularReport();
                    tabularReport.Generate();
                    tabularReport.Generatefile();
                    break;
                case "SUMMARY":
                    SummaryReport summaryReport = new SummaryReport();
                    summaryReport.Generate();
                    summaryReport.Generatefile();
                    break;
                default:
                    Console.WriteLine("Invalid Report format...");
                    break;
            }
        }
    }
}
