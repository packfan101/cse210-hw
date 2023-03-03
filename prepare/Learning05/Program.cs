using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        Square s1 = new Square("green", 6);
        shapes.Add(s1);

        Circle c1 = new Circle("red", 3);
        shapes.Add(c1);

        Rectangle r1 = new Rectangle("purple", 6, 4);
        shapes.Add(r1);

        foreach (Shape shape in shapes){
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}\n");
    }
    }

    
    
}