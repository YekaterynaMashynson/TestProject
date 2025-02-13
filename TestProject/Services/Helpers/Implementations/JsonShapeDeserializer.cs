using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestProject.Models;
using TestProject.Models.Helpers;
using TestProject.Models.Shapes;
using TestProject.Services.Helpers.Implementations.ShapeJsonDes;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Helpers.Interfaces.IShapeDes;


namespace TestProject.Services.Helpers.Implementations
{
    public class JsonShapeDeserializer : IShapesListDeserializer
    {
        Dictionary<string, IShapeJsonDeserialize> _shapesDeserializer;
        public JsonShapeDeserializer(Dictionary<string, IShapeJsonDeserialize> shapesDeserializer)
        {
            _shapesDeserializer = shapesDeserializer;
        }
        public List<ShapeDto> DeserializeShapes(string inputData)
        {

            var shapes = new List<ShapeDto>();
            var jsonArray = JArray.Parse(inputData);
            foreach (var token in jsonArray)
            {
                var jsonObject = token as JObject;
                string shapeType = jsonObject[ConstDto.Type]?.ToString().ToLower() ?? "";
                var colorString = jsonObject[ConstDto.Color]?.ToString();
                ColorDto color = ParseColor(colorString);
                IShapeJsonDeserialize shapeDeserializer = _shapesDeserializer[shapeType];
                ShapeDto shape = shapeDeserializer.DeserializeShape(jsonObject);
                shape.Type = shapeType;
                shape.Color = color;
                shapes.Add(shape);
            }
            return shapes;
        }

        private ColorDto ParseColor(string colorString)
        {
            if (string.IsNullOrEmpty(colorString)) return new ColorDto(0, 0, 0, 0); // Default to transparent

            var colorParts = colorString.Split(';');
            if (colorParts.Length == 4)
            {
                byte a = byte.Parse(colorParts[0].Trim());
                byte r = byte.Parse(colorParts[1].Trim());
                byte g = byte.Parse(colorParts[2].Trim());
                byte b = byte.Parse(colorParts[3].Trim());

                return new ColorDto(a, r, g, b);
            }

            throw new ArgumentException($"Invalid color format: {colorString}");
        }
    }
}
