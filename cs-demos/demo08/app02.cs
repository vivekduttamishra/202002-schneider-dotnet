class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        Furnitures.Chair chair1=new Furnitures.Chair();
        Furnitures.Chair chair2=new Furnitures.Chair();
        Furnitures.Bed bed1=new Furnitures.Bed();

        System.Console.WriteLine("{0}\tprice{1}\tid={2}",chair2, chair2.price, chair2.GetHashCode());
        System.Console.WriteLine("{0}\tprice{1}\tid={2}",chair1, chair1.price, chair1.GetHashCode());
        System.Console.WriteLine("{0}\tprice{1}\tid={2}",bed1, bed1.price, bed1.GetHashCode());

        Data.LinkedList list=new Data.LinkedList();
        Data.Set set=new Data.Set();

        list.Add(20);
        list.Add(30);
        set.Add(20);
        set.Add(30);

        Data.Table table=new Data.Table(); //which table?
        table.Add(2,3,4);
        //System.Console.WriteLine(table.price);


    }
}