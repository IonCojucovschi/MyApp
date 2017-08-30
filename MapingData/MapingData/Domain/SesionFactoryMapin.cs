using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


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




}
