using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models.Helpers;

namespace TestProject.Models.Shapes
{
    public class Triangle:ShapeDto
    {
        public PointDto A { get; set; }  // Coordinates of point A
        public PointDto B { get; set; }  // Coordinates of point B
        public PointDto C { get; set; }  // Coordinates of point C
        public bool Filled { get; set; }  // Flag to determine if the triangle is filled or just a border

        public override PointDto GetMaxCoordinates()
        {
            double maxX = Math.Max(Math.Max(A.X, B.X), C.X);
            double maxY = Math.Max(Math.Max(A.Y, B.Y), C.Y);
            return new PointDto(maxX, maxY);
        }

        public override PointDto GetMinCoordinates()
        {
            double minX = Math.Min(Math.Min(A.X, B.X), C.X);
            double minY = Math.Min(Math.Min(A.Y, B.Y), C.Y);
            return new PointDto(minX, minY);
        }
    }
}
