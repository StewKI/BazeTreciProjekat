using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class FarmaceutMap : SubclassMap<FarmacyLibrary.Entiteti.Farmaceut>
    {
        public FarmaceutMap()
        {
            Table("Farmaceut");
            KeyColumn("id");

            Map(x => x.DatumDiplomiranja, "datum_diplomiranja").CustomType("date").Not.Nullable();
            Map(x => x.BrLicence, "br_licence").Not.Nullable().Unique();
            Map(x => x.DatumPoslObnoveLicence, "datum_poslednje_obnove_licence").CustomType("date").Not.Nullable();
            Map(x => x.Specijalnost, "specijalnost");
        }
    }
}
