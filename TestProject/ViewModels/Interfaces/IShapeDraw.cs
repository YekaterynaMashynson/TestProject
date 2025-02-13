using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestProject.Models;

namespace TestProject.ViewModels.Interfaces
{
    public interface IShapeDraw
    {
        public void DrawShape(Canvas canvas, ShapeDto shape);
        public void ApplyTranslation(double translationX, double translationY, ShapeDto shape);
        public void ScaleShape(ShapeDto shape, double scaleFactor);
    }
}
