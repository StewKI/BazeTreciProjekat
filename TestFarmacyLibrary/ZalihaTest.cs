using FarmacyLibrary;

namespace TestFarmacyLibrary;

public class ZalihaTest
{
    [Fact]
    void Dodaj()
    {
        var dto = new ZalihaBasic
        {
            ProdajnaJedinicaId = 14,
            PakovanjeId = 1,
            Kolicina = 104,
            DatumPoslednjeIsporuke = new DateTime(2023, 10, 10),
            OdgovorniMagacionerId = 101
        };
        DTOManagerIsporukeZalihe.DodajZalihu(dto);
    }
}