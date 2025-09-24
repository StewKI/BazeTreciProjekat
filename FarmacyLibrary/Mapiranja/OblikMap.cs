using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class OblikMap : ClassMap<Oblik>
    {
        public OblikMap()
        {
            Table("Oblik");
            Id(x => x.Id)
            .Column("id")
            .GeneratedBy.Sequence("oblik_leka_seq");
            Map(x => x.Naziv, "naziv").Not.Nullable().Unique();
        }
    }
}
