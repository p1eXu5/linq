<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	const int N = 10_000;
	var e = Enumerable.Range(1, 1_000).Select( i => i.ToString() );
	
	var sw = new Stopwatch();
	
	"ToImmutableArray()".Dump();
	sw.Start();
	for ( int i = 0; i < N; ++i ) {
		var coll = e.ToImmutableArray();
	}
	
	sw.Stop();
	sw.Elapsed.Dump();
	
	"ToImmutableList()".Dump();
	sw.Restart();
	
	for ( int i = 0; i < N; ++i ) {
		var coll = e.ToImmutableList();
	}
	sw.Stop();
	sw.Elapsed.Dump();
	
	"ToList()".Dump();
	sw.Restart();
	
	for ( int i = 0; i < N; ++i ) {
		var coll = e.ToList();
	}
	sw.Stop();
	sw.Elapsed.Dump();
	
	"ToArray()".Dump();
	sw.Restart();
	
	for ( int i = 0; i < N; ++i ) {
		var coll = e.ToArray();
	}
	sw.Stop();
	sw.Elapsed.Dump();
}

// You can define other methods, fields, classes and namespaces here
