using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ApotekaSaLabMap : SubclassMap<ApotekaSaLabBasic>
    {
        public ApotekaSaLabMap()
        {
            Table("Apoteka_sa_lab");
            KeyColumn("id");
            Map(x => x.Napomena, "napomena");
        }
    }
}
