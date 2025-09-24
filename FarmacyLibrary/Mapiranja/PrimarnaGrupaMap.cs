using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class PrimarnaGrupaMap : ClassMap<PrimarnaGrupa>
    {
        public PrimarnaGrupaMap()
        {
            Table("Primarna_grupa");
            Table("Primarna_grupa");
            Id(x => x.Id, "id").GeneratedBy.Sequence("SEQ_ZAPOSLENI_PRIMARNA_ID");
            Map(x => x.Naziv, "naziv").Not.Nullable().Unique();
        }
    }
}
