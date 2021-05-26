<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	new Inheritant( "some" );
}

// You can define other methods, fields, classes and namespaces here
public abstract class Base
{
	protected Base() 
	{
		"Base: ".Dump();
		Prop.Dump();
	}
	
	public abstract string Prop { get; }
	
	protected void Subscribe()
	{
		"Subscribe: ".Dump();
		Prop.Dump();
	}
}


public class Inheritant : Base
{
	private string _prop;
	
	public Inheritant( string prop )
	{
		"Inheritant: ".Dump();
		_prop = prop;
		Prop.Dump();
		
		Subscribe();
	}
	
	public override string Prop => _prop;
}