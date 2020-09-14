<Query Kind="Program" />

void Main()
{
	int[] arr = { 1, 2, 3, 4 };
	
	reduce(arr, (accumulator, currentItem) => accumulator + currentItem, 0).Dump();
}

// Define other methods and classes here
int reduce(int[] arr, Func<int,int,int> fn, int initial)
{
	if (arr.Length == 0)
		return initial;
		
	if (arr.Length == 1)
		return fn(initial, arr[0]);
		
	return reduce(arr.Skip(1).ToArray(), fn, fn(initial, arr[0]));
}