using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using TestProject.Models;
using TestProject.Models.Shapes;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Helpers.Interfaces.IShapeDes;

namespace TestProject.Services.Helpers.Implementations.ShapeJsonDes
{
    public class LineShapeDeserailizer : IShapeJsonDeserialize
    {
        public ShapeDto DeserializeShape(JObject jsonObject)
        {
           LineDto line = new LineDto();
           line.A = JsonPointParser.ParsePoint(jsonObject[ConstDto.A]?.ToString());
           line.B = JsonPointParser.ParsePoint(jsonObject[ConstDto.B]?.ToString());
            return line;
        }
    }
}
