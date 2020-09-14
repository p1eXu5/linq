<Query Kind="Program" />

void Main()
{
	try {
		"outer try".Dump();
		SomeMethod();
	}
	catch (ArgumentException) {
		"outer catch".Dump();
	}
	finally {
		"outer finally".Dump();
	}
	
}

// Define other methods and classes here
void SomeMethod()
{
	try {
		"inner try".Dump();
		DeepSomeMethod();
	}
	catch {
		"inner catch".Dump();
		throw;
	}
	finally {
		"inner finally".Dump();
	}
}

void DeepSomeMethod()
{
	try {
		"deep inner try".Dump();
		throw new ArgumentException();
	}
	catch {
		"deep inner catch".Dump();
		throw;
	}
	finally {
		"deep inner finally".Dump();
	}
}