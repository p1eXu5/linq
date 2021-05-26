<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var foo = new Foo();
	ReferenceEquals( foo, null ).Dump();
	
	Foo nullFoo = null;
	ReferenceEquals( nullFoo, null ).Dump();
	
	int a = 5;
	ReferenceEquals( a, null ).Dump();
	
	int? na = null;
	ReferenceEquals( na, null ).Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Foo
{}