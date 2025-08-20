using FarmacyLibrary.Entiteti;
using FluentNHibernate.Mapping;

namespace FarmacyLibrary.Mapiranja
{
    public class PakovanjeMap : ClassMap<Pakovanje>
    {
        public PakovanjeMap()
        {
            Table("Pakovanje");
            Id(x => x.Id, "id").GeneratedBy.Identity();
            References(x => x.Lek, "lek_id").Not.Nullable();
            References(x => x.Oblik, "oblik_id").Not.Nullable();
            Map(x => x.VelicinaPakovanja, "velicina_pakovanja").Not.Nullable();
            Map(x => x.KolicinaAktivne, "kolicina_aktivne").CustomType("decimal").Not.Nullable();
            Map(x => x.JedinicaMere, "jedinica_mere").Not.Nullable();
            Map(x => x.Ambalaza, "ambalaza");
            Map(x => x.NacinCuvanja, "nacin_cuvanja");
            Map(x => x.PreporuceniRokDana, "preporuceni_rok_dana").Nullable();
            // UNIQUE(lek_id, oblik_id, velicina_pakovanja) – nije obavezno deklarisati i u NH
        }
    }
}
