<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	(new Foo() is INullObject).Dump();
	(new Bar() is INullObject).Dump();
}

// Define other methods, classes and namespaces here
public interface INullObject
{ }

public class Foo : INullObject
{ }

public class Bar : Foo
{ }