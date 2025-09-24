using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class SekundarnaKategorijaMap : ClassMap<SekundarnaKategorija>
    {
        public SekundarnaKategorijaMap()
        {
            Table("Sekundarna_kategorija");
            Id(x => x.Id)
           .Column("id")
           .GeneratedBy.Sequence("SEKUNDARNA_KATEGORIJA_SEQ");
            Map(x => x.Naziv, "naziv").Not.Nullable().Unique();
        }
    }
}
