namespace FarmacyLibrary.Entiteti
{
    public class Isporuka
    {
        public virtual long Id { get; set; }
        public virtual Distributer Distributer { get; set; } = default!;
        public virtual ProdajnaJedinicaBasic ProdajnaJedinica { get; set; } = default!;
        public virtual DateTime Datum { get; set; }
        public virtual Zaposleni? Magacioner { get; set; }

        public virtual ISet<IsporukaStavka> Stavke { get; set; } = new HashSet<IsporukaStavka>();
    }
}
