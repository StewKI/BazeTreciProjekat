namespace FarmacyLibrary.Entiteti
{
    public class RadnoVreme : IEquatable<RadnoVreme>
    {
        public virtual ProdajnaJedinica ProdajnaJedinica { get; set; } = default!;
        public virtual int Dan { get; set; }            // 1..7
        public virtual TimeSpan VremeOd { get; set; }   // INTERVAL DAY TO SECOND
        public virtual TimeSpan VremeDo { get; set; }   // INTERVAL DAY TO SECOND

        // ----- Equality za CompositeId -----
        public virtual bool Equals(RadnoVreme? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            var thisPjId = ProdajnaJedinica?.Id;
            var otherPjId = other.ProdajnaJedinica?.Id;

            return Equals(thisPjId, otherPjId) && Dan == other.Dan;
        }

        public override bool Equals(object? obj) => Equals(obj as RadnoVreme);

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (ProdajnaJedinica?.Id.GetHashCode() ?? 0);
                h = h * 23 + Dan.GetHashCode();
                return h;
            }
        }
    }
}
