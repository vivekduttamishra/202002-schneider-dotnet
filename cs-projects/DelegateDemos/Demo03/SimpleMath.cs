using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    public class SimpleMath
    {
        public static int Plus(int x, int y) { return x + y; }
        public static int Minus(int x, int y) { return x - y; }
    }

    public class AdvancedMath
    {
        public int Multiply(int x, int y) { return x * y; }
        public int Divide(int x, int y) { return x / y; }

        private  int Mod(int x, int y) { return x % y; }

        public BinaryOperator getModDelegate()
        {
            return new BinaryOperator(Mod);
        }
    }
}
