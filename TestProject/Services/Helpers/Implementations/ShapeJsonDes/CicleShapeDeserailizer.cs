using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Models.Shapes;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Helpers.Interfaces.IShapeDes;

namespace TestProject.Services.Helpers.Implementations.ShapeJsonDes
{
    public class CicleShapeDeserailizer : IShapeJsonDeserialize
    {
        public ShapeDto DeserializeShape(JObject jsonObject)
        {
            Circle circle = new Circle();
            circle.Center = JsonPointParser.ParsePoint(jsonObject[ConstDto.Center]?.ToString());
            circle.Radius = double.Parse(jsonObject[ConstDto.Radius]?.ToString());
            circle.Filled = bool.Parse(jsonObject[ConstDto.Filled]?.ToString());
            return circle;
        }
    }
}
