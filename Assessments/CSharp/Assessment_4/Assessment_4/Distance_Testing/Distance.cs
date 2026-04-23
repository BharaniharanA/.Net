using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance_Testing
{
    public class Distance
    {
        public int kilometer {  get; set; }


        public static Distance Add(Distance d1, Distance d2)
        {
            Distance d3 = new Distance();
            d3.kilometer = d1.kilometer + d2.kilometer;
            return d3 ;
        }
        

        public static int Display(Distance d)
        {
            return d.kilometer;
        }
    }
}
