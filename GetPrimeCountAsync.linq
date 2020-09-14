<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	//DisplayPrimeCounts();
	DisplayPrimeCount2();
}

// Define other methods and classes here


int GetPrimesCount (int start, int count)
{
	return ParallelEnumerable.Range (start, count).Count (n =>
		Enumerable.Range (2, (int)Math.Sqrt(n) - 1).All (i => n % i > 0));
}

Task<int> GetPrimesCountAsync (int start, int count)
{
	return Task.Run(() => ParallelEnumerable.Range (start, count).Count (n =>
		Enumerable.Range (2, (int)Math.Sqrt(n) - 1).All (i => n % i > 0)));
}

void DisplayPrimeCounts()
{
	DisplayPrimeCountFrom (0);
}

async void DisplayPrimeCount()
{
	int result = await GetPrimesCountAsync (2, (int)1e6);
	Console.WriteLine (result);
}

async void DisplayPrimeCount2()
{
	for (int i = 0; i < 10; ++i) 
		Console.WriteLine ("" + await GetPrimesCountAsync (i * (int)1e6 + 2, (int)1e6) + " " + i);
}


void DisplayPrimeCountFrom (int i)
{
	var awaiter = GetPrimesCountAsync (i * (int)1e6 + 2, (int)1e6).GetAwaiter();
	
	awaiter.OnCompleted (() =>
	{
		Console.WriteLine (awaiter.GetResult() + " primes between...");
		
		if (i++ < 10) 
			DisplayPrimeCountFrom (i);
		else
			Console.WriteLine ("Done");
	});
}