using FarmacyLibrary.Entiteti;
using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using FarmacyLibrary.Entiteti;
using FarmacyLibrary;

namespace FarmacyLibrary
{
    public static class DTOManagerIsporukeZalihe
    {
        public static long KreirajIsporuku(IsporukaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var isp = new Isporuka
                {
                    Distributer = s.Load<Distributer>(dto.DistributerId),
                    ProdajnaJedinica = s.Load<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId),
                    Datum = dto.Datum,
                    Magacioner = dto.MagacionerId.HasValue ? s.Load<Zaposleni>(dto.MagacionerId.Value) : null
                };
                s.Save(isp);

                foreach (var st in dto.Stavke)
                {
                    var stavka = new IsporukaStavka
                    {
                        Isporuka = isp,
                        Pakovanje = s.Load<Pakovanje>(st.PakovanjeId),
                        Kolicina = st.Kolicina,
                    };
                    s.Save(stavka);

                    // update Zaliha (upsert)
                    var z = s.Query<Zaliha>()
                             .FirstOrDefault(x => x.ProdajnaJedinica.Id == dto.ProdajnaJedinicaId
                                               && x.Pakovanje.Id == st.PakovanjeId);
                    if (z == null)
                    {
                        z = new Zaliha
                        {
                            ProdajnaJedinica = isp.ProdajnaJedinica,
                            Pakovanje = stavka.Pakovanje,
                            Kolicina = st.Kolicina,
                            DatumPoslednjeIsporuke = dto.Datum,
                            OdgovorniMagacioner = isp.Magacioner,
                        };
                        s.Save(z);
                    }
                    else
                    {
                        z.Kolicina += st.Kolicina;
                        z.DatumPoslednjeIsporuke = dto.Datum;
                        z.OdgovorniMagacioner = isp.Magacioner;
                        s.Update(z);
                    }
                }

