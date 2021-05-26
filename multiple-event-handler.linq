<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var foo = new Foo();
	
	foo.SomeEvent += DoWork;
	foo.SomeEvent += DoWork;
	foo.SomeEvent += DoWork;
	foo.SomeEvent += DoWork;
	
	foo.OnSomeEvent();
	
	"Remove one handler".Dump();
	foo.SomeEvent -= DoWork;
	
	foo.OnSomeEvent();
}

public static void DoWork( object sender, EventArgs args)
{
	"Do Work".Dump();
}

// You can define other methods, fields, classes and namespaces here
public class Foo
{
	public event EventHandler SomeEvent;
	
	public void OnSomeEvent()
	{
		SomeEvent?.Invoke(this, EventArgs.Empty);
	}
}