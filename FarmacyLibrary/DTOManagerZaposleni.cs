using FarmacyLibrary.Entiteti;
using FluentNHibernate.Data;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarmacyLibrary
{
    public static class DTOManagerZaposleni
    {
        // ========== ZAPOSLENI & PODTIPOVI ==========

        public static void DodajFarmaceuta(FarmaceutBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var f = new Entiteti.Farmaceut
                {
                    Id = dto.Id,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    DatumDiplomiranja = dto.DatumDiplomiranja,
                    BrLicence = dto.BrLicence,
                    DatumPoslObnoveLicence = dto.DatumPoslednjeObnoveLicence,
                    Specijalnost = dto.Specijalnost,
                    MatBr = dto.MatBr
                };
                s.Save(f);
                s.Flush();
                
                // Ažuriraj MBr u DTO-u
                dto.Id = f.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateFarmaceuta(FarmaceutBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var farmaceut = s.Get<Entiteti.Farmaceut>(dto.Id);

                if (farmaceut == null)
                {
                    return;
                }

                farmaceut.Ime = dto.Ime;
                farmaceut.Prezime = dto.Prezime;
                farmaceut.DatumRodj = dto.DatumRodj;
                farmaceut.Adresa = dto.Adresa;
                farmaceut.Telefon = dto.Telefon;
                farmaceut.DatumZaposlenja = dto.DatumZaposlenja;
                farmaceut.DatumDiplomiranja = dto.DatumDiplomiranja;
                farmaceut.BrLicence = dto.BrLicence;
                farmaceut.DatumPoslObnoveLicence = dto.DatumPoslednjeObnoveLicence;
                farmaceut.Specijalnost = dto.Specijalnost;
                farmaceut.MatBr = dto.MatBr;

                s.Update(farmaceut);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void DodajTehnicara(TehnicarBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var t = new Tehnicar
                {
                    Id = dto.Id,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    NivoObrazovanja = dto.NivoObrazovanja,
                    MatBr = dto.MatBr
                };
                s.Save(t);
                s.Flush();
                
                // Ažuriraj MBr u DTO-u
                dto.Id = t.Id;

                if (dto.Sertifikacije.Count > 0)
                {
                    foreach (var cert in dto.Sertifikacije)
                    {
                        var c = new TehnicarSertifikacija
                        {
                            Naziv = cert.Naziv,
                            Datum = cert.Datum,
                            Tehnicar = t
                        };
                        s.Save(c);
                    }
                }

                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateTehnicara(TehnicarBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var tehnicar = s.Get<Tehnicar>(dto.Id);

                if (tehnicar == null)
                {
                    return;
                }

                tehnicar.Ime = dto.Ime;
                tehnicar.Prezime = dto.Prezime;
                tehnicar.DatumRodj = dto.DatumRodj;
                tehnicar.Adresa = dto.Adresa;
                tehnicar.Telefon = dto.Telefon;
                tehnicar.DatumZaposlenja = dto.DatumZaposlenja;
                tehnicar.NivoObrazovanja = dto.NivoObrazovanja;
                tehnicar.MatBr = dto.MatBr;

                s.Update(tehnicar);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void DodajMenadzera(MenadzerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = new Entiteti.Menadzer
                {
                    Id = dto.Id,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    MatBr = dto.MatBr,
                };
                s.Save(m);
                s.Flush();
                
                // Ažuriraj MBr u DTO-u
                dto.Id = m.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateMenadzera(MenadzerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var menadzer = s.Get<Entiteti.Menadzer>(dto.Id);

                if (menadzer == null)
                {
                    return;
                }

                menadzer.Ime = dto.Ime;
                menadzer.Prezime = dto.Prezime;
                menadzer.DatumRodj = dto.DatumRodj;
                menadzer.Adresa = dto.Adresa;
                menadzer.Telefon = dto.Telefon;
                menadzer.DatumZaposlenja = dto.DatumZaposlenja;
                menadzer.MatBr = dto.MatBr;

                s.Update(menadzer);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DodajZaposlenog(ZaposleniBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = new Zaposleni
                {
                    Id = dto.Id,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    MatBr = dto.MatBr
                };
                s.Save(m);
                s.Flush();
                
                // Ažuriraj MBr u DTO-u
                dto.Id = m.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void UpdateZaposlenog(ZaposleniBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // Pronađi postojećeg zaposlenog u bazi
                var zaposleni = s.Get<Zaposleni>(dto.Id);

                if (zaposleni == null)
                {
                    return;
                }

                // Ažuriraj polja
                zaposleni.Ime = dto.Ime;
                zaposleni.Prezime = dto.Prezime;
                zaposleni.DatumRodj = dto.DatumRodj;
                zaposleni.Adresa = dto.Adresa;
                zaposleni.Telefon = dto.Telefon;
                zaposleni.DatumZaposlenja = dto.DatumZaposlenja;
                zaposleni.MatBr = dto.MatBr;

                // Sačuvaj izmene
                s.Update(zaposleni);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ZaposleniBasic? VratiZaposlenog(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // NH polimorfno: prvo probaj specifičan tip
                var f = s.Get<Entiteti.Farmaceut>(id);
                if (f != null)
                {
                    return new FarmaceutBasic
                    {
                        Id = f.Id,
                        Ime = f.Ime,
                        Prezime = f.Prezime,
                        DatumRodj = f.DatumRodj,
                        Adresa = f.Adresa,
                        Telefon = f.Telefon,
                        DatumZaposlenja = f.DatumZaposlenja,
                        DatumDiplomiranja = f.DatumDiplomiranja,
                        BrLicence = f.BrLicence,
                        DatumPoslednjeObnoveLicence = f.DatumPoslObnoveLicence,
                        Specijalnost = f.Specijalnost,
                        MatBr = f.MatBr
                    };
                }

                var t = s.Get<Tehnicar>(id);
                if (t != null)
                {
                    var tb = new TehnicarBasic
                    {
                        Id = t.Id,
                        Ime = t.Ime,
                        Prezime = t.Prezime,
                        DatumRodj = t.DatumRodj,
                        Adresa = t.Adresa,
                        Telefon = t.Telefon,
                        DatumZaposlenja = t.DatumZaposlenja,
                        NivoObrazovanja = t.NivoObrazovanja,
                        MatBr = t.MatBr
                    };

                    //var certs = s.Query<TehnicarSertifikacija>()
                    //             .Where(x => x.Tehnicar.MBr == t.MBr)
                    //             .Select(x => new TehnicarSertifikacijaBasic
                    //             {
                    //                 MBrTehnicara = x.Tehnicar.MBr,
                    //                 Naziv = x.Naziv,
                    //                 Datum = x.Datum
                    //             }).ToList();
                    //tb.Sertifikacije = certs;
                    return tb;
                }

                var m = s.Get<Entiteti.Menadzer>(id);
                if (m != null)
                {
                    return new MenadzerBasic
                    {
                        Id = m.Id,
                        Ime = m.Ime,
                        Prezime = m.Prezime,
                        DatumRodj = m.DatumRodj,
                        Adresa = m.Adresa,
                        Telefon = m.Telefon,
                        DatumZaposlenja = m.DatumZaposlenja,
                        MatBr = m.MatBr
                    };
                }

                var z = s.Get<Zaposleni>(id);
                if (z != null)
                {
                    return new ZaposleniBasic
                    {
                        Id = z.Id,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja,
                        MatBr = z.MatBr
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static FarmaceutBasic? VratiFarmaceuta(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var f = s.Get<Entiteti.Farmaceut>(mbr);
                if (f != null)
                {
                    return new FarmaceutBasic
                    {
                        Id = f.Id,
                        Ime = f.Ime,
                        Prezime = f.Prezime,
                        DatumRodj = f.DatumRodj,
                        Adresa = f.Adresa,
                        Telefon = f.Telefon,
                        DatumZaposlenja = f.DatumZaposlenja,
                        DatumDiplomiranja = f.DatumDiplomiranja,
                        BrLicence = f.BrLicence,
                        DatumPoslednjeObnoveLicence = f.DatumPoslObnoveLicence,
                        Specijalnost = f.Specijalnost,
                        MatBr = f.MatBr
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static TehnicarBasic? VratiTehnicara(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var t = s.Get<Tehnicar>(mbr);
                if (t != null)
                {
                    return new TehnicarBasic
                    {
                        Id = t.Id,
                        Ime = t.Ime,
                        Prezime = t.Prezime,
                        DatumRodj = t.DatumRodj,
                        Adresa = t.Adresa,
                        Telefon = t.Telefon,
                        DatumZaposlenja = t.DatumZaposlenja,
                        NivoObrazovanja = t.NivoObrazovanja,
                        MatBr = t.MatBr
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static MenadzerBasic? VratiMenadzera(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = s.Get<Entiteti.Menadzer>(mbr);
                if (m != null)
                {
                    return new MenadzerBasic
                    {
                        Id = m.Id,
                        Ime = m.Ime,
                        Prezime = m.Prezime,
                        DatumRodj = m.DatumRodj,
                        Adresa = m.Adresa,
                        Telefon = m.Telefon,
                        DatumZaposlenja = m.DatumZaposlenja,
                        MatBr = m.MatBr
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<MenadzerBasic> VratiSveMenadzere()
        {
            var list = new List<MenadzerBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var menadzeri = s.Query<Entiteti.Menadzer>().ToList();
                foreach (var m in menadzeri)
                {
                    list.Add(new MenadzerBasic
                    {
                        Id = m.Id,
                        Ime = m.Ime,
                        Prezime = m.Prezime,
                        DatumRodj = m.DatumRodj,
                        Adresa = m.Adresa,
                        Telefon = m.Telefon,
                        DatumZaposlenja = m.DatumZaposlenja,
                        MatBr = m.MatBr
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static Entiteti.Farmaceut? VratiOdgovornogFarmaceuta(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var f = s.Get<Entiteti.Farmaceut>(id); // ovde NE ide FarmaceutBasic
                if (f != null)
                {
                    return f;
                }

                return null; // ako nema farmaceuta
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<ZaposleniBasic> VratiSveZaposlene()
        {
            var list = new List<ZaposleniBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var svi = s.Query<Zaposleni>().ToList();
                foreach (var z in svi)
                {
                    list.Add(new ZaposleniBasic
                    {
                        Id = z.Id,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja,
                        MatBr = z.MatBr
                    });
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void ObrisiZaposlenog(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var selektovaniZaposleni = VratiZaposlenog(mbr);
                
                if (selektovaniZaposleni is FarmaceutBasic faramaceut)
                {
                    var z = s.Get<Entiteti.Farmaceut>(mbr);
                    var p = s.Query<Entiteti.ProdajnaJedinica>()
                        .Where(p => p.OdgovorniFarmaceut == z)
                        .ToList();

                    if(p.Count > 0)
                    {
                     
                         throw new Exception($"Farmaceut je odgovran za apoteku {p[0].Naziv}, pa ne moze biti izbrisan!");
                    }


                }
                else if (selektovaniZaposleni is TehnicarBasic tehnicar)
                {

                    var z = s.Get<Tehnicar>(mbr);
                    var sertifikacije=s.Query<Entiteti.TehnicarSertifikacija>().
                                        Where(p=>p.Tehnicar==z)
                                        .ToList();
                    if(sertifikacije.Count > 0)
                    {
                        foreach(var s1  in sertifikacije)
                        {
                            s.Delete(s1);
                            s.Flush();

                        }
                        // Sertifikacije tehnicara su uspesno obrisane
                    }


                }
                else if (selektovaniZaposleni is MenadzerBasic menadzer)
                {
                    var z = s.Get<Entiteti.Menadzer>(mbr);
                    var odgovran = s.Query<Entiteti.MenadzerApoteka>()
                                    .Where(m=>m.Menadzer==z)
                                    .ToList();
                    if( odgovran.Count > 0 )
                    {
                        foreach(var m in odgovran)
                        {
                            s.Delete(m);
                            s.Flush();

                        }
                        // Kontrole apoteka od strane menadzera su obrisane!
                    }

                }

                var z1 = s.Get<Entiteti.Zaposleni>(mbr);
                

                var ras=s.Query<RasporedRada>().Where(r=>r.Zaposleni==z1).ToList();

                if (ras.Count > 0)
                {
                    foreach (var r in ras)
                    {
                        s.Delete(r);
                        s.Flush();
                    }
                    // Obrisan je raspored rada za zaposlenog.
                }


                if (z1 != null)
                {
                    s.Delete(z1);
                    s.Flush();
                }
                // Zaposleni uspesno obirsan.
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public static void IzmeniRadnoMesto(long mbr,long idRadnogMesta,int smena1)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var raspored=s.Query<RasporedRada>()
                    .Where(r => r.Zaposleni.Id==mbr).FirstOrDefault();

                

                var novi = new RasporedRadaBasic
                {
                    ProdajnaJedinicaId = idRadnogMesta,
                    Id = mbr,
                    Pocetak = raspored.Pocetak,
                    Kraj = raspored.Kraj,
                    BrojSmene = smena1
                };

                s.Delete(raspored);
                s.Flush();

                DodajRasporedRada(novi);
                
                // Promena radnog mesta uspesna
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void IzbrisiRasporedRada(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var raspored = s.Query<RasporedRada>()
                    .Where(r => r.Zaposleni.Id == mbr).FirstOrDefault();

                



                s.Delete(raspored);
                s.Flush();

                // Raspored rada izbrisan
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static RasporedRadaBasic VratiRasporedRada(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var raspored = s.Query<RasporedRada>()
                    .Where(r => r.Zaposleni.Id == mbr).FirstOrDefault();

                if (raspored == null)
                {
                    throw new Exception($"Zaposleni nema raspored rada");
                }

                return (new RasporedRadaBasic
                {
                    ProdajnaJedinicaId = raspored.ProdajnaJedinica.Id,
                    Id = raspored.Zaposleni.Id,
                    Pocetak = raspored.Pocetak,
                    Kraj = raspored.Kraj,

                });




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        // ========== RASPORED RADA ==========

        public static void DodajRasporedRada(RasporedRadaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                // Proveri da li zaposleni postoji
                var zaposleni = s.Get<Zaposleni>(dto.Id);
                if (zaposleni == null)
                {
                    return;
                }
                
                // Proveri da li prodajna jedinica postoji
                var prodajnaJedinica = s.Get<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId);
                if (prodajnaJedinica == null)
                {
                    return;
                }
                
                var raspored = new RasporedRada
                {
                    Zaposleni = zaposleni,
                    ProdajnaJedinica = prodajnaJedinica,
                    Pocetak = dto.Pocetak,
                    Kraj = dto.Kraj,
                    BrojSmene = dto.BrojSmene
                };
                
                s.Save(raspored);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<RasporedRadaBasic> VratiRasporedRadaZaZaposlenog(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var query = s.Query<RasporedRada>()
                    .Where(rr => rr.Zaposleni.Id == mbr)
                    .Select(rr => new RasporedRadaBasic
                    {
                        Id = rr.Zaposleni.Id,
                        ProdajnaJedinicaId = rr.ProdajnaJedinica.Id,
                        Pocetak = rr.Pocetak,
                        Kraj = rr.Kraj,
                        BrojSmene = rr.BrojSmene,
                        ZaposleniIme = rr.Zaposleni.Ime,
                        ZaposleniPrezime = rr.Zaposleni.Prezime,
                        ProdajnaJedinicaNaziv = rr.ProdajnaJedinica.Naziv,
                        SmenaNaziv = rr.BrojSmene == null ? "Nije dodeljena" : 
                                   rr.BrojSmene == 1 ? "Prva smena" :
                                   rr.BrojSmene == 2 ? "Druga smena" : "Treća smena"
                    });
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<RasporedRadaBasic> VratiRasporedRadaZaProdajnuJedinicu(long prodajnaJedinicaId)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                // Privremeno rešenje - direktan SQL upit dok se ne restaruje aplikacija
                var sql = @"
                    SELECT rr.m_br, rr.prodajna_jedinica_id, rr.pocetak, rr.kraj, rr.broj_smene,
                           z.ime, z.prezime, pj.naziv
                    FROM Raspored_rada rr
                    LEFT JOIN Zaposleni z ON rr.m_br = z.m_br
                    LEFT JOIN Prodajna_Jedinica pj ON rr.prodajna_jedinica_id = pj.id
                    WHERE rr.prodajna_jedinica_id = :p0";
                
                var query = s.CreateSQLQuery(sql)
                    .SetParameter("p0", prodajnaJedinicaId);
                
                var results = query.List();
                var rasporedList = new List<RasporedRadaBasic>();
                
                foreach (object[] row in results)
                {
                    var raspored = new RasporedRadaBasic
                    {
                        Id = Convert.ToInt64(row[0]),
                        ProdajnaJedinicaId = Convert.ToInt64(row[1]),
                        Pocetak = Convert.ToDateTime(row[2]),
                        Kraj = Convert.ToDateTime(row[3]),
                        BrojSmene = row[4] != null ? Convert.ToInt32(row[4]) : (int?)null,
                        ZaposleniIme = row[5]?.ToString() ?? "",
                        ZaposleniPrezime = row[6]?.ToString() ?? "",
                        ProdajnaJedinicaNaziv = row[7]?.ToString() ?? "",
                        SmenaNaziv = row[4] == null ? "Nije dodeljena" : 
                                   Convert.ToInt32(row[4]) == 1 ? "Prva smena" :
                                   Convert.ToInt32(row[4]) == 2 ? "Druga smena" : "Treća smena"
                    };
                    rasporedList.Add(raspored);
                }
                
                return rasporedList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<RasporedRadaBasic> VratiSveRasporedeRada()
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                // Privremeno rešenje - direktan SQL upit dok se ne restaruje aplikacija
                var sql = @"
                    SELECT rr.m_br, rr.prodajna_jedinica_id, rr.pocetak, rr.kraj, rr.broj_smene,
                           z.ime, z.prezime, pj.naziv
                    FROM Raspored_rada rr
                    LEFT JOIN Zaposleni z ON rr.m_br = z.m_br
                    LEFT JOIN Prodajna_Jedinica pj ON rr.prodajna_jedinica_id = pj.id
                    ORDER BY rr.pocetak";
                
                var query = s.CreateSQLQuery(sql);
                var results = query.List();
                var rasporedList = new List<RasporedRadaBasic>();
                
                foreach (object[] row in results)
                {
                    var raspored = new RasporedRadaBasic
                    {
                        Id = Convert.ToInt64(row[0]),
                        ProdajnaJedinicaId = Convert.ToInt64(row[1]),
                        Pocetak = Convert.ToDateTime(row[2]),
                        Kraj = Convert.ToDateTime(row[3]),
                        BrojSmene = row[4] != null ? Convert.ToInt32(row[4]) : (int?)null,
                        ZaposleniIme = row[5]?.ToString() ?? "",
                        ZaposleniPrezime = row[6]?.ToString() ?? "",
                        ProdajnaJedinicaNaziv = row[7]?.ToString() ?? "",
                        SmenaNaziv = row[4] == null ? "Nije dodeljena" : 
                                   Convert.ToInt32(row[4]) == 1 ? "Prva smena" :
                                   Convert.ToInt32(row[4]) == 2 ? "Druga smena" : "Treća smena"
                    };
                    rasporedList.Add(raspored);
                }
                
                return rasporedList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ObrisiRasporedRada(long mbr, long prodajnaJedinicaId, DateTime pocetak)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var raspored = s.Query<RasporedRada>()
                    .FirstOrDefault(rr => rr.Zaposleni.Id == mbr 
                                       && rr.ProdajnaJedinica.Id == prodajnaJedinicaId 
                                       && rr.Pocetak == pocetak);
                
                if (raspored != null)
                {
                    s.Delete(raspored);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
  
}
