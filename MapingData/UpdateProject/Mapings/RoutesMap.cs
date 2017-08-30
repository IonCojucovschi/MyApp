using FluentNHibernate.Mapping;


namespace MapingData.Domain
{
    class RoutesMap : ClassMap<Routes>
    {
        public RoutesMap()
        {
            Id(x => x.id);
            Map(x => x.name);
            Map(x => x.curse);
            Map(x => x.oterInfor);
        }
    }




}
