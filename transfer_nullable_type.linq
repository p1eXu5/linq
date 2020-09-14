<Query Kind="Program" />

void Main()
{
	TimeSpan? a = TimeSpan.FromSeconds(1);
	TimeSpan? b = a;
	
	a = null;
	
	b.Dump();
}

// Define other methods and classes here
