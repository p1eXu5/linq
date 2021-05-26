<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	// if using List then error!!!
	var bar = new Foo[] { new Foo { Name = "Before" } };
	
	var beforeFoo = bar[0];
	
	bar[0].Dump();
	beforeFoo.Dump();
	
	bar[0].Replace( out bar[0], "Next" );
	
	bar[0].Dump();
	beforeFoo.Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Foo
{
	public string Name { get; set; }
	
	public void Replace( out Foo foo, string newValue )
	{
		var f = (Foo)MemberwiseClone();
		f.Name = newValue;
		foo = f;
	}
}