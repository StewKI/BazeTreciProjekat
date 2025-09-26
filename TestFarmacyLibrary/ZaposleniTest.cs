using FarmacyLibrary;
using FarmacyLibrary.Entiteti;

namespace TestFarmacyLibrary;

public class ZaposleniTest
{
    [Fact]
    void Dodaj()
    {
        var zap = new ZaposleniBasic()
        {
            Ime = "Pera",
            Prezime = "Peric",
            DatumRodj = new DateTime(1980, 10, 10),
            Adresa = "Negde Daleko",
            Telefon = "065123456",
            DatumZaposlenja = new DateTime(2020, 10, 10),
            MatBr = "0909009232323"
        };
        DTOManagerZaposleni.DodajZaposlenog(zap);
    }
}