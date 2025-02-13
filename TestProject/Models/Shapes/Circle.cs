using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models.Helpers;

namespace TestProject.Models.Shapes
{
    public class Circle:ShapeDto
    {
        public PointDto Center { get; set; }  // Coordinates of the center
        public double Radius { get; set; }  // Radius of the circle
        public bool Filled { get; set; }    // Flag to determine if the circle is filled or just a border

        public override PointDto GetMaxCoordinates()
        {
            double maxX = Center.X + Radius;
            double maxY = Center.Y + Radius;
            return new PointDto(maxX, maxY);
        }

        public override PointDto GetMinCoordinates()
        {
            double minX = Center.X-Radius;
            double minY = Center.Y-Radius;
            return new PointDto(minX,minY);
        }
    }
}
