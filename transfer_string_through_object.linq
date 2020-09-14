<Query Kind="Program" />

void Main()
{
	Object a = "21";
	Object b = a;
	
	a = "qwe";
	((string)b).Dump();
}

// Define other methods and classes here
