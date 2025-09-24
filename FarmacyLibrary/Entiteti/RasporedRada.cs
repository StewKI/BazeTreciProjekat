namespace FarmacyLibrary.Entiteti
{
    public class RasporedRada
    {
        public virtual Zaposleni Zaposleni { get; set; }                         // M_BR
        public virtual FarmacyLibrary.Entiteti.ProdajnaJedinicaBasic ProdajnaJedinica { get; set; } // PRODAJNA_JEDINICA_ID (FK)
        public virtual DateTime Pocetak { get; set; }                // POCETAK (TIMESTAMP)
        public virtual DateTime Kraj { get; set; }                   // KRAJ (TIMESTAMP)
        public virtual int? BrojSmene { get; set; }                  // BROJ_SMENE (1, 2, 3)

        public override bool Equals(object? obj)
        {
            var other = obj as RasporedRada;
            if (ReferenceEquals(this, other)) return true;
            if (other is null) return false;

            // Paziti da reference mogu biti null dok NH ne učita proxije
            var thisZapId = Zaposleni?.MBr ?? 0;
            var otherZapId = other.Zaposleni?.MBr ?? 0;

            var thisPjId = ProdajnaJedinica?.Id ?? 0;
            var otherPjId = other.ProdajnaJedinica?.Id ?? 0;

            return thisZapId == otherZapId
                && thisPjId == otherPjId
                && Pocetak == other.Pocetak;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int h = 17;
                h = h * 23 + (Zaposleni?.MBr ?? 0).GetHashCode();
                h = h * 23 + (ProdajnaJedinica?.Id ?? 0).GetHashCode();
                h = h * 23 + Pocetak.GetHashCode();
                return h;
            }
        }
    }
}
