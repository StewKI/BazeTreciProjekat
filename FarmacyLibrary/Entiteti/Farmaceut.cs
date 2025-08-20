namespace FarmacyLibrary.Entiteti
{
    public class Farmaceut : Zaposleni
    {
        public virtual DateTime DatumDiplomiranja { get; set; }
        public virtual string BrLicence { get; set; } = default!;
        public virtual DateTime DatumPoslObnoveLicence { get; set; }
        public virtual string? Specijalnost { get; set; }
    }
}
