<Query Kind="Program" />

void Main()
{
	var dict = new Dictionary<int,Action>();
	for( int i = 0; i < 10; ++i )
	{
		var n = i;
		dict[i] = () => Foo(n);
	}
	
	for( int i = 0; i < 10; ++i )
	{
		dict[i]();
	}
	
	"".Dump();
	
	var dict3 = new Dictionary<int,Action>();
	foreach( var n in Enumerable.Range(0, 10) )
	{
		dict3[n] = () => Foo(n);
	}
	
	for( int i = 0; i < 10; ++i )
	{
		dict3[i]();
	}
	
	"".Dump();
	
	var k = 0;
	var dict2 = new Dictionary<int,Action>();
	foreach( var ch in "abc" )
	{
		dict2[k++] = () => ch.Dump();
	}
	
	for( int i = 0; i < dict2.Count; ++i )
	{
		dict2[i]();
	}
}

// Define other methods and classes here
public void Foo( int i )
{
	i.Dump();
}