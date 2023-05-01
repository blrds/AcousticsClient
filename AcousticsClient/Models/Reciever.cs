using AcousticsClient.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcousticsClient.Models
{
    internal class Reciever
    {
        public Vector3 Coordinates { get; private set; }=new Vector3();
        public double CellLagTime { get; set; }
        public double RWallLagTime { get; set; }
        public double LWallLagTime { get; set; }
    }
}
 