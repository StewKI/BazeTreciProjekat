using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class IsporukaStavkaMap : ClassMap<IsporukaStavka>
    {
        public IsporukaStavkaMap()
        {
            Table("Isporuka_stavka");

            CompositeId()
                .KeyReference(x => x.Isporuka, "isporuka_id")
                .KeyReference(x => x.Pakovanje, "pakovanje_id");

            Map(x => x.Kolicina, "kolicina").Not.Nullable();
        }
    }
}
