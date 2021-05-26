<Query Kind="Program">
  <Namespace>System.Collections.Immutable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Ogject - initialization with collection with private setter;

void Main()
{
	var b = new Bar()
	{
		Sgtin = { "sdf" }
	};
	b.Dump();
	
	
	var l = new Foo();
	l.Sgtin = { "sdf" };
	
	l.Dump();
	
}

// You can define other methods, fields, classes and namespaces here
public class Foo
{
	public Foo()
	{
		this._sgtin = new List<string>();
	}

    private List<string> _sgtin;
	public List<string> Sgtin
    {
        get
        {
            return this._sgtin;
        }
        private set
        {
            this._sgtin = value;
        }
    }
}


public class Bar
{
	public Bar()
	{
		this._sgtin = new List<string>();
	}

    private List<string> _sgtin;
	public List<string> Sgtin
    {
        get
        {
            return this._sgtin;
        }
        private set
        {
            this._sgtin = value;
        }
    }
}