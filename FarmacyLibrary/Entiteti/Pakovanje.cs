namespace FarmacyLibrary.Entiteti
{
    public class Pakovanje
    {
        public virtual long Id { get; set; }
        public virtual Lek Lek { get; set; } = default!;
        public virtual Oblik Oblik { get; set; } = default!;
        public virtual string VelicinaPakovanja { get; set; } = default!;
        public virtual decimal KolicinaAktivne { get; set; }
        public virtual string JedinicaMere { get; set; } = default!;
        public virtual string? Ambalaza { get; set; }
        public virtual string? NacinCuvanja { get; set; }
        public virtual int? PreporuceniRokDana { get; set; }
    }
}
