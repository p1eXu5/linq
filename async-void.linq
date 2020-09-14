<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Navigate();
}

// Define other methods, classes and namespaces here
public void Navigate()
{
	string foo = "sdfsdf";
	"Pre OnNavigate()".Dump();
	OnNavigate( foo );
	"Post OnNavigate()".Dump();
}

public async void OnNavigate( string p )
{
	try {
	"OnNavigate Start".Dump();
	await SomeTask();
	await SomeTask();
	"OnNavigate Done".Dump();
	}
	catch {
		"Exception".Dump();
	}
}

public async Task SomeTask()
{
	"Task start".Dump();
	await Task.Delay(1000);
	throw new Exception();
	"Task done".Dump();
}