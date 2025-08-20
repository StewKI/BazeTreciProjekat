using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class MenadzerMap : SubclassMap<Menadzer>
    {
        public MenadzerMap()
        {
            Table("Menadzer");
            KeyColumn("m_br");
        }
    }
}
