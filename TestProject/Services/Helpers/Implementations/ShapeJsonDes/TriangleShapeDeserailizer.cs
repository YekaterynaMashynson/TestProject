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
    internal class TriangleShapeDeserailizer : IShapeJsonDeserialize
    {
        public ShapeDto DeserializeShape(JObject jsonObject)
        {
            Triangle triangle = new Triangle();
            triangle.A = JsonPointParser.ParsePoint(jsonObject[ConstDto.A]?.ToString());
            triangle.B = JsonPointParser.ParsePoint(jsonObject[ConstDto.B]?.ToString());
            triangle.C = JsonPointParser.ParsePoint(jsonObject[ConstDto.C]?.ToString());
            triangle.Filled = bool.Parse(jsonObject[ConstDto.Filled]?.ToString());
            return triangle;
        }
    }
}
