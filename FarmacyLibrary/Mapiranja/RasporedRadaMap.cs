using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class RasporedRadaMap : ClassMap<RasporedRada>
    {
        public RasporedRadaMap()
        {
            Table("Raspored_rada");

            CompositeId()
                .KeyReference(x => x.Zaposleni, "id_zaposlenog")
                .KeyReference(x => x.ProdajnaJedinica, "prodajna_jedinica_id")
                .KeyProperty(x => x.Pocetak, "pocetak");

            Map(x => x.Kraj)
                .Column("kraj")
                .Not.Nullable();

            Map(x => x.BrojSmene)
                .Column("broj_smene")
                .Nullable();
        }
    }
}
