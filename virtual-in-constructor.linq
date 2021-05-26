<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Foo foo = new Foo();
	foo.Value.Dump();
	
	Foo bar = new Bar();
	bar.Value.Dump();
}

// Define other methods, classes and namespaces here

public class Foo
{
	protected string _value;
	
	public Foo()
	{
		SetValue( "Foo init value" );
	}
	
	protected virtual void SetValue( string value )
	{
		_value = "Foo";
	}


	public string Value
	{
		get => _value;
	}
}

public class Bar : Foo
{
	public Bar()
	{
		_value = "some";
	}

	protected override void SetValue( string value )
	{
		Debug.WriteLine("There is no other way to set _value! Liskov substitution principle is restricted. State of a derived class has no set yet.");
		if ( Value.ToString() == "some" ) {
		}
		
	}
}