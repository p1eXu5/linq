<Query Kind="Program" />

void Main()
{
	var skills = new[] {
		new Skill(),
	};
	
	var bios = new[] {
		new Bio(),
	};
	
	IEnumerable< IEntity > entities = skills;
	
	View( (dynamic) entities );
	
	entities = bios;
	
	View( (dynamic) entities );
}

// Define other methods and classes here
void View( IEnumerable< Skill > entities )
{
	entities.First().TypeName.Dump();
}

void View( IEnumerable< Bio > entities )
{
	entities.First().TypeName.Dump();
}


public interface IEntity{}

public class Skill : IEntity
{
	public string TypeName { get; } = "Skill";
}

public class Bio : IEntity
{
	public string TypeName { get; } = "Bio";
}