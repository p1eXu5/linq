<Query Kind="Program" />

void Main()
{
	HashSet<string> set = new HashSet<string>();
	string[] arr = new string[1000];
	
	for (int i = 0; i < 1000; ++i) {
		arr[i] = ".ex" + i.ToString();
		set.Add(".ex" + i.ToString());
	}
	
	Random rnd = new Random(DateTime.Now.TimeOfDay.Milliseconds);
	int k = 0;
	
	Stopwatch sp = Stopwatch.StartNew();
	
	for (int i = 0; i < 1000; ++i) {
		if (set.Contains(".ex" + rnd.Next(1000))) ++k;
	}
	
	$"HashSet (1000 times  occurrence of): {sp.Elapsed, -20}".Dump();
	
	sp = Stopwatch.StartNew();
	
	for (int i = 0; i < 1000; ++i) {
		if (arr.Contains(".ex" + rnd.Next(1000))) ++k;
	}
	
	Console.WriteLine($"Array (1000 times  occurrence of):     {sp.Elapsed, -20}");
}

// Define other methods and classes here
