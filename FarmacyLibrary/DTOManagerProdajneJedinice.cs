using FarmacyLibrary.Entiteti;
using FluentNHibernate.Data;
using NHibernate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacyLibrary
{
    public static class DTOManagerProdajneJedinice
    {
        // ========== PRODAJNE JEDINICE ==========

        public static void IzmeniMenadzerApoteka(MenadzerApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var ent = s.Query<MenadzerApoteka>()
                           .FirstOrDefault(x => x.Menadzer.Id == dto.IdMenadzera
                                             && x.ProdajnaJedinica.Id == dto.ProdajnaJedinicaId);

                if (ent != null)
                {
                    ent.Od = dto.Od;
                    ent.Do = dto.Do;
                }

                s.Update(ent);
                s.Flush();

                // Podaci o vezi su uspešno ažurirani!

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IList<MenadzerBasic> VratiMenadzereZaApoteku(long id)
        {
            var list = new List<MenadzerBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var menadzeri = s.Query<MenadzerApoteka>()
                    .Where(x => x.ProdajnaJedinica.Id == id)
                    .Select(x => x.Menadzer)
                    .ToList();

                foreach (var z in menadzeri)
                {
                    list.Add(new MenadzerBasic
                    {
                        Id = z.Id,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja
                    });
                }

                
            }

            
            catch(Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return list;
        }
        public static void DodajProdajnuJedinicu(ProdajnaJedinicaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var odgovorni = s.Load<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);

                var pj = new Entiteti.ProdajnaJedinica
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    OdgovorniFarmaceut = odgovorni
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void DodajApotekuSaLab(ApotekaSaLabBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);
                if (odgovorniFarmaceut == null)
                {
                    throw new ArgumentException("Odgovorni farmaceut sa tim ID-em ne postoji!");
                }

                var pj = new Entiteti.ApotekaSaLab
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,
                    OdgovorniFarmaceut = odgovorniFarmaceut
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DodajSpecApoteku(SpecijalizovanaApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);

                var pj = new Entiteti.SpecijalizovanaApoteka
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,
                    SpecijalnostTipa=dto.SpecijalnostTipa,
                    OdgovorniFarmaceut=odgovorniFarmaceut,
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void DodajStandardnuApoteku(StandardnaApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                
                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);
                
                
                var pj = new Entiteti.StandardnaApoteka
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,         
                    OdgovorniFarmaceut = odgovorniFarmaceut,
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ProdajnaJedinicaBasic VratiProdajnuJedinicu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Get<Entiteti.ProdajnaJedinica>(id);
                if (pj == null) return null;

                return new ProdajnaJedinicaBasic
                {
                    Id = pj.Id,
                    Naziv = pj.Naziv,
                    Ulica = pj.Ulica,
                    Broj = pj.Broj,
                    PostanskiBroj = pj.PostanskiBroj,
                    Mesto = pj.Mesto,
                    OdgovorniFarmaceutId = pj.OdgovorniFarmaceut?.Id ?? 0
                };
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return null;
        }

        public static Entiteti.ProdajnaJedinica VratiProdajnuJedinicuTip(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // 1) Apoteka sa laboratorijom
                var lab = s.Get<Entiteti.ApotekaSaLab>(id); // <-- ako ti se entitet zove drugačije, promeni ovde
                if (lab != null)
                {
                    return new ApotekaSaLab
                    {
                        Id = lab.Id,
                        Naziv = lab.Naziv,
                        Ulica = lab.Ulica,
                        Broj = lab.Broj,
                        PostanskiBroj = lab.PostanskiBroj,
                        Mesto = lab.Mesto,
                        // ako imaš navigaciono svojstvo:
                        OdgovorniFarmaceut = lab.OdgovorniFarmaceut,
                        Napomena = lab.Napomena
                    };
                }

                // 2) Specijalizovana apoteka
                var spec = s.Get<Entiteti.SpecijalizovanaApoteka>(id);
                if (spec != null)
                {
                    return new SpecijalizovanaApoteka
                    {
                        Id = spec.Id,
                        Naziv = spec.Naziv,
                        Ulica = spec.Ulica,
                        Broj = spec.Broj,
                        PostanskiBroj = spec.PostanskiBroj,
                        Mesto = spec.Mesto,
                        OdgovorniFarmaceut = spec.OdgovorniFarmaceut,
                        SpecijalnostTipa = spec.SpecijalnostTipa,
                        Napomena = spec.Napomena
                    };
                }

                var standardna= s.Get<Entiteti.StandardnaApoteka>(id);
                if (standardna != null)
                {
                    return new StandardnaApoteka
                    {
                        Id = standardna.Id,
                        Naziv = standardna.Naziv,
                        Ulica = standardna.Ulica,
                        Broj = standardna.Broj,
                        PostanskiBroj = standardna.PostanskiBroj,
                        Mesto = standardna.Mesto,
                        OdgovorniFarmaceut= standardna.OdgovorniFarmaceut,
                        Napomena = standardna.Napomena
                    };
                        
                }
                
                


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }
        public static IList<ProdajnaJedinicaBasic> VratiSveProdajneJedinice()
        {
            var list = new List<ProdajnaJedinicaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                foreach (var pj in s.Query<Entiteti.ProdajnaJedinica>())
                {
                    list.Add(new ProdajnaJedinicaBasic
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceutId = pj.OdgovorniFarmaceut?.Id ?? 0
                    });
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<ProdajnaJedinicaBasic> VratiOsnovneProdajneJedinice()
        {
            var list = new List<ProdajnaJedinicaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                // Uzmi samo osnovne prodajne jedinice (ne nasleđene)
                var osnovne = s.Query<Entiteti.ProdajnaJedinica>()
                    .Where(pj => !(pj is Entiteti.ApotekaSaLab) && 
                                 !(pj is Entiteti.StandardnaApoteka) && 
                                 !(pj is Entiteti.SpecijalizovanaApoteka))
                    .ToList();

                foreach (var pj in osnovne)
                {
                    list.Add(new ProdajnaJedinicaBasic
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceutId = pj.OdgovorniFarmaceut?.Id ?? 0
                    });
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<ApotekaSaLab> VratiApotekeSaLab()
        {
            var list = new List<ApotekaSaLab>();
            try
            {
                using var s = DataLayer.GetSession();
                foreach (var pj in s.Query<Entiteti.ApotekaSaLab>())
                {
                    list.Add(new ApotekaSaLab
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceut = pj.OdgovorniFarmaceut,
                        Napomena = pj.Napomena
                    });
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<StandardnaApoteka> VratiStandardneApoteke()
        {
            var list = new List<StandardnaApoteka>();
            try
            {
                using var s = DataLayer.GetSession();
                foreach (var pj in s.Query<Entiteti.StandardnaApoteka>())
                {
                    list.Add(new StandardnaApoteka
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceut = pj.OdgovorniFarmaceut,
                        Napomena = pj.Napomena
                    });
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static IList<SpecijalizovanaApoteka> VratiSpecijalizovaneApoteke()
        {
            var list = new List<SpecijalizovanaApoteka>();
            try
            {
                using var s = DataLayer.GetSession();
                foreach (var pj in s.Query<Entiteti.SpecijalizovanaApoteka>())
                {
                    list.Add(new SpecijalizovanaApoteka
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceut = pj.OdgovorniFarmaceut,
                        SpecijalnostTipa = pj.SpecijalnostTipa,
                        Napomena = pj.Napomena
                    });
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void IzmeniProdajnuJedinicu(ProdajnaJedinicaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<Entiteti.ProdajnaJedinica>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = s.Load<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);

                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public static void IzmeniSpecApoetku(SpecijalizovanaApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);
                
                var pj = s.Load<Entiteti.SpecijalizovanaApoteka>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = odgovorniFarmaceut;
                pj.SpecijalnostTipa = dto.SpecijalnostTipa;
               

                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public static void IzmeniSApoetku(StandardnaApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<Entiteti.StandardnaApoteka>(dto.Id);

                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);
                
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = odgovorniFarmaceut;
                


                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public static void IzmeniApotekuSaLab(ApotekaSaLabBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<Entiteti.ApotekaSaLab>(dto.Id);
                var odgovorniFarmaceut = s.Get<Entiteti.Farmaceut>(dto.OdgovorniFarmaceutId);
                if (odgovorniFarmaceut == null)
                {
                    throw new ArgumentException("Odgovorni farmaceut sa tim ID-em ne postoji!");
                }
                
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.Napomena = dto.Napomena;
                pj.OdgovorniFarmaceut = odgovorniFarmaceut;

                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ObrisiProdajnuJedinicu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Get<Entiteti.ProdajnaJedinica>(id);
                if (pj != null)
                {
                    s.Delete(pj);
                    s.Flush();
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        // ========== MENADŽER – APOTEKA ==========

        public static void DodajMenadzerApoteka(MenadzerApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = s.Get<Entiteti.Menadzer>(dto.IdMenadzera);
                var p = s.Get<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId);

                var radnov = new MenadzerApoteka
                {
                    Menadzer=m,
                    ProdajnaJedinica=p,
                    Do=dto.Do,
                    Od=dto.Od,
                    datumKontrole=dto.datumKontrole,
                };
                   


                s.Save(radnov);
                s.Flush();

                // Kontrola apoteke kreirana uspesno
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DodeliMenadzeraApoteci(MenadzerApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = s.Load<Entiteti.Menadzer>(dto.IdMenadzera);
                var pj = s.Load<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId);

                var veza = new MenadzerApoteka
                {
                    Menadzer = m,
                    ProdajnaJedinica = pj,
                    Od = dto.Od,
                    Do = dto.Do
                };

                s.Save(veza);
                s.Flush();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public static IList<MenadzerApotekaBasic> VratiApotekeMenadzera(long mbrMenadzera)
        {
            var list = new List<MenadzerApotekaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var veze = s.Query<MenadzerApoteka>()
                    .Where(x => x.Menadzer.Id == mbrMenadzera).ToList();

                list.AddRange(veze.Select(x => new MenadzerApotekaBasic
                {
                    IdMenadzera = x.Menadzer.Id,
                    ProdajnaJedinicaId = x.ProdajnaJedinica.Id,
                    Od = x.Od,
                    Do = x.Do
                }));
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return list;
        }

        public static void UkloniMenadzeraSaApoteke(long idA,long idM)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var ent = s.Query<MenadzerApoteka>()
                    .FirstOrDefault(x => x.Menadzer.Id == idM
                                         && x.ProdajnaJedinica.Id == idA);

                if (ent != null)
                {
                    s.Delete(ent);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        // ========== RADNO VREME ==========

        public static IList<RadnoVremeBasic> VratiRadnoVremeZaProdajnuJedinicu(long prodajnaJedinicaId)
        {
            var list = new List<RadnoVremeBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var radnaVremena = s.Query<RadnoVreme>()
                    .Where(rv => rv.ProdajnaJedinica.Id == prodajnaJedinicaId)
                    .ToList();

                string[] dani = { "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" };

                foreach (var rv in radnaVremena)
                {
                    list.Add(new RadnoVremeBasic
                    {
                        Id = rv.ProdajnaJedinica.Id * 100 + rv.Dan, // Composite key simulation
                        ProdajnaJedinicaId = rv.ProdajnaJedinica.Id,
                        Dan = rv.Dan,
                        VremeOd = rv.VremeOd,
                        VremeDo = rv.VremeDo,
                        DanNaziv = dani[rv.Dan - 1],
                        ProdajnaJedinicaNaziv = rv.ProdajnaJedinica.Naziv
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju radnog vremena: " + ex.Message);
            }
            return list;
        }

        public static RadnoVremeBasic VratiRadnoVreme(long prodajnaJedinicaId, int dan)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var rv = s.Query<RadnoVreme>()
                    .FirstOrDefault(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId && x.Dan == dan);
                if (rv != null)
                {
                    string[] dani = { "Ponedeljak", "Utorak", "Sreda", "Četvrtak", "Petak", "Subota", "Nedelja" };
                    return new RadnoVremeBasic
                    {
                        Id = rv.ProdajnaJedinica.Id * 100 + rv.Dan, // Composite key simulation
                        ProdajnaJedinicaId = rv.ProdajnaJedinica.Id,
                        Dan = rv.Dan,
                        VremeOd = rv.VremeOd,
                        VremeDo = rv.VremeDo,
                        DanNaziv = dani[rv.Dan - 1],
                        ProdajnaJedinicaNaziv = rv.ProdajnaJedinica.Naziv
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju radnog vremena: " + ex.Message);
            }
            return null;
        }

        public static void IzmeniRadnoVreme(RadnoVremeBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var rv = s.Query<RadnoVreme>()
                    .FirstOrDefault(x => x.ProdajnaJedinica.Id == dto.ProdajnaJedinicaId && x.Dan == dto.Dan);
                if (rv != null)
                {
                    // Ažuriraj postojeći zapis
                    rv.VremeOd = dto.VremeOd ?? DateTime.MinValue;
                    rv.VremeDo = dto.VremeDo ?? DateTime.MinValue;
                    s.Update(rv);
                    s.Flush();
                }
                else
                {
                    // Kreiraj novi zapis ako ne postoji
                    var prodajnaJedinica = s.Query<Entiteti.ProdajnaJedinica>()
                        .FirstOrDefault(x => x.Id == dto.ProdajnaJedinicaId);
                    if (prodajnaJedinica != null)
                    {
                        var noviRadnoVreme = new RadnoVreme
                        {
                            ProdajnaJedinica = prodajnaJedinica,
                            Dan = dto.Dan,
                            VremeOd = dto.VremeOd ?? DateTime.MinValue,
                            VremeDo = dto.VremeDo ?? DateTime.MinValue
                        };
                        s.Save(noviRadnoVreme);
                        s.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri izmeni radnog vremena: " + ex.Message);
            }
        }

        public static void DodajRadnoVreme(RadnoVremeBasic dto)
        {
            try
            {
                // Proveri da li postoje vrednosti za radno vreme
                if (!dto.VremeOd.HasValue || !dto.VremeDo.HasValue)
                {
                    throw new Exception("Morate uneti i početno i krajnje vreme!");
                }

                using var s = DataLayer.GetSession();
                var prodajnaJedinica = s.Load<Entiteti.ProdajnaJedinica>(dto.ProdajnaJedinicaId);
                var rv = new RadnoVreme
                {
                    ProdajnaJedinica = prodajnaJedinica,
                    Dan = dto.Dan,
                    VremeOd = dto.VremeOd.Value,
                    VremeDo = dto.VremeDo.Value
                };
                s.Save(rv);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri dodavanju radnog vremena: " + ex.Message);
            }
        }

        public static void ObrisiRadnoVreme(long prodajnaJedinicaId, int dan)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var rv = s.Query<RadnoVreme>()
                    .FirstOrDefault(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId && x.Dan == dan);
                if (rv != null)
                {
                    s.Delete(rv);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri brisanju radnog vremena: " + ex.Message);
            }
        }

        public static bool PostojiRadnoVremeZaProdajnuJedinicu(long prodajnaJedinicaId)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var count = s.Query<RadnoVreme>()
                    .Count(x => x.ProdajnaJedinica.Id == prodajnaJedinicaId);
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri proveri radnog vremena: " + ex.Message);
            }
        }

        public static IList<FarmaceutBasic> VratiSveFarmaceuteUSistemu()
        {
            var list = new List<FarmaceutBasic>();

            try
            {
                using var s = DataLayer.GetSession();
                var rv = s.Query<RasporedRada>().ToList();
                  


                foreach (var x in rv)
                {
                    var z=DTOManagerZaposleni.VratiZaposlenog(x.Zaposleni.Id);
                    if(z is FarmaceutBasic f)
                    {
                        list.Add(f);
                    }
                    
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju radnog vremena: " + ex.Message);
            }
            return list;
        }

        public static IList<FarmaceutBasic> VratiSveFarmaceuteZaApoteku(long id)
        {
            var list = new List<FarmaceutBasic>();

            try
            {
                using var s = DataLayer.GetSession();
                var rv = s.Query<RasporedRada>().
                    Where(x=>x.ProdajnaJedinica.Id==id).
                    ToList();




                foreach (var x in rv)
                {
                    var z = DTOManagerZaposleni.VratiZaposlenog(x.Zaposleni.Id);
                    if (z is FarmaceutBasic f)
                    {
                        list.Add(f);
                    }

                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Greška pri učitavanju radnog vremena: " + ex.Message);
            }
            return list;
        }

        
    }
}
