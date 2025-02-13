using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TestProject.Models;
using TestProject.Services.Helpers.Implementations;
using TestProject.Services.Helpers.Implementations.ShapeJsonDes;
using TestProject.Services.Helpers.Interfaces;

using TestProject.Services.Helpers.Interfaces.IShapeDes;
using TestProject.Services.Implementations;
using TestProject.ViewModels.Implementations;
using TestProject.ViewModels.Implementations.ShapesDraw;
using TestProject.ViewModels.Interfaces;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IShapeViewModel _viewModel;
        Dictionary<string, IShapeJsonDeserialize> _shapesDeserializer = new Dictionary<string, IShapeJsonDeserialize>()
        {
             { ConstDto.Circle, new CicleShapeDeserailizer() },
             { ConstDto.Line, new LineShapeDeserailizer () },
             { ConstDto.Triangle, new TriangleShapeDeserailizer() }
        };
        Dictionary<string, IShapeDraw> _shapesDraw= new Dictionary<string, IShapeDraw>()
        {
             { ConstDto.Circle, new CircleDraw() },
             { ConstDto.Line, new LineDraw () },
             { ConstDto.Triangle, new TriangleDraw() }
        };
        public MainWindow()
        {
            InitializeComponent();
            string sourceFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Assets", "Shapes.json");
            IShapesListDeserializer deserializationService = new JsonShapeDeserializer(_shapesDeserializer);
            var shapeService = new ShapeService(deserializationService, sourceFilePath);

            _viewModel = new ShapeViewModel(shapeService, _shapesDraw);
            this.DataContext = _viewModel;

            _viewModel.LoadShapes();
            _viewModel.RenderShapes(DrawingCanvas);
          
        }
    }
}
