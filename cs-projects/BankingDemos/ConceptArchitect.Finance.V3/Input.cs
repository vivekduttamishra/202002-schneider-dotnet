using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.V2
{
    public class Input
    {
        public string GetString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int GetInt(string prompt)
        {
            return int.Parse(GetString(prompt));
        }

        public double GetDouble(string prompt)
        {
            return double.Parse(GetString(prompt));
        }
    }
}
