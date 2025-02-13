using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models.Helpers;

namespace TestProject.Services.Helpers.Implementations
{
    public class JsonPointParser
    {
        public static PointDto ParsePoint(string pointString)
        {
            var parts = pointString.Split(';');
            if (parts.Length == 2)
            {
                double x1 = double.Parse(parts[0].Trim());
                double y1 = double.Parse(parts[1].Trim());
                return new PointDto(x1, y1);
            }

            throw new ArgumentException($"Invalid point format: {pointString}");
        }
    }
}
