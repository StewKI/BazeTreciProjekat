namespace FarmacyLibrary.Entiteti
{
    public class Lek
    {
        public virtual long Id { get; set; }
        public virtual string HemijskiNaziv { get; set; } = default!;
        public virtual string KomercijalniNaziv { get; set; } = default!;
        public virtual string? Dejstvo { get; set; }

        public virtual Proizvodjac Proizvodjac { get; set; } = default!;
        public virtual PrimarnaGrupa PrimarnaGrupa { get; set; } = default!;

        public virtual ISet<LekSekundarna> Sekundarne { get; set; } = new HashSet<LekSekundarna>();
        public virtual ISet<Pakovanje> Pakovanja { get; set; } = new HashSet<Pakovanje>();
    }
}
