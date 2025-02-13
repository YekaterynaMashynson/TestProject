using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using TestProject.Models;
using TestProject.Models.Shapes;
using TestProject.ViewModels.Interfaces;

namespace TestProject.ViewModels.Implementations.ShapesDraw
{
    public class TriangleDraw:IShapeDraw
    {
        public void ApplyTranslation(double translationX, double translationY, ShapeDto shape)
        {
            var triangle = shape as Triangle;
            triangle.A.X += translationX;
            triangle.A.Y += translationY;
            triangle.B.X += translationX;
            triangle.B.Y += translationY;
            triangle.C.X += translationX;
            triangle.C.Y += translationY;
        }

        public void DrawShape(Canvas canvas, ShapeDto shape)
        {
            var triangle = shape as Triangle;
            var polygon = new Polygon
            {
                Points = new PointCollection
                {
                new Point(triangle.A.X, triangle.A.Y),
                new Point(triangle.B.X, triangle.B.Y),
                new Point(triangle.C.X, triangle.C.Y)
            },
                Fill = triangle.Filled ? new SolidColorBrush(triangle.Color.ToWpfColor()) : null,
                
                Stroke = new SolidColorBrush(triangle.Color.ToWpfColor()),
                StrokeThickness = 1
            };

            canvas.Children.Add(polygon);
        }

        public void ScaleShape(ShapeDto shape, double scaleFactor)
        {
            var triangle = shape as Triangle;
            triangle.A.X *= scaleFactor;
            triangle.A.Y *= scaleFactor;
            triangle.B.X *= scaleFactor;
            triangle.B.Y *= scaleFactor;
            triangle.C.X *= scaleFactor;
            triangle.C.Y *= scaleFactor;
        }
    }
}
