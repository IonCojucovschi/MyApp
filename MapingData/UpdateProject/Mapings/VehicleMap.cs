using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.id);
            Map(x => x.model);
            Map(x => x.carNumber);
            References(x => x.Route);

        }
    }
}
