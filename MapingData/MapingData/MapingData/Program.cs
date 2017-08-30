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
        private static String[] names =
     {
          "IOn", "Nicolai", "Petru", "Claudiu", "Eugen", "Razvan",
          "Mike", "Marck","Miroslav","Vladislav","Miron","MArius","Cristian","Elena",
          "Irina","Rebecca","Mille","Emily","Joe"
      };

        private static string[] surnames =
        {
          "BAlanescu", "Neculce", "Ilienco", "Balconschi", "Niculencu", "Munteanu",
          "Papusoi", "Lupu", "Lungu", "LAzarev", "Lisa", "Lavrov", "Liscu", "Dimicenco", "Popas",
              "Adamenco",
          "Mologin"
      };

        private static string[] Models = { "Mercedes", "Ford", "Iveco", "Woltsvagen", "Opel" };

        private static string[] info = { "", "HAve higg study", "Make a good job", "Create a party " };

        private static string[] routes = { "123", "154", "140", "120", "132", "180", "191", "166", "135", "121" };

        private static void Main(string[] args)
        {
            using (var session= SesionFactoryMapin.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    List<Routes> Rutes1 = new List<Routes>();
                    List<Vehicle> Vehicles = new List<Vehicle>();
                    List<Drivers> drivers1 = new List<Drivers>();
                    Random r = new Random();
                    try
                    {
                        for (int i = 0; i < routes.Length; i++)
                        {
                            Rutes1.Add(new Routes { name = routes[i], curse = "Not Have Info", oterInfor = "No have information" });
                            Routes a = new Routes();
                            a = Rutes1[i];
                            session.Save(a);
                           
                        }
                        for (int i = 0; i < 60; i++)
                        {
                            Vehicles.Add(new Vehicle { model = Models[r.Next(Models.Length)], carNumber = "TAXI" + i + "CH", Route = Rutes1[r.Next(routes.Length)] });
                            Vehicle a = new Vehicle();
                            a = Vehicles[i];
                            session.Save(a);
                            
                        }
                        for (int i = 0; i < 120; i++)
                        {
                            drivers1.Add(new Drivers
                            {
                                name = names[r.Next(names.Length)],
                                surname = surnames[r.Next(surnames.Length)],
                                age = 20 + r.Next(15),
                                ID_Vehicle = Vehicles[r.Next(59)],
                                salary = 5000 + r.Next(3000),
                                OterInfo = "none"
                            });
                            Drivers a = new Drivers();
                            a = drivers1[i];
                            session.Save(a);
                            
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    #region [PAp by one]
                    //var rute = new Routes
                    //{
                    //    name = "123",
                    //    curse = "must be one string",
                    //    oterInfor = "No have oter information!"
                    //};
                    //var veh = new Vehicle
                    //{
                    //    model = "mercedes",
                    //    carNumber = "ooiu234ui",
                    //   Route=rute,

                    //};
                    //var Driver = new Drivers
                    //{
                    //    name = "Miron",
                    //    surname = "Andrian",
                    //    age = 30,
                    //    ID_Vehicle=veh,


                    //};
                    //var userr = new users
                    //{
                    //    name = "Ion",
                    //    surname = "Cojucovschi",
                    //    age = 23,
                    //    phone="079227743",
                    //    info="None" 
                    //};
                    //var ratig = new UserRating
                    //{
                    //    points = 5000,
                    //    userID=userr,
                    //};

                    //session.Save(userr);
                    //session.Save(ratig);
                    //session.Save(rute);
                    //session.Save(veh);
                    //session.Save(Driver);
                    //transaction.Commit();
#endregion
                }
            }
            Console.ReadKey();
        }
    }
}
