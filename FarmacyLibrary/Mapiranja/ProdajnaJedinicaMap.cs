using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class ProdajnaJedinicaMap : ClassMap<ProdajnaJedinica>
    {
        public ProdajnaJedinicaMap()
        {
            Table("Prodajna_jedinica");
            Id(x => x.Id, "id").GeneratedBy.Sequence("PRODAJNA_JEDINICA_SEQ");
            Map(x => x.Naziv, "naziv").Not.Nullable();
            Map(x => x.Ulica, "ulica").Not.Nullable();
            Map(x => x.Broj, "broj").Not.Nullable();
            Map(x => x.PostanskiBroj, "postanski_broj").Not.Nullable();
            Map(x => x.Mesto, "mesto").Not.Nullable();

            References(x => x.OdgovorniFarmaceut, "odgovorni_farmaceut_mbr").Not.Nullable();

            HasMany(x => x.RadnaVremena)
                .KeyColumn("prodajna_jedinica_id")
                .Cascade.All()
                .Inverse();
        }
    }
}
