namespace FarmacyLibrary.Entiteti
{
    public class Menadzer : Zaposleni
    {
        public virtual ISet<MenadzerApoteka> Apoteke { get; set; } = new HashSet<MenadzerApoteka>();
    }
}
