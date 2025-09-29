using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace FarmacyLibrary.Mapiranja
{
    public class ProdajaMap : ClassMap<Prodaja>
    {
        public ProdajaMap()
        {
            Table("Prodaja");

            Id(x => x.Id, "id").GeneratedBy.Sequence("PRODAJA_SEQ");

            References(x => x.ProdajnaJedinica, "prodajna_jedinica_id").Not.Nullable();

            Map(x => x.DatumVreme, "datum_vreme")
                .CustomType<TimestampType>()
                .Not.Nullable();

            References(x => x.Blagajnik, "blagajnik_id").Nullable();

            HasMany(x => x.Stavke)
                .KeyColumn("prodaja_id")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
