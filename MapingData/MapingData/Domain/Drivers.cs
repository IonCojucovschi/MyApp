using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MapingData.Domain
{
     class RoutesMap : ClassMap<Routes>
    {
        public RoutesMap()
        {
            Id(x => x.id);
            Map(x => x.name);
            Map(x => x.curse);
            Map(x => x.oterInfor);
        }
    }

     class Routes
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string curse { get; set; }
        public virtual string oterInfor { get; set; }
    }

     class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.id);
            Map(x => x.model);
            Map(x => x.carNumber);
            References(x => x.Route);
        }
    }
     class Vehicle
    {
        public virtual int id { get; set;}
        public virtual string model { get; set;}
        public virtual string carNumber { get; set;}
        public virtual Routes Route { get; set;}



    }
     class DriversMap : ClassMap<Drivers>
    {
        public DriversMap()
        {
            Id(x => x.id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable();
            Map(x => x.age);
            Map(x => x.salary);
            Map(x => x.numberPH);
            Map(x=>x.OterInfo);
            References(x => x.ID_Vehicle);
            
        }
    }
     class Drivers
    {
        public virtual int id { get; set; }
       public virtual string name { get; set;}
        public virtual string surname { get; set; }
        public virtual int age { get; set; }
        public virtual int salary { get; set; }
        public virtual string numberPH { get; set;}
        public virtual string OterInfo { get; set; }
        public virtual Vehicle ID_Vehicle { get; set; }

    }

     class Accidents
    {
        public virtual int id { get; set; }
        public virtual IList<Vehicle> VEhicle_id { get; set; }
        public virtual string details { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-3}\t\t{1,-3}\t\t{2,-3}", id, VEhicle_id, details);
        }
    }

     class AccidentMap : ClassMap<Accidents>
    {
        AccidentMap()
        {
            Id(x => x.id).Column("Id").GeneratedBy.Identity();
            HasMany(x => x.VEhicle_id).Inverse();
            Map(x => x.details);
        }
    }

     class RoutePopularity
    {
        public virtual int id { get; set;}
        public virtual Routes route_id { get; set; }
        public virtual int points { get; set; }
    }

     class RoutePopulariryMap : ClassMap<RoutePopularity>
    {
        RoutePopulariryMap()
        {
            Id(x => x.id);
            References(x => x.route_id);
            Map(x => x.points).Not.Nullable().Default("0");
        }
    }









    class usersMap: ClassMap<users>
    {
        usersMap()
        {
            Id(x => x.id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable() ;
            Map(x => x.age);
            Map(x => x.phone);
            Map(x => x.info);
        }

    }
    class users
    {
        public virtual int id { get; set; }
        public virtual string name { get; set; }
        public virtual string surname { get; set; }
        public virtual int age { get; set; }
        public virtual string phone { get; set; }
        public virtual string info { get; set; }
    }

    class UserRatingMap : ClassMap<UserRating>
    {
        UserRatingMap()
        {
            Id(x => x.id);
            Map(x => x.points);
            References(x => x.userID).Not.Nullable().Cascade.All();
        }
    }
    class UserRating
    {
        public virtual int id { get; set; }
        public virtual int points { get; set; }
        public virtual users userID { get; set; }
    }




}
