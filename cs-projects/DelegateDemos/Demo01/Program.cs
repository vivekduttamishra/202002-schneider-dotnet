using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01
{
    delegate int BinaryOperator(int x, int y); 
    /*
     class BinaryOperator : MulticastDelegate
     {
        ...
        public int Invoke(int x,int y){ ...}
     }
     */
    class Program
    {
        static void Main(string[] args)
        {
            int a = 50, b = 15;

            //use standard approach
            int result = Plus(a, b);
            Console.WriteLine(result);

            //create a delegate object for Plus Function
            BinaryOperator add = new BinaryOperator(Plus);
            result = add.Invoke(a, b);
            Console.WriteLine(result);

            //c# 2.0 introduced two delegate features
            //feature 1: autoboxed delegates
            BinaryOperator sub = Minus;  //new PlusDelegate(Minus)
            result = sub(a, b);         //internally expands to sub.Invoke(a,b)
            Console.WriteLine(result);

        }
        static int Plus(int x,int y) { return x + y; }

        static int Minus(int x, int y) { return x - y; }
    }
}
