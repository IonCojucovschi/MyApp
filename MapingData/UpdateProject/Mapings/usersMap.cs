using FluentNHibernate.Mapping;


namespace MapingData.Domain
{
    class usersMap : ClassMap<Users>
    {
        usersMap()
        {
            Id(x => x.id);
            Map(x => x.name).Not.Nullable();
            Map(x => x.surname).Not.Nullable() ;
            Map(x => x.age);
            Map(x => x.phone);
            Map(x => x.info);
        }

    }




}
