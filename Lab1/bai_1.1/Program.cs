using System;

public abstract class Shape
{
    public string Name { get; set; }

    public abstract double CalculateArea();

    public abstract string Draw(); 
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(string name, double width, double height)
    {
        Name = name;
        Width = width;
        Height = height;
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    public override string Draw() 
    {
        return $"Ve hinh chu nhat {Name} voi chieu rong {Width} và chieu cao {Height}";
    }
}

public class Square : Rectangle
{
    public Square(string name, double sideLength) : base(name, sideLength, sideLength)
    {
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(string name, double radius)
    {
        Name = name;
        Radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override string Draw() 
    {
        return $"Ve hinh tron {Name} voi ban kinh {Radius}";
    }
}

public class Triangle : Shape
{
    public double edge1 { get; set; }
    public double  edge2 { get; set; }
    public double edge3 { get; set; }
    public Triangle(string name, double e1, double e2, double e3)
    {
        Name = name;
        edge1 = e1;
        edge2 = e2;
        edge3 = e3;
    }

    public override double CalculateArea()
    {
        double p = edge1+edge2+edge3;
        return Math.Sqrt(p*(p-edge1)*(p-edge2)*(p-edge3));
    }

    public override string Draw() 
    {
        return $"Ve hinh tam giac {Name} voi 3 canh {edge1}, {edge2}, {edge3} ";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Nhap so luong hinh muon tao: ");
        int numberOfShapes = int.Parse(Console.ReadLine());

        Random random = new Random();
        List<Shape> listShapes = new List<Shape>();

        for (int i = 0; i < numberOfShapes; i++)
        {
            int shapeType = random.Next(1, 4); // 1: Rectangle, 2: Circle, 3: Triangle
            string shapeName = $"Hinh {i + 1}";

            if (shapeType == 1)
            {
                Console.Write("Nhap chieu rong hinh chu nhat: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Nhap chieu cao hinh chu nhat: ");
                double height = double.Parse(Console.ReadLine());

                Rectangle rectangle = new Rectangle(shapeName, width, height);
                listShapes.Add(rectangle);
            }
            else if (shapeType == 2)
            {
                Console.Write("Nhap ban kinh hinh tron: ");
                double radius = double.Parse(Console.ReadLine());

                Circle circle = new Circle(shapeName, radius);
                listShapes.Add(circle);
            }
            else if (shapeType == 3)
            {
                Console.Write("Nhap canh 1 cua hinh tam giac: ");
                double e1 = double.Parse(Console.ReadLine());
                Console.Write("Nhap canh 2 cua hinh tam giac: ");
                double e2 = double.Parse(Console.ReadLine());
                Console.Write("Nhap canh 3 cua hinh tam giac: ");
                double e3 = double.Parse(Console.ReadLine());

                Triangle triangle = new Triangle(shapeName, e1, e2, e3);
                listShapes.Add(triangle);
            }
        }

        foreach (Shape shape in listShapes)
        {
            Console.WriteLine(shape.Draw());
            Console.WriteLine($"Dien tich: {shape.CalculateArea()}");
            Console.WriteLine();
        }
    }
}
