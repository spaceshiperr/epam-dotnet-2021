using System;

namespace RectangleHelper
{
    public class RectangleCalculator
    {
        public decimal Width { get; set; }

        public decimal Length { get; set; }

        public RectangleCalculator(decimal width, decimal length)
        {
            Width = width;
            Length = length;
        }

        public decimal GetPerimeter() => 2 * (Width + Length);

        public decimal GetSquare() => Width * Length;
    }
}
