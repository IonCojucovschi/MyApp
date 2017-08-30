using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class AccidentMap : ClassMap<Accidents>
    {
        AccidentMap()
        {
            Id(x => x.id).Column("Id").GeneratedBy.Identity();
            HasMany(x => x.ID_VEhicle).Inverse();
            Map(x => x.details);
        }
    }
}
