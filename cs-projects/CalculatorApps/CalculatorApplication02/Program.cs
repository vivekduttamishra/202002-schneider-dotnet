using System;
using System.IO;

namespace CalculatorApps01
{
    class Program
    {
        /// <summary>
        /// Assignment
        /// 1. Execute should provide the output in format
        /// 2 plus 10 = 12
        /// 2 minus 1 = 1
        /// 
        /// Note:
        /// a. Execute returns nothing
        /// b. Second parameter can be any datatype of your choice
        /// c. should display calculated output
        /// d. should support atleast 4 basic operations + , - , * , /
        /// e. in future may support more operation like power, mod etc
        /// f. in future we may display the output on UI 
        /// g. in future we may print output differently like
        /// 
        /// plus(2,10) => 12
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var calc = new SimpleCalculator();
            calc.Formatter = ResultFormatters.Infix;
            calc.Presenter = OutputPresenters.SimpleConsole;


           // TestCalculator(calc);

            calc.Formatter = ResultFormatters.MethodStyle;
            //calc.Presenter = OutputPresenters.Colored(ConsoleColor.Blue);

            var writer = new StreamWriter(@"c:\temp\calc.txt");
            calc.Presenter = (output) =>
             {
                 writer.WriteLine(output);
                 writer.Flush();
             };

            //multicast delegate
            calc.Presenter+= OutputPresenters.Colored(ConsoleColor.Blue);
            calc.Presenter += OutputPresenters.SimpleConsole;

            //TestCalculator(calc);
            TestCustomOperators(calc);
        }

        static  void TestCalculator(SimpleCalculator calc)
        {
            calc.Execute(40, Operators.Plus, 20);
            calc.Execute(40, Operators.Minus, 20);
            calc.Execute(40, Operators.Multiply, 20);
            calc.Execute(40, Operators.Divide, 20);            
            Console.WriteLine();
        }

        static void TestCustomOperators(SimpleCalculator calc)
        {
            //approach 1. create a method and call it.
            calc.Execute(10, Custom, 5);

            //approach 2. c# 2.0 anonymous delegate concept <--- return type is detected based on delegate return type
            BinaryOperator factAByFactB = delegate (int i, int j)
             {
                 int fi = 1;
                 while (i > 1) fi *= i--;
                 int fj = 1;
                 while (j > 1) fj *= j--;
                 return fi / fj;
             };

            calc.Execute(5, factAByFactB, 3);

            BinaryOperator mod = delegate (int i, int j) { return i % j; };

            calc.Execute(30, mod, 8);

            //C# 3.0 simplified anonymous delegate
            //BinaryOperator factXByFactY =  (int i, int j) =>
            BinaryOperator factXByFactY = ( i,  j) =>
            {
                int fi = 1;
                while (i > 1) fi *= i--;
                int fj = 1;
                while (j > 1) fj *= j--;
                return fi / fj;
            };

            calc.Execute(5, factXByFactY, 3);

            //BinaryOperator mod2 = delegate (int i, int j) { return i % j; };
            //BinaryOperator mod2 =  ( i,  j) => { return i % j; };
            BinaryOperator mod2 = (i, j) =>   i % j  ;  //Lambda expression

            calc.Execute(30, mod2, 8);

            calc.Execute(5, (a, b) => a * a + b * b, 3);


        }


        public static int Custom(int op1, int op2)
        {
            return (op1 + op2) / (op1 - op2);
        }
        



    }
}
