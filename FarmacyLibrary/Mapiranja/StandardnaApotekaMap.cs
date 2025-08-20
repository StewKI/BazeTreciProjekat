using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class StandardnaApotekaMap : SubclassMap<StandardnaApoteka>
    {
        public StandardnaApotekaMap()
        {
            Table("Standardna_apoteka");
            KeyColumn("id");
            Map(x => x.Napomena, "napomena");
        }
    }
}
