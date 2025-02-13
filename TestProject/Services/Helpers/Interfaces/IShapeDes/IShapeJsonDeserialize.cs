using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services.Helpers.Interfaces.IShapeDes
{
    public interface IShapeJsonDeserialize
    {
        public ShapeDto DeserializeShape( JObject jsonObject); 
    }
}
