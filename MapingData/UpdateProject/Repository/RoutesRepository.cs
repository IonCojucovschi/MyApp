using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Repository
{
    interface IRoutesRepository
    {
        IList<Routes> GetAll();
    }
    class RoutesRepository:IRoutesRepository
    {
        private readonly ISession _session;
        public RoutesRepository(ISession session)
        {
            _session = session;
        }

        public IList<Routes> GetAll()
        {
            return _session.QueryOver<Routes>().List();
        }
    }
}
