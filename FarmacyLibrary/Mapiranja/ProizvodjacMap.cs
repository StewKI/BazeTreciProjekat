using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ProizvodjacMap : ClassMap<Proizvodjac>
    {
        public ProizvodjacMap()
        {
            Table("Proizvodjac");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            Map(x => x.Naziv, "naziv").Not.Nullable();
            Map(x => x.Zemlja, "zemlja").Not.Nullable();
            Map(x => x.Telefon, "telefon");
            Map(x => x.Email, "email");
            HasMany(x => x.Lekovi).KeyColumn("proizvodjac_id").Inverse();
        }
    }
}
