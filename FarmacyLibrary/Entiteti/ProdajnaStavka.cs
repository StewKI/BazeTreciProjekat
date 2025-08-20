namespace FarmacyLibrary.Entiteti
{
    public class ProdajaStavka : IEquatable<ProdajaStavka>
    {
        public virtual Prodaja Prodaja { get; set; } = default!;
        public virtual Pakovanje Pakovanje { get; set; } = default!;
        public virtual int Kolicina { get; set; }
        public virtual decimal? Cena { get; set; }
        public virtual Recept? Recept { get; set; } // nullable if OTC
        public virtual int? KontrolisanaKol { get; set; }
        public virtual decimal? ProcenatParticip { get; set; }
        public virtual string? NeophodanIzvestaj { get; set; } // 'Y'/'N'

        public virtual bool Equals(ProdajaStavka? o) =>
            o != null && Equals(Prodaja?.Id, o.Prodaja?.Id) &&
            Equals(Pakovanje?.Id, o.Pakovanje?.Id);
        public override bool Equals(object? o) => Equals(o as ProdajaStavka);
        public override int GetHashCode() =>
            (int)(((Prodaja?.Id ?? 0) * 397) ^ (Pakovanje?.Id ?? 0));
    }
}
