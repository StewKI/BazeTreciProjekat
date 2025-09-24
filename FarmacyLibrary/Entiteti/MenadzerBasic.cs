namespace FarmacyLibrary.Entiteti
{
    public class MenadzerBasic : Zaposleni
    {
        public virtual ISet<MenadzerApoteka> Apoteke { get; set; } = new HashSet<MenadzerApoteka>();
    }
}
