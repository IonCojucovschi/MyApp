using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MapingData.Domain
{
   public class SesionFactoryMapin
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get { if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                 .Database(MsSqlConfiguration.MsSql2012
                 .ConnectionString(@"Data Source=MDDSK40069;Initial Catalog=Customers;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
                 .ShowSql()).Mappings(m => m.FluentMappings
                 .AddFromAssemblyOf<Routes>())
                 .ExposeConfiguration(cfg=>new SchemaExport(cfg).Create(true,true))
                 .BuildSessionFactory(); 
            }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }


    }
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
            References(x => x.Route).Cascade.All();
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
            References(x => x.ID_Vehicle).Cascade.All();
            
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
