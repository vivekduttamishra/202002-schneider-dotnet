using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApps01
{
    /*
     What does IOutputPresenter Represent?

        * there will be an object
        * of a class (name doesn't matter)
        * it will have method
                *    public
                *    non-static
                *    Present
        *  that will take an object and return nothing
     */
    public interface IOutputPresenter
    {
        void Present(object value);
    }

    public class SimpleConsolePresenter:IOutputPresenter
    {
        public void Present(Object value)
        {
            Console.WriteLine(value);
        }
    }

    public class ColoredConsolePresenter:IOutputPresenter
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
