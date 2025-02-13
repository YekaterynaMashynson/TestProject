using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using TestProject.Models;
using TestProject.Models.Shapes;
using TestProject.Services.Interfaces;
using TestProject.ViewModels.Interfaces;
using TestProject.Services.Helpers.Interfaces.IShapeDes;

namespace TestProject.ViewModels.Implementations
{
    public class ShapeViewModel: IShapeViewModel
    {
        Dictionary<string, IShapeDraw> _shapesDraws;
        public ObservableCollection<ShapeDto> Shapes { get; set; }
        private readonly IShapeService _shapeService;

        public ShapeViewModel(IShapeService shapeService, Dictionary<string, IShapeDraw> shapesDraws)
        {
            _shapesDraws = shapesDraws;
            _shapeService = shapeService;
            Shapes = new ObservableCollection<ShapeDto>();
        }

        public void LoadShapes()
        {
            var shapes = _shapeService.GetShapes();
            foreach (var shape in shapes)
            {
                Shapes.Add(shape);
            }
        }
        public void RenderShapes(Canvas canvas)
        {
            double minX = Shapes.Min(s => s.GetMinCoordinates().X);
            double minY = Shapes.Min(s => s.GetMinCoordinates().Y);
            double maxX = Shapes.Max(s => s.GetMaxCoordinates().X);
            double maxY = Shapes.Max(s => s.GetMaxCoordinates().Y);
            // Calculate the translation and apply it to the shapes
            double translationX = minX < 0 ? -minX : 0;
            double translationY = minY < 0 ? -minY : 0;
            double scaleFactor = CalculateScalingFactor(minX + translationX, maxX + translationX, minY + translationY, maxY + translationY, canvas);
            foreach (var shape in Shapes)
            {
                IShapeDraw shapeDraw = _shapesDraws[shape.Type];
                shapeDraw.ApplyTranslation(translationX, translationY, shape);
                shapeDraw.ScaleShape(shape,scaleFactor);
                shapeDraw.DrawShape(canvas,shape);
            }
        }

        #region Scaling
        private double CalculateScalingFactor(double minX, double maxX, double minY, double maxY, Canvas canvas)
        {
            double scaleX = canvas.Width / (maxX - minX);
            double scaleY = canvas.Height / (maxY - minY);

            return Math.Min(scaleX, scaleY);
        }
        #endregion
    }
}
