using System;

namespace RectangleHelper
{
    public class RectangleCalculator
    {
        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public RectangleCalculator(decimal width, decimal length)
        {
            if (width <= 0 | length <= 0)
            {
                throw new ArgumentException();
            }
           
            Width = width;
            Length = length;
        }

        public decimal GetPerimeter() => 2 * (Width + Length);

        public decimal GetSquare() => Width * Length;
    }
}
