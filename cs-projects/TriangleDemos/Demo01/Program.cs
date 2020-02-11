using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle t1 = new Triangle(3,4,5);
            //t1.Set(3, 4, 5);  // it is verified valid
            TestTriangle(t1);

            Triangle t2 = new Triangle(3,6,12);
            
            //t2.Set(3, 6, 12);
            TestTriangle(t2);



            //t1.s3 = 100;     //now its invalid, but Triangle doesn't know it has become invalid
            t1.Set(3, 4, 100);  //now system knows this new combination is invalid
            
            TestTriangle(t1);

            Triangle t3 = new Triangle();
            //sides are not set?
            TestTriangle(t3);

        }
        private static void TestTriangle(Triangle t1)
        {
            if (t1.IsValid())
            {
                t1.Draw();
                Console.WriteLine("Perimeter is " + t1.Perimeter());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Not a Valid Triangle");
            }
        }
    }
}
