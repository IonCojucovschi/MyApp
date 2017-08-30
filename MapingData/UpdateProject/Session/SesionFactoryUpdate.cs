using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Diagnostics;

using System.Diagnostics;

namespace UpdateProject.Domain
{
    public static class SesionFactoryUpdate
    {
        private static ISessionFactory _sessionFactory;
        private const string conSTR = @"Data Source=MDDSK40069;Initial Catalog=Customers;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static ISession GetSession()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = InitializeSessionFactory();
            }
            return _sessionFactory.OpenSession();
        }



        private static ISessionFactory InitializeSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(conSTR).ShowSql())
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(Drivers).Assembly))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(false, true);
                    cfg.SetInterceptor(new SqlStatementInterceptor());
                });

            return configuration.BuildSessionFactory();
        }

        public class SqlStatementInterceptor : EmptyInterceptor
        {
            public override NHibernate.SqlCommand.SqlString OnPrepareStatement(NHibernate.SqlCommand.SqlString sql)
            {
                Trace.WriteLine(sql.ToString());
                return sql;
            }
        }


    }
}
