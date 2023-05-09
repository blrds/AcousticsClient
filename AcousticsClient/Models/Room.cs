using AcousticsClient.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcousticsClient.Models
{
    internal class Room
    {
        public Room(string name="Room")
        {
            Name = name;
        }
        public Room(string name, Vector3 proportions)
        {
            Name = name;
            Proportions = proportions;
        }
        public string Name { get; set; } = "Room";

        /// <summary>
        /// x-length, y-width, z-height
        /// </summary>
        public Vector3 Proportions { get; set; } = new Vector3();
    }
}
