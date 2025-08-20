namespace FarmacyLibrary.Entiteti
{
    public class Distributer
    {
        public virtual long Id { get; set; }
        public virtual string Naziv { get; set; } = default!;
        public virtual string? Kontakt { get; set; }
    }

}
