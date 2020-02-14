using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApps01
{
    public interface IOperator
    {
        int Calculate(int op1, int op2);
        
    }

    public class Plus : IOperator
    {
        public int Calculate(int op1, int op2)
        {
            return op1 + op2;
        }
    }

    public class Minus : IOperator
    {
        public int Calculate(int op1, int op2)
        {
            return op1 - op2;
        }
    }

    public class Multiply : IOperator
    {
        public int Calculate(int op1, int op2)
        {
            return op1 * op2;
        }
    }

    public class Divide : IOperator
    {
        public int Calculate(int op1, int op2)
        {
            return op1 / op2;
        }
    }
}
