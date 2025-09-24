namespace FarmacyLibrary.Entiteti
{
    public class Tehnicar : Zaposleni
    {
        public virtual string NivoObrazovanja { get; set; } = default!;
        public virtual ISet<TehnicarSertifikacija> Sertifikacije { get; set; } = new HashSet<TehnicarSertifikacija>();
    }
}
