using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models.Helpers
{
    public class PointDto
    {
        public double X { get; set; }  // X coordinate
        public double Y { get; set; }  // Y coordinate

        public PointDto(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
