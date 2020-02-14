using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApps01
{
    
   /*
     * what does delegate represent
     * 
     *  there will be an object
     *  of a class (name doesn't matter)
     *  it will have method
     *      * scope ---> any
     *      * static/non static
     *      * method name --> doesn't matter
     *     *  that will take an object and return nothing 
     */
    public delegate void OutputPresenter(object value);



    public class OutputPresenters
    {
        public static void SimpleConsole(Object value)
        {
            Console.WriteLine(value);
        }
        public static OutputPresenter Colored(ConsoleColor color)
        {
            return new ColoredConsolePresenter(color).Present;
        }
    }

    public class ColoredConsolePresenter
    {
        ConsoleColor color;
        public ColoredConsolePresenter(ConsoleColor color)
        {
            this.color = color;
        }
        public void Present(Object value)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }
    }
}
