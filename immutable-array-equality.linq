<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Foo[] arr1 = new [] {
		new Foo( "asd" ),
		new Foo( "bnm" ),
	};
	
	Foo[] arr2 = new [] {
		new Foo( "asd" ),
		new Foo( "bnm" ),
	};
	
	arr1.Equals( arr2 ).Dump();
	
	var iarr1 = arr1.ToImmutableArray();
	var iarr2 = arr2.ToImmutableArray();
	
	iarr1.Equals( iarr2 ).Dump();
}

// You can define other methods, fields, classes and namespaces here
public record Foo( string Abc );