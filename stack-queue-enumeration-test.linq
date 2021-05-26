<Query Kind="Program" />

void Main()
{
	var queue = new Queue<string>();
	queue.Enqueue("one");
	queue.Enqueue("two");
	
	foreach (var s in queue) s.Dump();
	
	var stack = new Stack<string>();
	stack.Push("one");
	stack.Push("two");
	
	foreach (var s in stack) s.Dump();
}

// You can define other methods, fields, classes and namespaces here
