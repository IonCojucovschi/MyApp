using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.DataFormat;
using UpdateProject.Domain;

namespace UpdateProject.Repository
{
    public interface IDriverRepository
    {
        IList<Drivers> GetAll();
        IList<Drivers> GetDriverByFirstNAme(string firstname);
        IList<Drivers> GetDriverByID(int id);
        IList<dataFormat1> DriverNum_vehNum_forRoute();
        IList<dataFormat2> Driver_Veh();
        IList<dataFormat3> Driver_veh_route();
        IList<dataFormat4> Number_Driver_For_Route();
        IList<dataFormat5> GroupCarByRoutes();
        //IList<dataFormat6> DriverSubQueryCondition();
         void DriverSubQueryCondition2();
         IList<dataFormat6> NEwSubQuery();

    }
    public class DriverRepository : IDriverRepository
    {
        private readonly ISession _session;
        public DriverRepository(ISession session)
        {
            _session = session;
        }
        public IList<dataFormat1> DriverNum_vehNum_forRoute()
        {
            Drivers driver = null;
            Routes route = null;
            Vehicle vehicle = null;
            dataFormat1 row = null;

            IList<dataFormat1> ses = _session.QueryOver<Drivers>(() => driver).
                 Left.JoinAlias(() => driver.ID_Vehicle, () => vehicle).
                 Left.JoinAlias(() => vehicle.Route, () => route).
                 SelectList(list => list
                      .SelectCount(() => driver.id)
                      .SelectCount(() => vehicle.id)
                     ).TransformUsing(Transformers.AliasToBean<dataFormat1>()).
                 List<dataFormat1>();
            //SELECT count(this_.id) as y0_, count(vehicle1_.id) as y1_ FROM[Drivers] this_
            // left outer join[Vehicle] vehicle1_ on this_.ID_Vehicle_id = vehicle1_.id
            // left outer join[Routes] route2_ on vehicle1_.Route_id = route2_.id

            return ses;
        }
        public IList<dataFormat2> Driver_Veh()
        {
            Drivers driver=null;
            Vehicle vehicle = null;
            dataFormat2 data2 = null;
            return _session.QueryOver<Drivers>(() => driver).
               JoinAlias(() => driver.ID_Vehicle, () => vehicle).
               SelectList(list => list.Select(x => x.name).WithAlias(() => data2.name).
               Select(x => x.surname).WithAlias(() => data2.surname).
               Select(() => vehicle.model).WithAlias(() => data2.vehicleModel).
               Select(() => vehicle.carNumber).WithAlias(() => data2.vehNum)
                ).TransformUsing(Transformers.AliasToBean<dataFormat2>()).List<dataFormat2>();
                //SELECT this_.name as y0_, this_.surname as y1_, vehicle1_.model as y2_, vehicle1_.carNumber as y3_
                //FROM[Drivers] this_
                //inner join[Vehicle] vehicle1_ on this_.ID_Vehicle_id = vehicle1_.id
         }
        public IList<dataFormat3> Driver_veh_route()
        { Drivers driver = null;
            Vehicle veh = null;
            Routes rout = null;

            dataFormat3 dataf3 = null;

            return _session.QueryOver<Drivers>(() => driver).
                JoinAlias(() => driver.ID_Vehicle, () => veh).
                JoinAlias(() => veh.Route, () => rout).SelectList(list => list.
                     Select(x => x.name).WithAlias(() => dataf3.name).
                     Select(x => x.surname).WithAlias(() => dataf3.surname).
                     Select(() => veh.model).WithAlias(() => dataf3.vehicleModel).
                     Select(() => rout.name).WithAlias(() => dataf3.routeName)).
                TransformUsing(Transformers.AliasToBean<dataFormat3>()).List<dataFormat3>();
                //SELECT this_.name as y0_, this_.surname as y1_, vehicle1_.model as y2_, vehicle1_.carNumber as y3_
                //FROM[Drivers] this_
                //inner join[Vehicle] vehicle1_ on this_.ID_Vehicle_id = vehicle1_.id


        }
        public IList<dataFormat4> Number_Driver_For_Route()
        {
            Drivers driver = null;
            Vehicle veh = null;
            Routes rout = null;
            dataFormat4 dataf4 = null;
            return _session.QueryOver<Drivers>(() => driver).
                JoinAlias(() => driver.ID_Vehicle, () => veh).
                JoinAlias(() => veh.Route, () => rout).SelectList(list => list.
                SelectCount(()=>driver.id).WithAlias(()=>dataf4.number).
                SelectGroup(()=>rout.name).WithAlias(()=>dataf4.routeName)).
                TransformUsing(Transformers.AliasToBean<dataFormat4>()).List<dataFormat4>();
                //SELECT count(this_.id) as y0_, rout2_.name as y1_
                //FROM[Drivers] this_
                //inner join[Vehicle] veh1_ on this_.ID_Vehicle_id = veh1_.id
                //inner join[Routes] rout2_ on veh1_.Route_id = rout2_.id
                //group by rout2_.name
         }
        public IList<dataFormat5> GroupCarByRoutes()
        {
            Drivers driver = null;
            Vehicle veh = null;
            Routes rout = null;
            dataFormat5 dataf5 = null;

            return _session.QueryOver(() => driver).
                JoinAlias(() => driver.ID_Vehicle, () => veh).
                JoinAlias(() => veh.Route, () => rout).SelectList(list => list.
                    SelectCount(() => driver.id).WithAlias(() => dataf5.number).
                    SelectGroup(() => rout.name).WithAlias(() => dataf5.routeName)).
                TransformUsing(Transformers.AliasToBean<dataFormat5>()).List<dataFormat5>();



        }
        public IList<Drivers> GetAll()
        {
            return _session.QueryOver<Drivers>().List();

        }
        public IList<Drivers> GetDriverByFirstNAme(string firstname)
        {
            return _session.QueryOver<Drivers>()
                .Where(c => c.name == firstname).List();
        }
        public IList<Drivers> GetDriverByID(int id)
        {
            return _session.QueryOver<Drivers>()
                .Where(x => x.id == id).List();
        }

