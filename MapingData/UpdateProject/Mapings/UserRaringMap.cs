using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpdateProject.Domain;

namespace UpdateProject.Mapings
{
    class UserRatingMap : ClassMap<UserRating>
    {
        UserRatingMap()
        {
            Id(x => x.id);
            Map(x => x.points);
            References(x => x.userID).Not.Nullable().Cascade.All();
        }
    }
}
