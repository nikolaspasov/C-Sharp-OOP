using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle:Shape
    {
        private double radius;
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double CalculateArea()
        {
            return Math.PI*(Radius*Radius);
        }
        public override double CalculatePerimeter()
        {
            return Math.PI*(Radius+Radius);
        }
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        public override string Draw()
        {
            return "Drawing Circle";
        }
            
    }
}
