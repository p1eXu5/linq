<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

async Task Main()
{
	const int N = 10;

	Task[] tasks = new Task[10];
	List<string>[] results = new List<string>[N];

	for (int i = 0; i < N; ++i )
	{
		int ind = i;
		tasks[i] = Task.Run(async () => {
			await Test();
		});
	}
	await Task.WhenAll( tasks );
	results.Dump();
}


public async Task Test()
{
	if ( Foo._instance is null ) {
		"is null".Dump();
		await Foo.GetInstance();
	}
}


// You can define other methods, fields, classes and namespaces here
public class Foo
{
	public List<string> Values { get; set; }

	public static Foo _instance;

	public static async Task<Foo> GetInstance()
	{
		if ( _instance is null ) 
		{		
			"Creating".Dump();
			//await Task.Delay( 500 );
			List<string> values = new();
			for ( int i = 1; i <= 4; ++i)
			{
				await Task.Delay(100);
				values.Add( i.ToString() );
			}
			_instance = new() { Values = values };
		}
		
		return _instance;
	}
}