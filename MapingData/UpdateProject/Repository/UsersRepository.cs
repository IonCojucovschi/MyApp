using NHibernate;
using UpdateProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateProject.Repository
{
    interface iUsersRepository
    {
        IList<Users> GetAll();
    }
    class UsersRepository:iUsersRepository
    {
        private readonly ISession _session;
        public UsersRepository(ISession session)
        {
            _session = session;
        }

        public IList<Users> GetAll()
        {
            return _session.QueryOver<Users>().List();
        }
    }
}
