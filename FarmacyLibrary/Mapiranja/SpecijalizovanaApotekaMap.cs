using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class SpecijalizovanaApotekaMap : SubclassMap<SpecijalizovanaApoteka>
    {
        public SpecijalizovanaApotekaMap()
        {
            Table("Specijalizovana_apoteka");
            KeyColumn("id");
            Map(x => x.SpecijalnostTipa, "specijalnost_tipa");
            Map(x => x.Napomena, "napomena");
        }
    }
}
