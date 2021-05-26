<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var f1 = Foo.One;
	f1.Is( Foo.Two ).Dump();
	f1 |= Foo.Two;
	f1.Is( Foo.Two ).Dump();
	
	Foo fx = (Foo)16;
	fx.Is( Foo.Two ).Dump();
	
	Enum.IsDefined(typeof(Foo), Foo.One | Foo.Two).Dump();
}

// Define other methods, classes and namespaces here

[Flags]
public enum Foo
{
	One = 1,
	Two = 2
}

public static class Ext
{
	public static bool Is( this Foo foo, Foo value)
	{
		return (foo & value) > 0;
	}
}