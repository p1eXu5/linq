<Query Kind="Program" />

void Main()
{
	List<IEnumerable<int>> list = Enumerable.Range(2, 11).Select(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).Where(i => n % i > 0)).ToList();
	
	Console.WriteLine($"{list.Count}");
	
	int ind = 0;
	
	foreach (var item in list) {
	
		Console.WriteLine($"Простые числа {2 + ind++}");
		
		foreach (int numb in item)
			Console.WriteLine(numb);
	}
			
	int a = Enumerable.Range(2, 11).Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
	
	Console.WriteLine($"Количество - {a}");
}

// Define other methods and classes here
