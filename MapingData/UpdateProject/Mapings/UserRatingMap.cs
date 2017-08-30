using FluentNHibernate.Mapping;


namespace MapingData.Domain
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
