using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public abstract class GraphicEditor
    {
        public  void DrawShape(IShape shape)
        {
            this.DrawFigure(shape);
        }
        protected abstract void DrawFigure(IShape shape);
    }
}
