using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class LekMap : ClassMap<Lek>
    {
        public LekMap()
        {
            Table("Lek");
            Id(x => x.Id, "ID")
    .GeneratedBy.Sequence("SEQ_LEK_ID");
            Map(x => x.HemijskiNaziv, "hemijski_naziv").Not.Nullable().Unique();
            Map(x => x.KomercijalniNaziv, "komercijalni_naziv").Not.Nullable();
            Map(x => x.Dejstvo, "dejstvo");

            References(x => x.Proizvodjac, "proizvodjac_id").Not.Nullable();
            References(x => x.PrimarnaGrupa, "primarna_grupa_id").Not.Nullable();

            HasMany(x => x.Pakovanja).KeyColumn("lek_id").Inverse().Cascade.All();
            HasMany(x => x.Sekundarne).KeyColumn("lek_id").Inverse().Cascade.All();
        }
    }
}
