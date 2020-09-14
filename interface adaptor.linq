<Query Kind="Program" />

void Main()
{
	Foo( new DrawingWrapper( new Drawing() ) );
}

public void Foo( IDrawing drawing )
{
	drawing.Draw();
}

// Define other methods and classes here
public class Drawing
{
	public void Draw() => "Draw".Dump();
}

public interface IDrawing
{
	void Draw();
}

public struct DrawingWrapper : IDrawing
{
	private readonly Drawing _drawing;
	
	public DrawingWrapper( Drawing d )
	{
		_drawing = d;
	}
	
	public void Draw() => _drawing?.Draw();
}