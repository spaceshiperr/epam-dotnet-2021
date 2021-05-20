namespace ShapeLibrary
{
    public class Rectangle : Shape
    {
        public Rectangle(double width, double length)
        {
            Width = width;
            Length = length;
        }

        public double Width { get; set; }

        public double Length { get; set; }

        public override double GetArea()
        {
            return Width * Length;
        }

        public override double GetPerimeter()
        {
            return (Width + Length) * 2;
        }
    }
}
