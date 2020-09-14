<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var foo = new Foo() { Name = "Main func" };
	Process( ref foo );
	foo.Name.Dump();
}


public void Process( ref Foo foo )
{
	Foo local = foo;
	var res = Invoke( d => d( ref local ) );
	foo = local;
}


// Define other methods, classes and namespaces here
public delegate int ChangeDelegate( ref Foo foo );

public int Invoke( Func<ChangeDelegate, int> delegFunc )
{
	ChangeDelegate deleg = BarMethod;
	
	return delegFunc( deleg );
}

public int BarMethod( ref Foo foo )
{
	foo.Name = "BarMethod name";
	return 666;
}

public struct Foo
{
	public string Name;
}