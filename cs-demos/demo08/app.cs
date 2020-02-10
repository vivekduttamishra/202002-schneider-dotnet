using System;   //import System.*;
using ConceptArchitect.Furnitures;
using ConceptArchitect.Data;
using Table=ConceptArchitect.Furnitures.Table; //import Furntiures.Table;
using Set=Schneider.Data.Set;
using Schneider.Data;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Furniture Shop");
        Chair chair1=new Chair();
        Chair chair2=new Chair();
        Bed bed1=new Bed();

        Console.WriteLine("{0}\tprice{1}\tid={2}",chair2, chair2.price, chair2.GetHashCode());
        Console.WriteLine("{0}\tprice{1}\tid={2}",chair1, chair1.price, chair1.GetHashCode());
        Console.WriteLine("{0}\tprice{1}\tid={2}",bed1, bed1.price, bed1.GetHashCode());

        LinkedList list=new LinkedList();
        Set set=new Set();
        Console.WriteLine(set);

        list.Add(20);
        list.Add(30);
        //set.Add(20);
        //set.Add(30);

        ConceptArchitect.Data.Table table1=new ConceptArchitect.Data.Table(); //which table?
        table1.Add(2,3,4);

        Table table2=new Table();
        Console.WriteLine(table2.price);

        Search search=new Search();
        Console.WriteLine(search);


    }
}