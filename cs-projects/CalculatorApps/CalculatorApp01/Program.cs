using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp01
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
            var calc = SimpleCalculator();

            calc.Execute(2, plus, 10);
            calc.Execute(2, minus, 1);


        }
    }
}
