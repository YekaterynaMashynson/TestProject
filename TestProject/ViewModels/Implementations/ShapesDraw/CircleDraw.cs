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
    internal class CircleDraw : IShapeDraw
    {
        public void ApplyTranslation(double translationX, double translationY, ShapeDto shape)
        {
            var circle = shape as Circle;
            circle.Center.X += translationX;
            circle.Center.Y += translationY;
        }

        public void DrawShape(Canvas canvas, ShapeDto shape)
        {
            var circle = shape as Circle;
            var strokeColor = new SolidColorBrush(Colors.Red);
            var circleElement = new Ellipse
            {
                Width = circle.Radius * 2,
                Height = circle.Radius * 2,
                Fill = circle.Filled ? new SolidColorBrush(circle.Color.ToWpfColor()) : null,
                Stroke = new SolidColorBrush(circle.Color.ToWpfColor()),
                StrokeThickness = 1
            };
            Canvas.SetLeft(circleElement, circle.Center.X - circle.Radius);
            Canvas.SetTop(circleElement, circle.Center.Y - circle.Radius);
            canvas.Children.Add(circleElement);
        }

        public void ScaleShape(ShapeDto shape, double scaleFactor)
        {
            var circle = shape as Circle;
            circle.Center.X *= scaleFactor;
            circle.Center.Y *= scaleFactor;
            circle.Radius *= scaleFactor;
        }
    }
}