                s.Flush();
                dto.Id = isp.Id;
                return isp.Id;
            }
            catch (Exception ex) 
            {
                throw new Exception("Greška pri kreiranju isporuke: " + ex.Message);
            }
        }

        public static IList<ZalihaBasic> VratiZaliheApoteke(long prodajnaJedinicaId)
        {
            var list = new List<ZalihaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var zalihe = s.Query<Zaliha>()
                              .Where(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId)
                              .ToList();
                foreach (var z in zalihe)
                {
                    list.Add(new ZalihaBasic
                    {
                        ProdajnaJedinicaId = z.ProdajnaJedinica.Id,
                        PakovanjeId = z.Pakovanje.Id,
                        Kolicina = z.Kolicina,
                        DatumPoslednjeIsporuke = z.DatumPoslednjeIsporuke,
                        OdgovorniMagacionerId = z.OdgovorniMagacioner?.Id
                    });
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Greška pri vraćanju zaliha apoteke: " + ex.Message);
            }
            return list;
        }

        public static void DodajDistributera(DistributerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                var d1 = new Distributer
                {
                    Naziv=dto.Naziv,
                    Kontakt=dto.Kontakt,
                };
                s.Save(d1);
                s.Flush();

                // Uspesno je dodat distributer
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri dodavanju distributera: " + ex.Message);
            }
        }

        public static void DodajRecept(Recept r)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var d1 = new Recept
                {
                    SerijskiBroj=r.SerijskiBroj,
                    SifraLekara=r.SifraLekara,
                    DatumIzd=r.DatumIzd,
                    Status=r.Status,
                    NazivUstanove=r.NazivUstanove,
                };
                s.Save(d1);
                s.Flush();

                // Uspesno je dodat recept
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static void RealizujRecept(string idR, long prodajnaJedinicaId,DateTime d)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var recept = s.Get<Recept>(idR);
                var prodajnaJedinica=s.Get<Entiteti.ProdajnaJedinica>(prodajnaJedinicaId);
                if (recept.RealizovaoFarmaceut != null)
                {
                    throw new Exception("Recept je vec realizovan");
                    
                }
                if(recept !=null)
                {
                    recept.RealizovanaProdajnaJedinica = prodajnaJedinica;
                    recept.RealizovaoFarmaceut = DTOManagerZaposleni.VratiOdgovornogFarmaceuta(prodajnaJedinica.OdgovorniFarmaceut.Id);
                    recept.RealizacijaDatum = d;

                }
                s.Update(recept);
                s.Flush();

                // Uspesno je realizovan recept
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public static IList<ProizvodjacBasic> VratiSveProizvodjace()
        {
            var list = new List<ProizvodjacBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var proizvodjaci = s.Query<Proizvodjac>().ToList();
                foreach (var p in proizvodjaci)
                {
                    list.Add(new ProizvodjacBasic
                    {
                        Id = p.Id,
                        Naziv = p.Naziv,
                        Zemlja = p.Zemlja,
                        Telefon = p.Telefon,
                        Email = p.Email
                    });
                }
            }
            catch (Exception ex) { 
                throw new Exception(ex.Message);
                
            }
            return list;
        }

        public static IList<SekundarnaKategorijaBasic> VratiSveSekundarneKategorije()
        {
            var list = new List<SekundarnaKategorijaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var kategorije = s.Query<SekundarnaKategorija>().ToList();
                foreach (var k in kategorije)
                {
                    list.Add(new SekundarnaKategorijaBasic
                    {
                        Id = k.Id,
                        Naziv = k.Naziv
                    });
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
                
            }
            return list;
        }

        public static SekundarnaKategorijaBasic VratiSekundarnuGrupu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var grupa = s.Get<SekundarnaKategorija>(id);
                if (grupa != null)
                {
                    return new SekundarnaKategorijaBasic
                    {
                        Id = grupa.Id,
                        Naziv = grupa.Naziv
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static long DodajSekundarnuGrupu(SekundarnaKategorijaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var grupa = new SekundarnaKategorija { Naziv = dto.Naziv };
                s.Save(grupa);
                s.Flush();
                dto.Id = grupa.Id;
                return grupa.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri dodavanju sekundarne grupe: " + ex.Message);
            }
        }

        public static void IzmeniSekundarnuGrupu(SekundarnaKategorijaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var grupa = s.Get<SekundarnaKategorija>(dto.Id);
                if (grupa != null)
                {
                    grupa.Naziv = dto.Naziv;
                    s.Update(grupa);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri izmeni sekundarne grupe: " + ex.Message);
            }
        }

        public static void ObrisiSekundarnuGrupu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var grupa = s.Get<SekundarnaKategorija>(id);
                if (grupa != null)
                {
                    s.Delete(grupa);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju sekundarne grupe: " + ex.Message);
            }
        }

        public static IList<Recept> VratiSveRecepte()
        {
            var list = new List<Recept>();
            try
            {
                using var s = DataLayer.GetSession();
                var recepti = s.Query<Recept>().ToList();
                foreach (var r in recepti)
                {
                    list.Add(r);
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Recept VratiRecept(string serijskiBroj)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var recept = s.Get<Recept>(serijskiBroj);
                return recept;
            }
            catch (Exception ex) 
            {
                throw new Exception("Greška pri učitavanju recepta: " + ex.Message);
            }
        }

        public static void ObrisiRecept(string serijskiBroj)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var recept = s.Get<Recept>(serijskiBroj);
                if (recept != null)
                {
                    s.Delete(recept);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju recepta: " + ex.Message);
            }
        }

        public static void DodajReceptStavku(ReceptStavkaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var recept = s.Get<Recept>(dto.ReceptSerijskiBroj);
                var pakovanje = s.Get<Pakovanje>(dto.PakovanjeId);

                if (recept is null || pakovanje is null)
                {
                    throw new Exception("Pogresni pakovanjeId ili receptSerijskiBroj");
                }

                var receptStavka = new ReceptStavka()
                {
                    Kolicina = dto.Kolicina,
                    Pakovanje = pakovanje,
                    PreporucenaDoza = dto.PreporucenaDoza,
                    Recept = recept
                };
                
                s.Save(receptStavka);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri dodavanju stavke recepta: " + ex.Message);
            }
        }

        // === Distributer CRUD operacije ===
        public static IList<DistributerBasic> VratiSveDistributere()
        {
            var list = new List<DistributerBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var distributeri = s.Query<Distributer>().ToList();
                foreach (var d in distributeri)
                {
                    list.Add(new DistributerBasic
                    {
                        Id = d.Id,
                        Naziv = d.Naziv,
                        Kontakt = d.Kontakt
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static DistributerBasic VratiDistributera(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var distributer = s.Get<Distributer>(id);
                if (distributer != null)
                {
                    return new DistributerBasic
                    {
                        Id = distributer.Id,
                        Naziv = distributer.Naziv,
                        Kontakt = distributer.Kontakt
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static void IzmeniDistributera(DistributerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var distributer = s.Get<Distributer>(dto.Id);
                if (distributer != null)
                {
                    distributer.Naziv = dto.Naziv;
                    distributer.Kontakt = dto.Kontakt;
                    s.Update(distributer);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri izmeni distributera: " + ex.Message);
            }
        }

        public static void ObrisiDistributera(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var distributer = s.Get<Distributer>(id);
                if (distributer != null)
                {
                    s.Delete(distributer);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju distributera: " + ex.Message);
            }
        }

        // === Proizvodjac CRUD operacije ===
        public static ProizvodjacBasic VratiProizvodjaca(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var proizvodjac = s.Get<Proizvodjac>(id);
                if (proizvodjac != null)
                {
                    return new ProizvodjacBasic
                    {
                        Id = proizvodjac.Id,
                        Naziv = proizvodjac.Naziv,
                        Zemlja = proizvodjac.Zemlja,
                        Telefon = proizvodjac.Telefon,
                        Email = proizvodjac.Email
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static void IzmeniProizvodjaca(ProizvodjacBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var proizvodjac = s.Get<Proizvodjac>(dto.Id);
                if (proizvodjac != null)
                {
                    proizvodjac.Naziv = dto.Naziv;
                    proizvodjac.Zemlja = dto.Zemlja;
                    proizvodjac.Telefon = dto.Telefon;
                    proizvodjac.Email = dto.Email;
                    s.Update(proizvodjac);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri izmeni proizvodjača: " + ex.Message);
            }
        }

        public static void DodajProizvodjaca(ProizvodjacBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                var p = new Proizvodjac
                {
                    Naziv = dto.Naziv,
                    Zemlja = dto.Zemlja,
                    Telefon = dto.Telefon,
                    Email = dto.Email
                };
                s.Save(p);
                s.Flush();

                // Uspešno je dodat proizvodjač
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ObrisiProizvodjaca(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var proizvodjac = s.Get<Proizvodjac>(id);
                if (proizvodjac != null)
                {
                    s.Delete(proizvodjac);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju proizvodjača: " + ex.Message);
            }
        }

        // === Zaliha CRUD operacije ===
        public static IList<ZalihaBasic> VratiSveZalihe()
        {
            var list = new List<ZalihaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var zalihe = s.Query<Zaliha>().ToList();
                foreach (var z in zalihe)
                {
                    list.Add(new ZalihaBasic
                    {
                        ProdajnaJedinicaId = z.ProdajnaJedinica.Id,
                        PakovanjeId = z.Pakovanje.Id,
                        Kolicina = z.Kolicina,
                        DatumPoslednjeIsporuke = z.DatumPoslednjeIsporuke,
                        OdgovorniMagacionerId = z.OdgovorniMagacioner?.Id
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static ZalihaBasic VratiZalihu(long prodajnaJedinicaId, long pakovanjeId)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var zaliha = s.Query<Zaliha>()
                    .FirstOrDefault(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId
                                         && x.Pakovanje.Id == pakovanjeId);
                if (zaliha != null)
                {
                    return new ZalihaBasic
                    {
                        ProdajnaJedinicaId = zaliha.ProdajnaJedinica.Id,
                        PakovanjeId = zaliha.Pakovanje.Id,
                        Kolicina = zaliha.Kolicina,
                        DatumPoslednjeIsporuke = zaliha.DatumPoslednjeIsporuke,
                        OdgovorniMagacionerId = zaliha.OdgovorniMagacioner?.Id
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static void DodajZalihu(ZalihaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var odgMagacioner = s.Load<Zaposleni>(dto.OdgovorniMagacionerId);
                
                var zaliha = new Zaliha
                {
                    ProdajnaJedinica = s.Load<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId),
                    Pakovanje = s.Load<Pakovanje>(dto.PakovanjeId),
                    Kolicina = dto.Kolicina,
                    DatumPoslednjeIsporuke = dto.DatumPoslednjeIsporuke,
                    OdgovorniMagacioner = odgMagacioner
                };
                s.Save(zaliha);
                s.Flush();

                // Uspešno je dodana zaliha
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void IzmeniZalihu(ZalihaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var zaliha = s.Query<Zaliha>()
                              .FirstOrDefault(x => x.ProdajnaJedinica.Id == dto.ProdajnaJedinicaId 
                                                && x.Pakovanje.Id == dto.PakovanjeId);
                if (zaliha != null)
                {
                    zaliha.Kolicina = dto.Kolicina;
                    zaliha.DatumPoslednjeIsporuke = dto.DatumPoslednjeIsporuke;
                    zaliha.OdgovorniMagacioner = dto.OdgovorniMagacionerId.HasValue ? 
                        s.Load<Zaposleni>(dto.OdgovorniMagacionerId.Value) : null;
                    s.Update(zaliha);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri izmeni zalihe: " + ex.Message);
            }
        }

        public static void ObrisiZalihu(long prodajnaJedinicaId, long pakovanjeId)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var zaliha = s.Query<Zaliha>()
                              .FirstOrDefault(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId 
                                                && x.Pakovanje.Id == pakovanjeId);
                if (zaliha != null)
                {
                    s.Delete(zaliha);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju zalihe: " + ex.Message);
            }
        }

        // === Helper funkcije za dropdown liste ===
        public static IList<ProdajnaJedinicaBasic> VratiSveProdajneJedinice()
        {
            var list = new List<ProdajnaJedinicaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var prodajneJedinice = s.Query<Entiteti.ProdajnaJedinica>().ToList();
                foreach (var pj in prodajneJedinice)
                {
                    list.Add(new ProdajnaJedinicaBasic
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

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
                        PreporuceniRokDana = p.PreporuceniRokDana
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<ZaposleniBasic> VratiSveMagacionere()
        {
            var list = new List<ZaposleniBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var magacioneri = s.Query<Zaposleni>()
                    .Where(x => x.GetType().Name == "Magacioner")
                    .ToList();
                foreach (var m in magacioneri)
                {
                    list.Add(new ZaposleniBasic
                    {
                        Id = m.Id,
                        Ime = m.Ime,
                        Prezime = m.Prezime,
                        DatumRodj = m.DatumRodj,
                        Adresa = m.Adresa,
                        Telefon = m.Telefon,
                        DatumZaposlenja = m.DatumZaposlenja
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        // === Prodaja CRUD operacije ===
        public static IList<ProdajaBasic> VratiSveProdaje()
        {
            var list = new List<ProdajaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var prodaje = s.Query<Prodaja>().ToList();
                foreach (var p in prodaje)
                {
                    decimal ukupnaVrednost = 0;
                    int brojStavki = 0;

                    if (p.Stavke != null)
                    {
                        brojStavki = p.Stavke.Count;
                        foreach (var stavka in p.Stavke)
                        {
                            if (stavka.Cena.HasValue)
                            {
                                ukupnaVrednost += stavka.Cena.Value * stavka.Kolicina;
                            }
                        }
                    }

                    list.Add(new ProdajaBasic
                    {
                        Id = p.Id,
                        ProdajnaJedinicaId = p.ProdajnaJedinica.Id,
                        DatumVreme = p.DatumVreme,
                        BlagajnikId = p.Blagajnik?.Id,
                        ProdajnaJedinicaNaziv = p.ProdajnaJedinica.Naziv,
                        BlagajnikIme = p.Blagajnik != null ? $"{p.Blagajnik.Ime} {p.Blagajnik.Prezime}" : "N/A",
                        UkupnaVrednost = ukupnaVrednost,
                        BrojStavki = brojStavki
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<ProdajaBasic> VratiProdajeZaProdajnuJedinicu(long prodajnaJedinicaId)
        {
            var list = new List<ProdajaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var prodaje = s.Query<Prodaja>()
                    .Where(p => p.ProdajnaJedinica.Id == prodajnaJedinicaId)
                    .ToList();
                foreach (var p in prodaje)
                {
                    decimal ukupnaVrednost = 0;
                    int brojStavki = 0;
                    
                    if (p.Stavke != null)
                    {
                        brojStavki = p.Stavke.Count;
                        foreach (var stavka in p.Stavke)
                        {
                            if (stavka.Cena.HasValue)
                            {
                                ukupnaVrednost += stavka.Cena.Value * stavka.Kolicina;
                            }
                        }
                    }

                    list.Add(new ProdajaBasic
                    {
                        Id = p.Id,
                        ProdajnaJedinicaId = p.ProdajnaJedinica.Id,
                        DatumVreme = p.DatumVreme,
                        BlagajnikId = p.Blagajnik?.Id,
                        ProdajnaJedinicaNaziv = p.ProdajnaJedinica.Naziv,
                        BlagajnikIme = p.Blagajnik != null ? $"{p.Blagajnik.Ime} {p.Blagajnik.Prezime}" : "N/A",
                        UkupnaVrednost = ukupnaVrednost,
                        BrojStavki = brojStavki
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju prodaja za prodajnu jedinicu: " + ex.Message);
            }
            return list;
        }

        public static ProdajaBasic VratiProdaju(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var prodaja = s.Get<Prodaja>(id);
                if (prodaja != null)
                {
                    decimal ukupnaVrednost = 0;
                    int brojStavki = 0;

                    if (prodaja.Stavke != null)
                    {
                        brojStavki = prodaja.Stavke.Count;
                        foreach (var stavka in prodaja.Stavke)
                        {
                            if (stavka.Cena.HasValue)
                            {
                                ukupnaVrednost += stavka.Cena.Value * stavka.Kolicina;
                            }
                        }
                    }

                    return new ProdajaBasic
                    {
                        Id = prodaja.Id,
                        ProdajnaJedinicaId = prodaja.ProdajnaJedinica.Id,
                        DatumVreme = prodaja.DatumVreme,
                        BlagajnikId = prodaja.Blagajnik?.Id,
                        ProdajnaJedinicaNaziv = prodaja.ProdajnaJedinica.Naziv,
                        BlagajnikIme = prodaja.Blagajnik != null
                            ? $"{prodaja.Blagajnik.Ime} {prodaja.Blagajnik.Prezime}"
                            : "N/A",
                        UkupnaVrednost = ukupnaVrednost,
                        BrojStavki = brojStavki
                    };
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static long DodajProdaju(ProdajaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                var prodaja = new Prodaja
                {
                    ProdajnaJedinica = s.Load<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId),
                    DatumVreme = dto.DatumVreme,
                    Blagajnik = dto.BlagajnikId.HasValue ? 
                        s.Load<Zaposleni>(dto.BlagajnikId.Value) : null
                };
                s.Save(prodaja);
                s.Flush();

                // Uspešno je dodana prodaja

                return prodaja.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri dodavanju prodaje: " + ex.Message);
            }
        }

        public static void ObrisiProdaju(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var prodaja = s.Get<Prodaja>(id);
                if (prodaja != null)
                {
                    s.Delete(prodaja);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju prodaje: " + ex.Message);
            }
        }

        // === Helper funkcije za Prodaja ===
        public static IList<ZaposleniBasic> VratiSveBlagajnike()
        {
            var list = new List<ZaposleniBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var blagajnici = s.Query<Zaposleni>()
                    .Where(x => x.GetType().Name == "Blagajnik")
                    .ToList();
                foreach (var b in blagajnici)
                {
                    list.Add(new ZaposleniBasic
                    {
                        Id = b.Id,
                        Ime = b.Ime,
                        Prezime = b.Prezime,
                        DatumRodj = b.DatumRodj,
                        Adresa = b.Adresa,
                        Telefon = b.Telefon,
                        DatumZaposlenja = b.DatumZaposlenja
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
