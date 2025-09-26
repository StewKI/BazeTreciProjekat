namespace FarmacyLibrary.Entiteti
{
    public class Zaliha : IEquatable<Zaliha>
    {
        public virtual FarmacyLibrary.Entiteti.ProdajnaJedinica ProdajnaJedinica { get; set; } = default!;
        public virtual Pakovanje Pakovanje { get; set; } = default!;
        public virtual int Kolicina { get; set; }
        public virtual DateTime? DatumPoslednjeIsporuke { get; set; }
        public virtual Zaposleni? OdgovorniMagacioner { get; set; }

        public virtual bool Equals(Zaliha? o) =>
            o != null &&
            Equals(ProdajnaJedinica?.Id, o.ProdajnaJedinica?.Id) &&
            Equals(Pakovanje?.Id, o.Pakovanje?.Id);

        public override bool Equals(object? obj) => Equals(obj as Zaliha);

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (ProdajnaJedinica?.Id.GetHashCode() ?? 0);
                h = h * 23 + (Pakovanje?.Id.GetHashCode() ?? 0);
                return h;
            }
        }
    }
}
