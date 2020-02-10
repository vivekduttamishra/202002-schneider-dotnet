using ConceptArchitect.Data;
using ConceptArchitect.Furnitures;
using Schneider.Data;
using System;

namespace FurnitureApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Bed bed = new Bed();
            Console.WriteLine(bed);

            Chair chair = new Chair();
            Console.WriteLine(chair);

            Search search = new Search();
            Console.WriteLine(search);

            List list = new List();
            Console.WriteLine(list);


        }
    }
}
