class Program
{
    static void Main()
    {
        System.Console.WriteLine("Welcome to Furniture Shop");
        Chair chair1=new Chair();
        Chair chair2=new Chair();
        Bed bed1=new Bed();

        System.Console.WriteLine("{0}\tprice{1}\tid={2}",chair2, chair2.price, chair2.GetHashCode());
        System.Console.WriteLine("{0}\tprice{1}\tid={2}",chair1, chair1.price, chair1.GetHashCode());
        System.Console.WriteLine("{0}\tprice{1}\tid={2}",bed1, bed1.price, bed1.GetHashCode());

        LinkedList list=new LinkedList();
        Set set=new Set();

        list.Add(20);
        list.Add(30);
        set.Add(20);
        set.Add(30);

    
    }
}