namespace FarmacyLibrary.Entiteti
{
    public class Zaposleni
    {
        public virtual long Id { get; set; }
        public virtual string Prezime { get; set; } = default!;
        public virtual string Ime { get; set; } = default!;
        public virtual string? MatBr { get; set; } = default!;
        public virtual DateTime DatumRodj { get; set; }
        public virtual string? Adresa { get; set; }
        public virtual string? Telefon { get; set; }
        public virtual DateTime DatumZaposlenja { get; set; }
    }
}
