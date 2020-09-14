<Query Kind="Program" />

void Main()
{
	var a = new[] { 1, 2, 3 };
	var b = new[] { 1, 2, 3 };
	var c = new[] { 3, 2, 1 };
	
	(a == b).Dump();
	(a.Equals(b)).Dump();
	(a.SequenceEqual(b)).Dump();
	(a.SequenceEqual(c)).Dump();
}

// Define other methods and classes here
