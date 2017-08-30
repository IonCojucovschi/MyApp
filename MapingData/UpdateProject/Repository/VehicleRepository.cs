using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.DataFormat;
using UpdateProject.Domain;

namespace UpdateProject.Repository
{
    interface IVehicleRepository
    {
        IList<Vehicle> GetAll();
        IList<dataFormat4> num_Driver_For_VEhicle_Model();
        void FuruteQuery();
        IList<Vehicle> Find_vehicle_popular_Routes();
        IList<dataFormat7> NUmDriverForVehicleModel();
        IList<dataFormat7> AnySubQuery();

    }


    class VehicleRepository:IVehicleRepository
    {
        private readonly ISession _session;
        public VehicleRepository(ISession session)
        {
            _session = session;
        }
        public IList<dataFormat7> AnySubQuery()
        {
            Vehicle veh = null;
            Routes rout = null;
            dataFormat7 data = null;

            var qr1 = QueryOver.Of<Routes>().Select(x => x.name)
                .Where(Restrictions.Between(Projections.Property<Routes>(x => x.id), "5", "9"));


            var a = _session.QueryOver<Vehicle>(() => veh)
                .JoinAlias(() => veh.Route, () => rout)
                .SelectList(list => list
                .SelectCount(() => veh.id).WithAlias(() => data.number)
                .SelectGroup(() => rout.name).WithAlias(() => data.type))
                .WithSubquery.WhereProperty(()=>rout.name).In(qr1)               
              .TransformUsing(Transformers.AliasToBean<dataFormat7>()).List<dataFormat7>();



            return a;
//select count(Vehicle.id),Routes.name
//from vehicle
//inner join routes on vehicle.Route_id = Routes.id
//group by routes.name
//having Routes.name = any(select name from routes where routes.id between 5 and 9)
        }
        public IList<dataFormat7> NUmDriverForVehicleModel()
        {
            Drivers dri = null;
            Vehicle veh = null;
            dataFormat7 data = null;
            var qr1 = QueryOver.Of<Drivers>(() => dri).JoinAlias(() => dri.ID_Vehicle, () => veh)
                .SelectList(list => list.SelectGroup(() => veh.model))//.List<string>();
                .Where(Restrictions.Gt(Projections.Count(Projections.Property<Drivers>(x => x.id)), 23));
            /// conform db vehicle not se driver de asta mereu pornim de la driver
            var a = _session.QueryOver<Drivers>().
                JoinAlias(x => x.ID_Vehicle, () => veh).SelectList(list => list
                .SelectCount(x=>x.id).WithAlias(() => data.number)
                .SelectGroup(() => veh.model).WithAlias(() => data.type))
                .WithSubquery.WhereProperty(()=>veh.model).In(qr1)
                .TransformUsing(Transformers.AliasToBean<dataFormat7>()).List<dataFormat7>();
               
          // var  a =new List<dataFormat4>();
            return a;

//exec sp_executesql
//N'SELECT count(this_.id) as y0_, veh1_.model as y1_ 
//FROM[Drivers] this_
//inner join[Vehicle] veh1_ on this_.ID_Vehicle_id = veh1_.id
//WHERE veh1_.model in (SELECT veh1_.model as y0_ FROM[Drivers] this_0_
//                      inner join[Vehicle] veh1_ on this_0_.ID_Vehicle_id = veh1_.id

//                       GROUP BY veh1_.model HAVING count(this_0_.id) > @p0) 
//GROUP BY veh1_.model',N'@p0 int',@p0=23

        }

        public IList<Vehicle> Find_vehicle_popular_Routes()
        {
            Vehicle veh = null;
            Routes rout = null;
            Vehicle data6 = null;
            RoutePopularity pop = null;
            var subquery = QueryOver.Of<RoutePopularity>().
                         Select(p => p.route_id).
                         Where(Restrictions.Gt(Projections.
                         Property<RoutePopularity>(p => p.points), 1000));

            var subquery2 = QueryOver.Of<Routes>().
                          Select(r => r.id).
                          WithSubquery.WhereProperty(r => r.id).In(subquery);

            var a= _session.QueryOver(() => veh).
                SelectList(list => list.
                    Select(() => veh.id).WithAlias(() => data6.id).
                    Select(() => veh.model).WithAlias(() => data6.model).
                    Select(() => veh.carNumber).WithAlias(() => data6.carNumber)).
                            WithSubquery.WhereProperty(() => veh.Route).In(subquery2).
                            TransformUsing(Transformers.AliasToBean<Vehicle>()).List<Vehicle>();
            return a;
//Select Vehicle.id,Vehicle.model, Vehicle.carNumber
//from vehicle
//where vehicle.Route_id in (select Routes.id
//                           from Routes
//                           where Routes.id in (select RoutePopularity.route_id_id
//                                               from RoutePopularity
//                                               where RoutePopularity.points > 1000))

        }

        public void FuruteQuery()
        {
            Vehicle veh = null;
            Routes rou = null;
            using (var ab=_session.BeginTransaction()) {
                try
                {
                    var a = _session.CreateCriteria<Vehicle>().Future<Vehicle>();

                    Drivers driver = null;
                    Vehicle vehicle = null;

                    dataFormat4 dataf4 = null;
                    var b= _session.QueryOver<Drivers>(() => driver).
                        JoinAlias(() => driver.ID_Vehicle, () => vehicle).
                      SelectList(list => list.
                        SelectCount(() => driver.id).WithAlias(() => dataf4.number).
                        SelectGroup(() => vehicle.model).WithAlias(() => dataf4.routeName)).
                        Where(Restrictions.Gt(Projections.Count(Projections.Property(() => driver.id)), 30)).
                        TransformUsing(Transformers.AliasToBean<dataFormat4>()).FutureValue<dataFormat4>();

                    var c = b.Value;
                    Console.WriteLine("IS Commited!!!");
                }
                catch (Exception ex) { Console.WriteLine("error: {0} ",ex.Message); }

            }
        }

        public IList<Vehicle> GetAll()
        {
            Vehicle a = null;
            return _session.QueryOver<Vehicle>().TransformUsing(Transformers.DistinctRootEntity).List();
        }

        public IList<dataFormat4> num_Driver_For_VEhicle_Model()
        {
            Drivers driver = null;
            Vehicle veh = null;
           
            dataFormat4 dataf4 = null;

            return _session.QueryOver<Drivers>(() => driver).
                JoinAlias(() => driver.ID_Vehicle, () => veh).
              SelectList(list => list.
                SelectCount(() => driver.id).WithAlias(() => dataf4.number).
                SelectGroup(()=>veh.model).WithAlias(() => dataf4.routeName)).
                Where(Restrictions.Gt(Projections.Count(Projections.Property(() =>driver.id)),30)).
                TransformUsing(Transformers.AliasToBean<dataFormat4>()).List<dataFormat4>();
                //exec sp_executesql N'SELECT count(this_.id) as y0_, veh1_.model as y1_ 
                //FROM[Drivers] this_
                //inner join[Vehicle] veh1_ on this_.ID_Vehicle_id = veh1_.id
                //GROUP BY veh1_.model
                //HAVING count(this_.id) > @p0',N'@p0 int',@p0=30
        }
    }
}
