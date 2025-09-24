namespace FarmacyLibrary.Entiteti
{
    public class Prodaja
    {
        public virtual long Id { get; set; }

        public virtual ProdajnaJedinicaBasic ProdajnaJedinica { get; set; } = default!;
        public virtual DateTime DatumVreme { get; set; }
        public virtual Zaposleni? Blagajnik { get; set; }

        public virtual ISet<ProdajaStavka> Stavke { get; set; } = new HashSet<ProdajaStavka>();
    }
}
