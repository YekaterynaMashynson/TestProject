using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using TestProject.Models;

namespace TestProject.Services.Helpers.Interfaces
{
    public interface IShapesListDeserializer
    {
        List<ShapeDto> DeserializeShapes(string inputData);
      
    }
}
