using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TestProject.Models;
using TestProject.Models.Shapes;
using TestProject.ViewModels.Interfaces;

namespace TestProject.ViewModels.Implementations.ShapesDraw
{
    internal class LineDraw : IShapeDraw
    {
        public void ApplyTranslation(double translationX, double translationY, ShapeDto shape)
        {
            var line = shape as LineDto;
            line.A.X += translationX;
            line.A.Y += translationY;
            line.B.X += translationX;
            line.B.Y += translationY;
        }

        public void DrawShape(Canvas canvas, ShapeDto shape)
        {
            var line = shape as LineDto;
            var lineElement = new Line
            {
                X1 = line.A.X,
                Y1 = line.A.Y,
                X2 = line.B.X,
                Y2 = line.B.Y,
                Stroke = new SolidColorBrush(line.Color.ToWpfColor()),
                StrokeThickness = 1
            };
            canvas.Children.Add(lineElement);
        }

        public void ScaleShape(ShapeDto shape, double scaleFactor)
        {
            var line = shape as LineDto;
            line.A.X *= scaleFactor;
            line.A.Y *= scaleFactor;
            line.B.X *= scaleFactor;
            line.B.Y *= scaleFactor;
        }
    }
}
