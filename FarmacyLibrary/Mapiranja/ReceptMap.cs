using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace FarmacyLibrary.Mapiranja
{
    public class ReceptMap : ClassMap<Recept>
    {
        public ReceptMap()
        {
            Table("Recept");

            Id(x => x.SerijskiBroj, "serijski_broj").GeneratedBy.Assigned();

            Map(x => x.SifraLekara, "sifra_lekara").Not.Nullable();
            Map(x => x.DatumIzd, "datum_izd").CustomType<DateType>().Not.Nullable();         // was "date"
            Map(x => x.Status, "status").Not.Nullable();
            Map(x => x.NazivUstanove, "naziv_ustanove").Not.Nullable();

            References(x => x.RealizovanaProdajnaJedinica, "realiz_prod_jed_id").Nullable();
            Map(x => x.RealizacijaDatum, "realizacija_datum").CustomType<DateType>().Nullable(); // was "date"
            References(x => x.RealizovaoFarmaceut, "realizovao_farmaceut_id").Nullable();
        }
    }
}
