using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class RasporedRadaMap : ClassMap<RasporedRada>
    {
        public RasporedRadaMap()
        {
            Table("Raspored_rada");

            // Složeni primarni ključ = (m_br, prodajna_jedinica_id, pocetak)
            CompositeId()
                .KeyReference(x => x.Zaposleni, "m_br")
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
