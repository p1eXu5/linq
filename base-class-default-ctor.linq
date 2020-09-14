<Query Kind="Program" />

void Main()
{
	var c = new Foo();
	Environment.NewLine.Dump();
	var b = new Baz( "param" );
}

// Define other methods, classes and namespaces here
public abstract class Base
{
	protected Base()
	{
		"Base".Dump();
	}
}

public class Foo : Base
{
	public Foo()
	{
		"Foo".Dump();
	}
}

public class Baz : Base
{
	public Baz()
	{
		"Baz less".Dump();
	}
	
	public Baz( string parameter ) : this()
	{
		"Baz".Dump();
	}
}