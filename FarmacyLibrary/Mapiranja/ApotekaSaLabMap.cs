using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ApotekaSaLabMap : SubclassMap<ApotekaSaLab>
    {
        public ApotekaSaLabMap()
        {
            Table("Apoteka_sa_lab");
            KeyColumn("id");
            Map(x => x.Napomena, "napomena");
        }
    }
}
