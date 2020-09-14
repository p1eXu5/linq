<Query Kind="Program" />

void Main()
{
	List<Trolleybus> trollList = new List<Trolleybus>
	{
		new ServiceTrolleybus(),
		new PublicTrolleybus()
	};
	
	List<Object> receiver = new List<Object>(trollList);
	
	foreach(var item in receiver)
	{
		if (item is ServiceTrolleybus)
			"Service!".Dump();
		if (item is PublicTrolleybus)
			"Public!".Dump();
	}
}

// Define other methods and classes here
public class Trolleybus
{
	string Model;
}

public class ServiceTrolleybus : Trolleybus
{
	Dictionary<DateTime,Object> ServiceList = new Dictionary<DateTime,Object>();
}

public class PublicTrolleybus : Trolleybus
{
	int SeatNumber;
}