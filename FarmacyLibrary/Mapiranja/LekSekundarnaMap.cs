using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class LekSekundarnaMap : ClassMap<LekSekundarna>
    {
        public LekSekundarnaMap()
        {
            Table("Lek_Sekundarna");

            CompositeId()
                .KeyReference(x => x.Lek, "lek_id")
                .KeyReference(x => x.Kategorija, "kategorija_id");

        }
    }
}
