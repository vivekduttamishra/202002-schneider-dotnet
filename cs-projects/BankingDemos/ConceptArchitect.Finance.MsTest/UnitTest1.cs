using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConceptArchitect.Finance.MsTest
{
   // [TestClass]
    public class UnitTest1
    {
        [TestMethod] //@TestMethod
        public void TestMethod1()
        {
            Console.WriteLine("Hi, Welcome to Test");
        }

        [TestMethod] //@TestMethod
        public void TestMethod2()
        {
            Console.WriteLine("Hi, Welcome to Test 2");
        }

        [TestMethod] //@TestMethod
        public void IAmNotATest()
        {
            Console.WriteLine("Hi, I am not  a Test");
        }

        public void Test4()
        {
            Console.WriteLine("I am the Test 4");
        }
    }
}
