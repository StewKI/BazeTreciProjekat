namespace FarmacyLibrary.Entiteti
{
    public class SpecijalizovanaApoteka : ProdajnaJedinica
    {
        public virtual string? SpecijalnostTipa { get; set; }
        public virtual string? Napomena { get; set; }
    }
}
