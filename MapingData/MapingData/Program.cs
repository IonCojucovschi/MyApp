using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate;
using MapingData.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace MapingData
{
  internal   class Program
    {
                  #region [elements]
        private static String[] names =
     {
          "IOn", "Nicolai", "Petru", "Claudiu", "Eugen", "Razvan",
          "Mike", "Marck","Miroslav","Vladislav","Miron","MArius","Cristian","Elena",
          "Irina","Rebecca","Mille","Emily","Joe","LAra","Fabian","Milla","Sara","Miguel","Mircea","Mihai","MArius"
      };

        private static string[] surnames =
        {
          "BAlanescu", "Neculce", "Ilienco", "Balconschi", "Niculencu", "Munteanu",
          "Papusoi", "Lupu", "Lungu", "LAzarev", "Lisa", "Lavrov", "Liscu", "Dimicenco", "Popas",
              "Adamenco","Mologin","Risina","Mamedov","Lazarenco","Cozariuc","Stepanov","Popescu"
      };

        private static string[] Models = { "Mercedes", "Ford", "Iveco", "Woltsvagen", "Opel" };

        private static string[] info = { "", "HAve higg study", "Make a good job", "Create a party " };

        private static string[] routes = { "123", "154", "140", "120", "132", "180", "191", "166", "135", "121" };
#endregion
        private static void Main(string[] args)
        {
            #region[Add Data]
            //using (var session = SesionFactoryMapin.OpenSession())
            //{
            //    using (var transaction = session.BeginTransaction())
            //    {
            //        List<Routes> Rutes1 = new List<Routes>();
            //        List<Vehicle> Vehicles = new List<Vehicle>();
            //        List<Drivers> drivers1 = new List<Drivers>();
            //        List<RoutePopularity> pop = new List<RoutePopularity>();
            //        List<users> users = new List<users>();
            //        List<UserRating> ratUsr = new List<UserRating>();
            //        Random r = new Random();
            //        try
            //        {
            //            for (int i = 0; i < 120; i++)
            //            {
            //                users.Add(new users
            //                {
            //                    name = names[r.Next(names.Length)],
            //                    surname = surnames[r.Next(surnames.Length)],
            //                    age = 10 + r.Next(50),
            //                    phone = "0792231" + i,
            //                    info = "No have information",
            //                });
            //                users a = new users();
            //                a = users[i];
            //                session.Save(a);
            //            }
            //            for (int i = 0; i < 120; i++)
            //            {
            //                ratUsr.Add(new UserRating
            //                {
            //                    userID = users[i],
            //                    points = r.Next(700),

            //                });
            //                UserRating a = new UserRating();
            //                a = ratUsr[i];
            //                session.Save(a);
            //            }




            //            for (int i = 0; i < routes.Length; i++)
            //            {
            //                Rutes1.Add(new Routes { name = routes[i], curse = "Not Have Info", oterInfor = "No have information" });
            //                Routes a = new Routes();
            //                a = Rutes1[i];
            //                session.Save(a);

            //            }
            //            for (int i = 0; i < routes.Length; i++)
            //            {
            //                pop.Add(new RoutePopularity { route_id = Rutes1[i], points = r.Next(2000) });
            //                RoutePopularity a = new RoutePopularity();
            //                a = pop[i];
            //                session.Save(a);
            //            }


            //            for (int i = 0; i < 60; i++)
            //            {
            //                Vehicles.Add(new Vehicle { model = Models[r.Next(Models.Length)], carNumber = "TAXI-" + i + "CH", Route = Rutes1[r.Next(routes.Length)] });
            //                Vehicle a = new Vehicle();
            //                a = Vehicles[i];
            //                session.Save(a);

            //            }
            //            for (int i = 0; i < 120; i++)
            //            {
            //                drivers1.Add(new Drivers
            //                {
            //                    name = names[r.Next(names.Length)],
            //                    surname = surnames[r.Next(surnames.Length)],
            //                    age = 20 + r.Next(15),
            //                    ID_Vehicle = Vehicles[r.Next(59)],
            //                    salary = 5000 + r.Next(3000),
            //                    OterInfo = "none"
            //                });
            //                Drivers a = new Drivers();
            //                a = drivers1[i];
            //                session.Save(a);

            //            }
            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }
            //    }
            //}
            #endregion

            using (var session = SesionFactoryUpdate.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    /// delete driver with id=10
                    var driver = session.Get<Drivers>(10);
                    session.Delete(driver);

                    transaction.Commit();
                }

                using (var tran = session.BeginTransaction())
                {
                    //update dtriver with id = 11
                    var driver11 = session.Get<Drivers>(11);
                    driver11.name = "Grisha";
                    driver11.surname = "Budeci";
                    tran.Commit();
                }


            }






            Console.ReadKey();
        }
    }
}
