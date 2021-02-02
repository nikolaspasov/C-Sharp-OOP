using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class SquareDrawMethod : GraphicEditor
    {
        protected override void DrawFigure(IShape shape)
        {
            Console.WriteLine("I'm a square");
        }
    }
}
