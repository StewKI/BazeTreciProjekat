using FarmacyLibrary;
using FarmacyLibrary.Entiteti;

namespace TestFarmacyLibrary;


public class ReceptTest
{
    [Fact]
    void DodajTest()
    {
        Recept r = new Recept()
        {
            SerijskiBroj = "1231233",
            DatumIzd = new DateTime(2025, 5, 5),
            NazivUstanove = "Dom zdravlja",
            SifraLekara = "Lekar1",
            Status = "CEKANJE"
        };
        DTOManagerIsporukeZalihe.DodajRecept(r);
    }

    [Fact]
    void VratiSvi()
    {
        DTOManagerIsporukeZalihe.VratiSveRecepte();
    }
}