using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.MsTest
{
    //[TestClass]
    public class MathTest
    {
        [TestMethod]
        public void PlusTest()
        {   Math math = new Math();
            int x=10, y=5;
            int result = math.Plus(x,y);
            Assert.AreEqual(x + y, result);
        }

        [TestMethod]
        public void Test2()
        {
            Math math = new Math();
            int x = 10, y = 5;

            int result = math.Minus(x, y);
            //Console.WriteLine("Minus({0},{1})=>{2}", x, y, result);
            Assert.AreEqual(x - y, result);
        }

        [TestMethod]
        public void MultiplyTest()
        {
            Math math = new Math();
            int x = 10, y = 5;

            int result = math.Multiply(x, y);
            //Console.WriteLine("Multiply({0},{1})=>{2}", x, y, result);
            Assert.AreEqual(x * y, result);

        }

        [TestMethod]
        public void Test4()
        {
            Math math = new Math();
            int x = 10, y = 5;

            int result = math.Divide(x, y);
            //Console.WriteLine("Divide({0},{1})=>{2}", x, y, result);
            Assert.AreEqual(x / y, result);

        }

    }
}
