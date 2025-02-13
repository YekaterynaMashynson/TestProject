using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models.Helpers
{
    using System.Windows.Media;

    public class ColorDto
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte Alpha { get; set; }

        // Constructor
        public ColorDto(byte alpha,byte red, byte green, byte blue )
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        // Convert to WPF Color
        public Color ToWpfColor()
        {
            return Color.FromArgb(Alpha, Red, Green, Blue);
        }

        // Optional: ToString method for easier representation
        public override string ToString()
        {
            return $"{Red}; {Green}; {Blue}; {Alpha}";
        }

        // Factory method to create ColorDto from a string
        public static ColorDto FromString(string colorString)
        {
            var parts = colorString.Split(';');
            byte red = byte.Parse(parts[0].Trim());
            byte green = byte.Parse(parts[1].Trim());
            byte blue = byte.Parse(parts[2].Trim());
            byte alpha = byte.Parse(parts[3].Trim());

            return new ColorDto(red, green, blue, alpha);
        }
    }

}
