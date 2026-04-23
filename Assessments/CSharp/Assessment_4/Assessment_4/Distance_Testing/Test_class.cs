using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Distance_Testing
{
    [TestFixture]
    public class Test_class
    {
        Distance d1,d2,d3;

        [SetUp]
        public void ObjInstance()
        {
            d1 = new Distance();
            d2 = new Distance();
            d3 = new Distance();
        }

        [Test]
        [TestCase(10,20,30)]
        [TestCase(50,20,70)]
        [TestCase(0,20,20)]
        [TestCase(5,11,16)]
        public void Testing_Add_Correct (int a,int b,int expected)
        {
            d1.kilometer= a; 
            d2.kilometer= b;
            d3 = Distance.Add(d1, d2);
            ClassicAssert.AreEqual(expected,d3.kilometer);
        }

        [Test]
        [TestCase(10, 20, 40)]
        [TestCase(50, 20, 60)]
        [TestCase(0, 20, 100)]
        [TestCase(5, 11, 20)]
        public void Testing_Add_Incorrect(int a, int b, int expected)
        {
            d1.kilometer = a;
            d2.kilometer = b;
            d3 = Distance.Add(d1, d2);
            ClassicAssert.AreNotEqual(expected, d3.kilometer);
        }

        [Test]
        [TestCase(10,10)]
        [TestCase(20,20)]
        [TestCase(30,30)]
        [TestCase(100,100)]

        public void Testing_Display(int a,int expected)
        {
            Distance d = new Distance();
            d.kilometer = a;
            ClassicAssert.AreEqual(d.kilometer,expected);
        }
    }
}
