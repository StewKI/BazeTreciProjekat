using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class IsporukaMap : ClassMap<Isporuka>
    {
        public IsporukaMap()
        {
            Table("Isporuka");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            References(x => x.Distributer, "distributer_id").Not.Nullable();
            References(x => x.ProdajnaJedinica, "prodajna_jedinica_id").Not.Nullable();
            Map(x => x.Datum, "datum").CustomType("date").Not.Nullable();
            References(x => x.Magacioner, "magacioner_mbr").Nullable();

            HasMany(x => x.Stavke).KeyColumn("isporuka_id").Inverse().Cascade.All();
        }
    }
}
