using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class MenadzerMap : SubclassMap<FarmacyLibrary.Entiteti.MenadzerBasic>
    {
        public MenadzerMap()
        {
            Table("Menadzer");
            KeyColumn("m_br");
        }
    }
}
