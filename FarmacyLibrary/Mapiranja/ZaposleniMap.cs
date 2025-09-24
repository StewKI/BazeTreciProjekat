using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ZaposleniMap : ClassMap<Zaposleni>
    {
        public ZaposleniMap()
        {
            Table("Zaposleni");
            Id(x => x.MBr).Column("m_br")
            .GeneratedBy.Sequence("ZAPOSLENI_SEQ");
            Map(x => x.Ime, "ime").Not.Nullable();
            Map(x => x.Prezime, "prezime").Not.Nullable();
            Map(x => x.DatumRodj, "datum_rodj").CustomType("date").Not.Nullable();
            Map(x => x.Adresa, "adresa");
            Map(x => x.Telefon, "telefon");
            Map(x => x.DatumZaposlenja, "datum_zaposlenja").CustomType("date").Not.Nullable();
        }
    }
}
