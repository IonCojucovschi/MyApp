using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class RoutesMap : ClassMap<Routes>
    {
        public RoutesMap()
        {
            Id(x => x.id);
            Map(x => x.name);
            Map(x => x.curse);
            Map(x => x.oterInfor);
            HasMany<Vehicle>(s => s.VehID);
        }

    }
}
