using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class usersMap : ClassMap<Users>
    {
        usersMap()
        {
            Id(x => x.id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable();
            Map(x => x.age);
            Map(x => x.phone);
            Map(x => x.info);
        }

    }
}
