using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class DriversMap : ClassMap<Drivers>
    {
        public DriversMap()
        {
            Id(x => x.id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable();
            Map(x => x.age);
            Map(x => x.salary);
            Map(x => x.numberPH);
            Map(x => x.OterInfo);
            References(x => x.ID_Vehicle);

        }
    }
}
