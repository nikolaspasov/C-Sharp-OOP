using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle:Shape
    {
        private double height;
        private double width;

        public Rectangle(double height,double width)
        {
            Height = height;
            Width = width;
        }
        public override double CalculatePerimeter()
        {
            return 2 * (Height+Width);
        
        }
        public override double CalculateArea()
        {
            return Height * Width;
        }

        public double Height
        {
            get { return height; } 
            set { height = value; }
        }
        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public override string Draw()
        {
            return "Drawing Rectangle";
        }

    }
}
