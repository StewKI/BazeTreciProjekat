namespace FarmacyLibrary.Entiteti
{
    public class Proizvodjac
    {
        public virtual long Id { get; set; }
        public virtual string Naziv { get; set; } = default!;
        public virtual string Zemlja { get; set; } = default!;
        public virtual string? Telefon { get; set; }
        public virtual string? Email { get; set; }

        public virtual ISet<Lek> Lekovi { get; set; } = new HashSet<Lek>();
    }
}
