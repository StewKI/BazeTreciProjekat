using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class DistributerMap : ClassMap<Distributer>
    {
        public DistributerMap()
        {
            Table("Distributer");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Naziv, "naziv").Not.Nullable();
            Map(x => x.Kontakt, "kontakt");
        }
    }
}
