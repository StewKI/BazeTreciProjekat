namespace FarmacyLibrary.Entiteti
{
    public class IsporukaStavka : IEquatable<IsporukaStavka>
    {
        public virtual Isporuka Isporuka { get; set; } = default!;
        public virtual Pakovanje Pakovanje { get; set; } = default!;
        public virtual int Kolicina { get; set; }

        // IMPORTANT: equality over the composite key (isporuka_id, pakovanje_id)
        public virtual bool Equals(IsporukaStavka? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            // Compare by ids to avoid proxy reference differences
            var thisIspId = Isporuka?.Id;
            var otherIspId = other.Isporuka?.Id;
            var thisPakId = Pakovanje?.Id;
            var otherPakId = other.Pakovanje?.Id;

            return Equals(thisIspId, otherIspId) &&
                   Equals(thisPakId, otherPakId);
        }

        public override bool Equals(object? obj) => Equals(obj as IsporukaStavka);

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (Isporuka?.Id.GetHashCode() ?? 0);
                h = h * 23 + (Pakovanje?.Id.GetHashCode() ?? 0);
                return h;
            }
        }
    }

}
