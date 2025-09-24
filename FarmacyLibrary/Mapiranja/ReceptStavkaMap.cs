using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ReceptStavkaMap : ClassMap<ReceptStavka>
    {
        public ReceptStavkaMap()
        {
            Table("Recept_stavka");

            // Composite key
            CompositeId()
                .KeyReference(x => x.Recept, "recept_ser_broj")
                .KeyReference(x => x.Pakovanje, "pakovanje_id");

            Map(x => x.Kolicina, "kolicina").Not.Nullable();
            Map(x => x.PreporucenaDoza, "preporucena_doza").Nullable();
        }
    }
}