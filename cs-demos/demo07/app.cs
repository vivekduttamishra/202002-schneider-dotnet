using System;   //import System.*;
using Furnitures;
using Data;
using Table=Furnitures.Table; //import Furntiures.Table;

using DTable= Data.Table ; //DTable is an alias for Data.Table

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

        list.Add(20);
        list.Add(30);
        set.Add(20);
        set.Add(30);

        DTable table1=new DTable(); //which table?
        table1.Add(2,3,4);

        Table table2=new Table();
        Console.WriteLine(table2.price);

        Search search=new Search();
        Console.WriteLine(search);


    }
}