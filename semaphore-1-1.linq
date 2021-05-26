<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
	for ( int i = 0; i <= 5; ++i ) new Thread( Enter ).Start();
}

// Define other methods, classes and namespaces here
public static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

public void Enter()
{
	"Enter".Dump();
	_semaphore.Wait();
	Thread.Sleep( 1000 );
	"in".Dump();
	_semaphore.Release();
	"out".Dump();
}