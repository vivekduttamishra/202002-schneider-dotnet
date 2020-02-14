using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
   

    public delegate int BinaryOperator(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            int a = 50, b = 15;
            var am = new AdvancedMath();
            BinaryOperator[] operators =
            {
                SimpleMath.Plus,
                SimpleMath.Minus,
                am.Multiply,
                am.Divide
            };

            for(int i=0; i < operators.Length; i++)
            {
                var result = operators[i](a, b);
                var name = operators[i].Method.Name;

                Console.WriteLine("{0} {1} {2} = {3}",a,name,b, result);
            }

        }
    }
}
