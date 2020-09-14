<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{

	var tcs = new TaskCompletionSource<int>();
	
	new Thread (() => { Thread.Sleep (5000); tcs.SetResult (42); })
		{ IsBackground = true }
		.Start();
		
	Task<int> task = tcs.Task;
	Console.WriteLine (task.Result);
}

// Define other methods and classes here
