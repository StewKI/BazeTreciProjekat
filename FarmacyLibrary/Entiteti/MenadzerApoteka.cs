namespace FarmacyLibrary.Entiteti
{
    public class MenadzerApoteka : IEquatable<MenadzerApoteka>
    {
        public virtual Menadzer Menadzer { get; set; } = default!;
        public virtual ProdajnaJedinica ProdajnaJedinica { get; set; } = default!;
        public virtual DateTime Od { get; set; }   // deo PK
        public virtual DateTime? Do { get; set; }

        // ---- Equality za composite-id (Menadzer.MBr, ProdajnaJedinica.Id, Od) ----
        public virtual bool Equals(MenadzerApoteka? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            var thisMenId = Menadzer?.MBr;
            var otherMenId = other.Menadzer?.MBr;
            var thisPjId = ProdajnaJedinica?.Id;
            var otherPjId = other.ProdajnaJedinica?.Id;

            return Equals(thisMenId, otherMenId)
                && Equals(thisPjId, otherPjId)
                && Od == other.Od;
        }

        public override bool Equals(object? obj) => Equals(obj as MenadzerApoteka);

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (Menadzer?.MBr.GetHashCode() ?? 0);
                h = h * 23 + (ProdajnaJedinica?.Id.GetHashCode() ?? 0);
                h = h * 23 + Od.GetHashCode();
                return h;
            }
        }
    }
}
