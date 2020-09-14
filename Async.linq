<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Go();
	Console.WriteLine ("End program;");
}


// Define other methods and classes here
async void Go()
{
	//PrintAnswerToLife();
	//Console.WriteLine ("Done");
	await GoAsync();
}

void PrintAnswerToLife()
{
	int answer = GetAnswerToLife();
	Console.WriteLine (answer);
}

int GetAnswerToLife()
{
	Thread.Sleep (5000);
	int answer = 21 * 2;
	return answer;
}

async Task GoAsync()
{
	var task = PrintAnswerToLifeAsync();
	await task;
	Console.WriteLine ("Done");
}

async Task PrintAnswerToLifeAsync()
{
	var task =  GetAnswerToLifeAsync();
	int answer = await task;
	Console.WriteLine (answer);
}

async Task<int> GetAnswerToLifeAsync()
{
	var task =  Task.Delay (5000);
	await task;
	int answer = 21 * 2;
	return answer;
}