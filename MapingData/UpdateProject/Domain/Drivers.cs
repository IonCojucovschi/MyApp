using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateProject.Domain
{
    public class Routes
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string curse { get; set; }
        public virtual string oterInfor { get; set; }
       public virtual Vehicle VehID { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}", id, name, oterInfor);
        }
    }
    public class Vehicle
    {
        public virtual int id { get; set; }
        public virtual string model { get; set; }
        public virtual string carNumber { get; set; }
        public virtual Routes Route { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}", id, model, carNumber);
        }

    }
    public class Accidents
    {
        public virtual int id { get; set; }
        public virtual IList<Vehicle> ID_VEhicle { get; set; }
        public virtual string details { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}", id, ID_VEhicle, details);
        }
    }
    public class Drivers
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual int age { get; set; }
        public virtual int salary { get; set; }
        public virtual string numberPH { get; set; }
        public virtual string OterInfo { get; set; }
        public virtual Vehicle ID_Vehicle { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}\t\t{3,-3}\t\t{4,-3}", name, surname, age,
                salary, numberPH);
        }

    }


    class RoutePopularity
    {
        public virtual int id { get; set; }
        public virtual Routes route_id { get; set; }
        public virtual int points { get; set; }
    }

}
