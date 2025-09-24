using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace FarmacyLibrary.Mapiranja
{
    public class RadnoVremeMap : ClassMap<RadnoVreme>
    {
        public RadnoVremeMap()
        {
            Table("Radno_vreme");

            CompositeId()
                .KeyReference(x => x.ProdajnaJedinica, "prodajna_jedinica_id")
                .KeyProperty(x => x.Dan, "dan");

            Map(x => x.VremeOd, "vreme_od")
                .Not.Nullable()
                .CustomType<DateTimeType>()
                .CustomSqlType("timestamp");

            Map(x => x.VremeDo, "vreme_do")
                .Not.Nullable()
                .CustomType<DateTimeType>()
                .CustomSqlType("timestamp");
        }
    }
}
