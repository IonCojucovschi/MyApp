using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class RoutePopulariryMap : ClassMap<RoutePopularity>
    {
        RoutePopulariryMap()
        {
            Id(x => x.id);
            References(x => x.route_id);
            Map(x => x.points).Not.Nullable().Default("0");
        }
    }
}
