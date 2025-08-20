namespace FarmacyLibrary.Entiteti
{
    public class LekSekundarna : IEquatable<LekSekundarna>
    {
        public virtual Lek Lek { get; set; } = default!;
        public virtual SekundarnaKategorija Kategorija { get; set; } = default!;

        // (opciono) dodatna polja... npr. Napomena, DatumOd...

        public virtual bool Equals(LekSekundarna? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Lek?.Id, other.Lek?.Id) &&
                   Equals(Kategorija?.Id, other.Kategorija?.Id);
        }

        public override bool Equals(object? obj) => Equals(obj as LekSekundarna);

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (Lek?.Id.GetHashCode() ?? 0);
                h = h * 23 + (Kategorija?.Id.GetHashCode() ?? 0);
                return h;
            }
        }
    }

}
