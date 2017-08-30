using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateProject.DataFormat
{
    public class dataFormat1
    {
        public int DriverNumber { get; set; }
        public int VehicleNumber { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0,-10}\t\t{1,-10}", DriverNumber, VehicleNumber);
        }
    }

}
