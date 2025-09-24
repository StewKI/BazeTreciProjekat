using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace FarmacyLibrary.Mapiranja
{
    public class MenadzerApotekaMap : ClassMap<MenadzerApoteka>
    {
        public MenadzerApotekaMap()
        {
            Table("Menadzer_Apoteka");

            CompositeId()
                .KeyReference(x => x.Menadzer, "m_br_menadzera")
                .KeyReference(x => x.ProdajnaJedinica, "prodajna_jedinica_id")
                .KeyProperty(x => x.Od, "od").CustomType<DateType>();

            Map(x => x.Do, "do").CustomType<DateType>().Nullable();

            Map(x => x.datumKontrole, "datum_kontrole").CustomType<DateType>().Nullable();

        }
    }
}
