using FarmacyLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FarmacyLibrary
{
    public static class DTOManagerProdaja
    {
        // Kreira klasičnu prodaju sa stavkama. Vraća ID prodaje.
        public static long KreirajProdaju(ProdajaBasic prodajaDto, IList<ProdajaStavkaBasic> stavke)
        {
            if (stavke == null || stavke.Count == 0)
                throw new ArgumentException("Prodaja mora imati bar jednu stavku.", nameof(stavke));

            try
            {
                using var s = DataLayer.GetSession();

                var prodaja = new Prodaja
                {
                    ProdajnaJedinica = s.Get<Entiteti.ProdajnaJedinicaBasic>(prodajaDto.ProdajnaJedinicaId),
                    DatumVreme = prodajaDto.DatumVreme,
                    Blagajnik = prodajaDto.BlagajnikMbr.HasValue ? s.Load<Zaposleni>(prodajaDto.BlagajnikMbr.Value) : null
                };

                s.Save(prodaja);

                foreach (var st in stavke)
                {
                    // Provera zaliha
                    var zaliha = s.Query<Zaliha>()
                                   .FirstOrDefault(z => z.ProdajnaJedinica.Id == prodajaDto.ProdajnaJedinicaId &&
                                                        z.Pakovanje.Id == st.PakovanjeId);
                    if (zaliha == null)
                    {
                        throw new Exception($"Ne postoji zaliha za pakovanje {st.PakovanjeId} u prodajnoj jedinici {prodajaDto.ProdajnaJedinicaId}.");
                    }
                    if (zaliha.Kolicina < st.Kolicina)
                    {
                        throw new Exception($"Nedovoljna zaliha za pakovanje {st.PakovanjeId}. Traženo: {st.Kolicina}, na stanju: {zaliha.Kolicina}.");
                    }

                    // Kreiraj stavku prodaje (klasična prodaja → recept polja su null)
                    var stavka = new Entiteti.ProdajaStavka
                    {
                        Prodaja = prodaja,
                        Pakovanje = s.Load<Pakovanje>(st.PakovanjeId),
                        Kolicina = st.Kolicina,
                        Cena = st.Cena
                    };
                    s.Save(stavka);

                    // Smanji zalihu
                    zaliha.Kolicina -= st.Kolicina;
                    s.Update(zaliha);
                }

                s.Flush();
                prodajaDto.Id = prodaja.Id;
                return prodaja.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri kreiranju prodaje: " + ex.Message);
            }
        }

        // Kreira prodaju NA RECEPT. Sva recept-specifična polja se preuzimaju iz stavke/parametara.
        // receptSerijskiBroj: zajednički recept za sve stavke ove prodaje (ako treba per-stavka, koristi polje u stavci)
        public static long KreirajProdajuNaRecept(ProdajaBasic prodajaDto, string receptSerijskiBroj, IList<ProdajaStavkaBasic> stavke)
        {
            if (string.IsNullOrWhiteSpace(receptSerijskiBroj))
                throw new ArgumentException("Serijski broj recepta je obavezan.", nameof(receptSerijskiBroj));
            if (stavke == null || stavke.Count == 0)
                throw new ArgumentException("Prodaja mora imati bar jednu stavku.", nameof(stavke));

            try
            {
                using var s = DataLayer.GetSession();

                // Učitaj recept (validacija postojanja)
                var recept = s.Get<Recept>(receptSerijskiBroj);
                if (recept == null)
                {
                    throw new Exception($"Recept sa brojem '{receptSerijskiBroj}' ne postoji.");
                }

                var prodaja = new Prodaja
                {
                    ProdajnaJedinica = s.Get<Entiteti.ProdajnaJedinicaBasic>(prodajaDto.ProdajnaJedinicaId),
                    DatumVreme = prodajaDto.DatumVreme,
                    Blagajnik = prodajaDto.BlagajnikMbr.HasValue ? s.Load<Zaposleni>(prodajaDto.BlagajnikMbr.Value) : null
                };

                s.Save(prodaja);

                foreach (var st in stavke)
                {
                    // Provera zaliha
                    var zaliha = s.Query<Zaliha>()
                                   .FirstOrDefault(z => z.ProdajnaJedinica.Id == prodajaDto.ProdajnaJedinicaId &&
                                                        z.Pakovanje.Id == st.PakovanjeId);
                    if (zaliha == null)
                    {
                        throw new Exception($"Ne postoji zaliha za pakovanje {st.PakovanjeId} u prodajnoj jedinici {prodajaDto.ProdajnaJedinicaId}.");
                    }
                    if (zaliha.Kolicina < st.Kolicina)
                    {
                        throw new Exception($"Nedovoljna zaliha za pakovanje {st.PakovanjeId}. Traženo: {st.Kolicina}, na stanju: {zaliha.Kolicina}.");
                    }

                    // Ako stavka nema eksplicitno zadat recept, koristi zajednički
                    var rsb = string.IsNullOrWhiteSpace(st.ReceptSerijskiBroj) ? receptSerijskiBroj : st.ReceptSerijskiBroj;

                    var stavka = new Entiteti.ProdajaStavka
                    {
                        Prodaja = prodaja,
                        Pakovanje = s.Load<Pakovanje>(st.PakovanjeId),
                        Kolicina = st.Kolicina,
                        Cena = st.Cena,
                        Recept = rsb != null ? s.Load<Recept>(rsb) : null,
                        KontrolisanaKol = st.KontrolisanaKol,
                        ProcenatParticip = st.ProcenatParticip,
                        NeophodanIzvestaj = st.NeophodanIzvestaj
                    };
                    s.Save(stavka);

                    // Smanji zalihu
                    zaliha.Kolicina -= st.Kolicina;
                    s.Update(zaliha);
                }

                s.Flush();
                prodajaDto.Id = prodaja.Id;
                return prodaja.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri kreiranju prodaje na recept: " + ex.Message);
            }
        }

        // === Helper funkcije za pakovanja ===
        public static IList<PakovanjeBasic> VratiSvaPakovanja()
        {
            var list = new List<PakovanjeBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var pakovanja = s.Query<Pakovanje>().ToList();
                foreach (var p in pakovanja)
                {
                    list.Add(new PakovanjeBasic
                    {
                        Id = p.Id,
                        LekId = p.Lek.Id,
                        OblikId = p.Oblik.Id,
                        VelicinaPakovanja = p.VelicinaPakovanja,
                        KolicinaAktivne = p.KolicinaAktivne,
                        JedinicaMere = p.JedinicaMere,
                        Ambalaza = p.Ambalaza,
                        NacinCuvanja = p.NacinCuvanja,
                        PreporuceniRokDana = p.PreporuceniRokDana,
                        LekNaziv = p.Lek.KomercijalniNaziv,
                        OblikNaziv = p.Oblik.Naziv
                    });
                }
            }
            catch (Exception) { }
            return list;
        }

        public static IList<PakovanjeBasic> VratiPakovanjaSaZalihe(long prodajnaJedinicaId)
        {
            var list = new List<PakovanjeBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var zalihe = s.Query<Zaliha>()
                              .Where(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId && x.Kolicina > 0)
                              .ToList();
                
                foreach (var z in zalihe)
                {
                    list.Add(new PakovanjeBasic
                    {
                        Id = z.Pakovanje.Id,
                        LekId = z.Pakovanje.Lek.Id,
                        OblikId = z.Pakovanje.Oblik.Id,
                        VelicinaPakovanja = z.Pakovanje.VelicinaPakovanja,
                        KolicinaAktivne = z.Pakovanje.KolicinaAktivne,
                        JedinicaMere = z.Pakovanje.JedinicaMere,
                        Ambalaza = z.Pakovanje.Ambalaza,
                        NacinCuvanja = z.Pakovanje.NacinCuvanja,
                        PreporuceniRokDana = z.Pakovanje.PreporuceniRokDana,
                        LekNaziv = z.Pakovanje.Lek.KomercijalniNaziv,
                        OblikNaziv = z.Pakovanje.Oblik.Naziv
                    });
                }
            }
            catch (Exception) { }
            return list;
        }

        // === Helper funkcije za blagajnike i recepte ===
        public static IList<ZaposleniBasic> VratiSveBlagajnike()
        {
            var list = new List<ZaposleniBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var blagajnici = s.Query<Zaposleni>().ToList();
                foreach (var b in blagajnici)
                {
                    list.Add(new ZaposleniBasic
                    {
                        MBr = b.MBr,
                        Ime = b.Ime,
                        Prezime = b.Prezime,
                        DatumRodj = b.DatumRodj,
                        Adresa = b.Adresa,
                        Telefon = b.Telefon,
                        DatumZaposlenja = b.DatumZaposlenja
                    });
                }
            }
            catch (Exception) { }
            return list;
        }

        public static IList<ReceptBasic> VratiSveRecepte()
        {
            var list = new List<ReceptBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var recepti = s.Query<Recept>().ToList();
                foreach (var r in recepti)
                {
                    list.Add(new ReceptBasic
                    {
                        SerijskiBroj = r.SerijskiBroj,
                        SifraLekara = r.SifraLekara,
                        DatumIzd = r.DatumIzd,
                        Status = r.Status,
                        NazivUstanove = r.NazivUstanove,
                        RealizacijaDatum = r.RealizacijaDatum
                    });
                }
            }
            catch (Exception) { }
            return list;
        }
    }
}
