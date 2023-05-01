using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcousticsClient.Models
{
    internal class Surface
    {
        public Surface()
        {
        }

        public Surface(string name, double reflection)
        {
            Name = name;
            Reflection = reflection;
        }

        public string Name { get; private set; } = "";    
        public double Reflection { get; private set; }



    }
}
