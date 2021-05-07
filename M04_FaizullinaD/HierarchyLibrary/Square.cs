namespace ShapeLibrary
{
    public class Square : Shape
    {
        public Square(double side)
        {
            Side = side;
        }

        public double Side { get; set; }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return Side * 4;
        }
    }
}
