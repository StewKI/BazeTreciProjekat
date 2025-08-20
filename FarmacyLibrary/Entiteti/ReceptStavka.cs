namespace FarmacyLibrary.Entiteti
{
    public class ReceptStavka : IEquatable<ReceptStavka>
    {
        public virtual Recept Recept { get; set; } = default!;
        public virtual Pakovanje Pakovanje { get; set; } = default!;
        public virtual int Kolicina { get; set; }
        public virtual string? PreporucenaDoza { get; set; }

        public virtual bool Equals(ReceptStavka? o) =>
            o != null && Equals(Recept?.SerijskiBroj, o.Recept?.SerijskiBroj) &&
            Equals(Pakovanje?.Id, o.Pakovanje?.Id);
        public override bool Equals(object? o) => Equals(o as ReceptStavka);
        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (Recept?.SerijskiBroj?.GetHashCode() ?? 0);
                h = h * 23 + (Pakovanje?.Id.GetHashCode() ?? 0);
                return h;
            }
        }
    }
}
