using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class MenadzerMap : SubclassMap<FarmacyLibrary.Entiteti.Menadzer>
    {
        public MenadzerMap()
        {
            Table("Menadzer");
            KeyColumn("id");
        }
    }
}
