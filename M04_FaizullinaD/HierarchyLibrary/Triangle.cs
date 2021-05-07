using System;

namespace ShapeLibrary
{
    public class Triangle : Shape
    {
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; set; }

        public override double GetArea()
        {
            var p = GetPerimeter() / 2;
            var area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return area;
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
    }
}
