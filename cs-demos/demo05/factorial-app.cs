

class FactorialApp
{
	static void Main()
	{
		int n=5;
		Calculator calc= new Calculator();
		int fn = calc.Factorial(n);
		System.Console.WriteLine("Factorial of {0} is {1}",n,fn);
	}
}

