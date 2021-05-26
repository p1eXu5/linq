<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var tasks = new List<Task>();
	for	( int i = 0; i < 10; ++i ) {
		int tmp = i;
		tasks.Add( Task.Run( () => {
			if ( i % 2 != 0 ) Inc();
			else {
				Interlocked.Exchange( ref foo, 1 );
			}
		} ) );
	}
	
	Task.WaitAll( tasks.ToArray() );
	
	acc.Dump();
}

// You can define other methods, fields, classes and namespaces here
private static int foo = 0;
private static int acc = 0;

private static void Inc()
{
	if ( Interlocked.CompareExchange( ref foo, 1, 0 ) == 1 ) return;
	++acc;
}