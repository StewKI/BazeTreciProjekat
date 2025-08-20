namespace FarmacyLibrary.Entiteti
{
    public class ProdajnaJedinica
    {
        public virtual long Id { get; set; }
        public virtual string Naziv { get; set; } = default!;
        public virtual string Ulica { get; set; } = default!;
        public virtual string Broj { get; set; } = default!;
        public virtual string PostanskiBroj { get; set; } = default!;
        public virtual string Mesto { get; set; } = default!;

        public virtual Farmaceut OdgovorniFarmaceut { get; set; } = default!;
        public virtual ISet<RadnoVreme> RadnaVremena { get; set; } = new HashSet<RadnoVreme>();
    }
}
