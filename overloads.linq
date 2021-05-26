<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	IFoo[] foos = new IFoo[] {
		new Foo(),
		new Bar<int>(),
		new Baz< int, string >()
	};
	
	foreach( var foo in foos)
	{
		Process( foo );
	}
}

public void Process( IFoo foo )
{
	foo.GetType().Name.Dump();
}

public void Process<T>( IBar<T> foo )
{
	foo.GetType().Name.Dump();
}

public void Process<T1, T2>( IBaz<T1, T2> foo )
{
	foo.GetType().Name.Dump();
}

// You can define other methods, fields, classes and namespaces here
public interface IFoo
{}

public interface IBar<T> : IFoo {}

public interface IBaz<T1, T2> : IFoo {}

public class Foo : IFoo {}
public class Bar<T> : IBar<T> {}
public class Baz<T1, T2> : IBaz<T1, T2> {}