        public void DriverSubQueryCondition2()
        {
            Drivers driver = null;
            Vehicle veh = null;
            Routes rout = null;

            var query1 = _session.QueryOver(() => veh)
                .Where(x => x.Route.IsBetween(2).And(4))
                .Select(x => x.id).List<int>();

            Console.WriteLine("ok");


            var DrSubQuery = _session.QueryOver(() => driver)
                .JoinAlias(() => driver.ID_Vehicle, () => veh)
                //.Where(() => veh.Route.IsBetween(2).And.(12))//IsIn(query1))
                .Select(x => x.salary).List<int>();

        }

        //////////////////////////////////////////////////////////////

        public IList<dataFormat6> NEwSubQuery()
        {
            Drivers dr = null;
            Vehicle vh = null;
            dataFormat6 dat = null;

            var subguery = QueryOver.Of<Routes>()
                                .Select(r => r.id)
                                .Where(Restrictions.Between(
                                    Projections.Property<Routes>(r => r.id), "10", "30"));

            var subquery2 = QueryOver.Of<Vehicle>()
                            .Select(v => v.id)
                            .WithSubquery
                            .WhereProperty(v => v.Route.id).In(subguery);

            
            var a = _session.QueryOver(() => dr)
                .SelectList(list => list
                    .Select(() => dr.name).WithAlias(() => dat.name)
                    .Select(() => dr.salary).WithAlias(() => dat.salary))
                .WithSubquery
                .WhereProperty(() => dr.ID_Vehicle).In(subquery2)
                .TransformUsing(Transformers.AliasToBean<dataFormat6>())
                .List<dataFormat6>();

            return a;            
        }
    }
}
