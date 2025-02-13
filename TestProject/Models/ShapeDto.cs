using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models.Helpers;

namespace TestProject.Models
{
    public abstract class ShapeDto
    {
        public string Type { get; set; }  // Now using ShapeType enum
        public ColorDto Color { get; set; }    // ARGB color representation

        public abstract PointDto GetMinCoordinates();
        public abstract PointDto GetMaxCoordinates();
    }
}
