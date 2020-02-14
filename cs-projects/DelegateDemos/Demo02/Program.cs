using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    /*
     * It can contain a method that takes 2 int and returns an int
     * What it doesn't tell you
     *      What will be the method name? ---> It can be any name
     *      Which class method will belong? ---> It can belong to any class
     *      What will be the methods scope? ----> It can have any scope
    */

    public delegate int BinaryOperator(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            int a = 50, b = 15;

            BinaryOperator opr = SimpleMath.Plus; //public static function
            int result = opr(a, b);
            Console.WriteLine(result);

            opr = SimpleMath.Minus; //note same opr is reassigned
            result = opr(a, b);
            Console.WriteLine(result);

            var am = new AdvancedMath();
            opr = am.Multiply; //public non static method
            result = opr(a, b);
            Console.WriteLine(result);

            opr = am.getModDelegate(); //you got access to private method
            result = opr(a, b);
            Console.WriteLine(result);


        }
    }
}
