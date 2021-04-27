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
                throw new ArgumentException("Width and length must be positive numbers");
            }

            Width = width;
            Length = length;
        }

        public decimal GetPerimeter()
        {
            var perimeter = 2 * (Width + Length);
            return perimeter;
        }

        public decimal GetSquare()
        {
            var square = Width * Length;
            return square;
        }
    }
}
