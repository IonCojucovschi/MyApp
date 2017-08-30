using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.DataFormat;
using UpdateProject.Repository;

namespace UpdateProject
{
    internal class Program
    {
        private static IDriverRepository driverRepository;
        private static iUsersRepository userRepository;
        private static IVehicleRepository vehicleRepository;
        private static IRoutesRepository routeRepository;
     static Program()
        {
            var session = Domain.SesionFactoryUpdate.GetSession();
            driverRepository = new DriverRepository(session);
            vehicleRepository = new VehicleRepository(session);
            routeRepository = new RoutesRepository(session);
            userRepository = new UsersRepository(session);
        }
       
        #region [Private methods]

        private static void ShowAllDrivers()
        {
            try
            {
                var driver = driverRepository.GetAll();
                driver.PrintToConsole();

            }
            catch (NullReferenceException ex) { Console.WriteLine(ex.Message); }
        }
        private static void GetDriverByname(string name)
        {
            var drivers = driverRepository.GetDriverByFirstNAme(name);
            drivers.PrintToConsole();
        }
        private static void GetDriverNumVehicleNumber()
        {
            var dataform1 = driverRepository.DriverNum_vehNum_forRoute();
            dataform1.PrintToConsole();
        }
        private static void GetDriverByID(int i)
        {
            var driver = driverRepository.GetDriverByID(i);
            driver.PrintToConsole();
        }
        private static void GetDriver_AND_Vehicle()
        {
            var driVeh = driverRepository.Driver_Veh();
            driVeh.PrintToConsole();
        }
        private static void getDriver_Vehicle_Route()
        {
            var driversvehrout = driverRepository.Driver_veh_route();
            driversvehrout.PrintToConsole();
        }
        private static void numDriver_RouteName()
        {
            var numDriver_Routename = driverRepository.Number_Driver_For_Route();
            numDriver_Routename.PrintToConsole();
        }
        private static void ShowUserWith()
        {
            var driverList = (from element in driverRepository.GetAll()
                              where element.id > 20
                              select element);
            driverList.PrintToConsole();
        }


        private static void NumDriverForVEhicle()
        {
            var list = vehicleRepository.num_Driver_For_VEhicle_Model();
            list.PrintToConsole();
        }

        private static void Var()
        {
           driverRepository.DriverSubQueryCondition2();
           
        }
        private static void futureQr()
        {
            vehicleRepository.FuruteQuery();
        }
        private static void NEwSubQuery_1()
        {
            var a = driverRepository.NEwSubQuery();
            a.PrintToConsole();
        }
       private static void SubQueryFindVehicleByRoutePopularity()
        {
            var list = vehicleRepository.Find_vehicle_popular_Routes();
            list.PrintToConsole();
        }
        private static void DiriverWthCondition()
        {
            var list = vehicleRepository.NUmDriverForVehicleModel();
            list.PrintToConsole();
        }
        private static void AnyQueryInter()
        {
            var list = vehicleRepository.AnySubQuery();
            list.PrintToConsole();
        }
        #endregion

        private static void Main(string[] args)
        {



            ///ShowAllDrivers();
            ///GetDriverByname("Joe");
            // GetDriverNumVehicleNumber();
            //GetDriverByID(10);
            // GetDriver_AND_Vehicle();
            // getDriver_Vehicle_Route();
            //numDriver_RouteName();
            //ShowUserWith();
            //NumDriverForVEhicle();
            //Var();
            //futureQr();



            ///NEwSubQuery_1();
            //SubQueryFindVehicleByRoutePopularity();
            // DiriverWthCondition();
            AnyQueryInter();








            Console.ReadKey();
        }
    }
}
