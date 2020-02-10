

class FactorialApp
{
	static void Main()
	{
		int n=5;
		int fn= Factorial(n);
		System.Console.WriteLine("Factorial of "+n+" is "+fn);
	}

	static int Factorial(int x)
	{
		int fx=1;
		while(x>1)
		{
			//fx*=x--;
			fx*=x;
			x=x-1;
		}

		return fx;
	}
}