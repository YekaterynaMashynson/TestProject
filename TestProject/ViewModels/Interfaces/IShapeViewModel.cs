using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestProject.ViewModels.Interfaces
{
    public interface IShapeViewModel
    {
        void RenderShapes(Canvas canvas);
        void LoadShapes();
    }
}
