using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TestProject.Models.Helpers;

namespace TestProject.Models.Shapes
{
    public class LineDto:ShapeDto
    {
        public PointDto A { get; set; }  // Coordinates of point A
        public PointDto B { get; set; }  // Coordinates of point B

        public override PointDto GetMaxCoordinates()
        {
            double maxX = Math.Max(A.X, B.X);
            double maxY = Math.Max(A.Y, B.Y);
            return new PointDto(maxX, maxY);
        }

        public override PointDto GetMinCoordinates()
        {
            double minX = Math.Min(A.X, B.X);
            double minY = Math.Min(A.Y, B.Y);
            return new PointDto(minX, minY);
        }
    }
}
