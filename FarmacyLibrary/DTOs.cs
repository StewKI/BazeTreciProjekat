namespace FarmacyLibrary
{

    public class ZaposleniBasic
    {
        public long MBr { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodj { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumZaposlenja { get; set; }
    }

    public class FarmaceutBasic : ZaposleniBasic
    {
        public DateTime DatumDiplomiranja { get; set; }
        public string BrLicence { get; set; }
        public DateTime DatumPoslednjeObnoveLicence { get; set; }
        public string Specijalnost { get; set; }
    }

    public class TehnicarBasic : ZaposleniBasic
    {
        // 'SREDNJI' / 'VISI'
        public string NivoObrazovanja { get; set; }
        public IList<TehnicarSertifikacijaBasic> Sertifikacije { get; set; } = new List<TehnicarSertifikacijaBasic>();
    }

    public class TehnicarSertifikacijaBasic
    {
        public long MBrTehnicara { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum { get; set; }
    }

    public class MenadzerBasic : ZaposleniBasic { }

    // === Prodajne jedinice ===
    public class ProdajnaJedinicaBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string PostanskiBroj { get; set; }
        public string Mesto { get; set; }
        public long OdgovorniFarmaceutMbr { get; set; }
    }

    public class MenadzerApotekaBasic
    {
        public long MBrMenadzera { get; set; }
        public long ProdajnaJedinicaId { get; set; }
        public DateTime Od { get; set; }
        public DateTime? Do { get; set; }
        public DateTime? datumKontrole { get; set; }

    }

    // === Proizvođači / grupe / lekovi ===
    public class ProizvodjacBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Zemlja { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }

    public class PrimarnaGrupaBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class SekundarnaKategorijaBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class LekBasic
    {
        public long Id { get; set; }
        public string HemijskiNaziv { get; set; }
        public string KomercijalniNaziv { get; set; }
        public string Dejstvo { get; set; }
        public long ProizvodjacId { get; set; }
        public long PrimarnaGrupaId { get; set; }
        public IList<long> SekundarneKategorijeIds { get; set; } = new List<long>();
    }

    public class OblikBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
    }

    public class PakovanjeBasic
    {
        public long Id { get; set; }
        public long LekId { get; set; }
        public long OblikId { get; set; }
        public string VelicinaPakovanja { get; set; }
        public decimal KolicinaAktivne { get; set; }
        public string JedinicaMere { get; set; }
        public string? Ambalaza { get; set; }
        public string? NacinCuvanja { get; set; }
        public int? PreporuceniRokDana { get; set; }
        
        // Dodatne informacije za prikaz
        public string LekNaziv { get; set; }
        public string OblikNaziv { get; set; }
        public string PrikazniNaziv => $"{LekNaziv} - {VelicinaPakovanja} ({KolicinaAktivne} {JedinicaMere})";
    }

    // === Distributer / isporuka / zaliha ===
    public class DistributerBasic
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Kontakt { get; set; }
    }

    public class IsporukaStavkaBasic
    {
        public long IsporukaId { get; set; }
        public long PakovanjeId { get; set; }
        public int Kolicina { get; set; }
    }

    public class IsporukaBasic
    {
        public long Id { get; set; }
        public long DistributerId { get; set; }
        public long ProdajnaJedinicaId { get; set; }
        public DateTime Datum { get; set; }
        public long? MagacionerMbr { get; set; }
        public IList<IsporukaStavkaBasic> Stavke { get; set; } = new List<IsporukaStavkaBasic>();
    }

    public class ZalihaBasic
    {
        public long ProdajnaJedinicaId { get; set; }
        public long PakovanjeId { get; set; }
        public int Kolicina { get; set; }
        public DateTime? DatumPoslednjeIsporuke { get; set; }
        public long? OdgovorniMagacionerMbr { get; set; }
    }

    public class ProdajaBasic
    {
        public long Id { get; set; }
        public long ProdajnaJedinicaId { get; set; }
        public DateTime DatumVreme { get; set; }
        public long? BlagajnikMbr { get; set; }
        public string ProdajnaJedinicaNaziv { get; set; }
        public string BlagajnikIme { get; set; }
        public decimal UkupnaVrednost { get; set; }
        public int BrojStavki { get; set; }
    }

    public class ProdajaStavkaBasic
    {
        public long ProdajaId { get; set; }
        public long PakovanjeId { get; set; }
        public int Kolicina { get; set; }
        public decimal? Cena { get; set; }
        public string? ReceptSerijskiBroj { get; set; }
        public int? KontrolisanaKol { get; set; }
        public decimal? ProcenatParticip { get; set; }
        public string? NeophodanIzvestaj { get; set; }
        public string PakovanjeNaziv { get; set; }
    }

    public class RadnoVremeBasic
    {
        public long Id { get; set; }
        public long ProdajnaJedinicaId { get; set; }
        public int Dan { get; set; }
        public DateTime? VremeOd { get; set; }
        public DateTime? VremeDo { get; set; }
        public string DanNaziv { get; set; }
        public string ProdajnaJedinicaNaziv { get; set; }
    }


    public class RasporedRadaBasic
    {
        public virtual long MBr { get; set; }
        public virtual long ProdajnaJedinicaId { get; set; }
        public virtual DateTime Pocetak { get; set; }
        public virtual DateTime Kraj { get; set; }
        public virtual int? BrojSmene { get; set; }
        public virtual string ZaposleniIme { get; set; } = default!;
        public virtual string ZaposleniPrezime { get; set; } = default!;
        public virtual string ProdajnaJedinicaNaziv { get; set; } = default!;
        public virtual string SmenaNaziv { get; set; } = default!;
    }

    public class ReceptBasic
    {
        public string SerijskiBroj { get; set; }
        public string SifraLekara { get; set; }
        public DateTime DatumIzd { get; set; }
        public string Status { get; set; }
        public string NazivUstanove { get; set; }
        public DateTime? RealizacijaDatum { get; set; }
        public string PrikazniNaziv => $"{SerijskiBroj} - {NazivUstanove} ({Status})";
    }
}
