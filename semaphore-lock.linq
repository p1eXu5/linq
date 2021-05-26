<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var foo = new Foo();
	var t1 = Task.Run( async () => await foo.Bar() );
	var t2 = Task.Run( async () => await foo.Baz() );
	
	await Task.WhenAll( t1, t2 );
	
	var t3 = Task.Run( () => foo.Bar2() );
	var t4 = Task.Run( () => foo.Baz2() );
	
	await Task.WhenAll( t3, t4 );
}

// You can define other methods, fields, classes and namespaces here
public class Foo
{
	private static object _lock = new object();
	private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

	public int Counter = 0;

	public async Task Bar()
	{
		_semaphore.Wait();
		await Task.Delay( 1000 );
		"Bar".Dump();
		_semaphore.Release();
	}
	
	public async Task Baz()
	{
		_semaphore.Wait();
		await Task.Delay( 1000 );
		"Baz".Dump();
		_semaphore.Release();
	}
	
	public void Bar2()
	{
		lock ( _lock ) {
			Task.Delay( 1000 ).Wait();
			"Bar2".Dump();
		}
	}
	
	public void Baz2()
	{
		lock ( _lock ) {
			Task.Delay( 1000 ).Wait();
			"Baz2".Dump();
		}
	}
}