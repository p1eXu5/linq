<Query Kind="Program" />

void Main()
{
	Foo foo = new Foo();
	StringBuilder str = new StringBuilder();
	Enumerable.Repeat("=", 20).ToList().ForEach(p => str.Append(p));
	str.ToString().Dump();
	
	int[] i = { 1, 2, 3, 4, 5 };
	
	foo = new Foo(i);
}

// Define other methods and classes here
class Foo
{
	public static string DefaultName = "Default";

	public string Name;
	public List<int> I;
	
	public Foo()
		:this(DefaultName)
	{ "Second".Dump(); }
	
	public Foo(string str)
	{
		"First".Dump();
	
		Name = str;
		
		I = new List<int>();
	}
	
	public Foo(IEnumerable<int> arr)
		:this(DefaultName)
	{
		"Second".Dump();
	
		foreach (var i in arr)
		{
			I.Add(i);
		}
	}
}