using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class TehnicarMap : SubclassMap<Tehnicar>
    {
        public TehnicarMap()
        {
            Table("Tehnicar");
            KeyColumn("id");
            Map(x => x.NivoObrazovanja, "nivo_obrazovanja").Not.Nullable();
        }
    }
}
