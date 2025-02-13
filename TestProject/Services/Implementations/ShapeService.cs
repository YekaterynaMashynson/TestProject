using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestProject.Models;
using TestProject.Services.Helpers.Interfaces;
using TestProject.Services.Interfaces;

namespace TestProject.Services.Implementations
{
    public class ShapeService:IShapeService
    {
        private readonly IShapesListDeserializer _deserializationService;
        private readonly string _filePath;
        public ShapeService(IShapesListDeserializer deserializationService, string filePath)
        {
            _deserializationService = deserializationService;
            _filePath = filePath;
        }
        public List<ShapeDto> GetShapes()
        {
            string inputData = ReadFile(_filePath);
            return _deserializationService.DeserializeShapes(inputData);
        }
        private string ReadFile(string filePath)
        {
            var uri = new Uri(filePath, UriKind.RelativeOrAbsolute);

            if (uri.IsAbsoluteUri)
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                var stream = Application.GetResourceStream(uri)?.Stream;
                if (stream == null) throw new FileNotFoundException("Resource file not found.");

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
