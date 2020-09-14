<Query Kind="Program" />

void Main()
{
	IPushable<Animal> animals = new AnimalStack<Animal>();
	IPushable<SpecifiedAnimal> specAnimals = animals;
	
	specAnimals.Push(new SpecifiedAnimal(){Age = 8, AnimalClass = "Predator"});
	specAnimals.Push(new SpecifiedAnimal(){Age = 4, AnimalClass = "Predator"});
	
	foreach(var anim in ((AnimalStack<Animal>)specAnimals).InnerList) {
		//anim.Age.Dump();	// because Animal havn't Age property
		anim.AnimalClass.Dump();
	}
}

// Define other methods and classes here
interface IPushable<in T>
{
	void Push(T obj);
}

class AnimalStack<T> : IPushable<T>
{
	public List<T> InnerList { get; }
	
	public AnimalStack()
	{
		InnerList = new List<T>();
	}
	
	public void Push(T obj)
	{
		InnerList.Add(obj);
	}
}

class Animal
{
	public virtual string AnimalClass { get; set; }
}

class SpecifiedAnimal : Animal
{
	public int Age { get; set; }
}