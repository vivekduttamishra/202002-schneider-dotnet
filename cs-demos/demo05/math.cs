public class Calculator
{
	public int Factorial(int x)
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