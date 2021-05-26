<Query Kind="Program" />

void Main()
{
	IFoo foo = null;
	
	(foo is Foo).Dump();
	
	foo = new Foo();
	
	(foo is Foo).Dump();
	
	foo = (Foo)null;
	
	(foo is Foo).Dump();
}

// You can define other methods, fields, classes and namespaces here
public interface IFoo {}

public class Foo : IFoo {}

public class Bar : IFoo {}