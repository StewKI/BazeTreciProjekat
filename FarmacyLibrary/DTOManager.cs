
using FarmacyLibrary.Entiteti;

namespace FarmacyLibrary
{
    public static class DTOManager
    {
        // ========== ZAPOSLENI & PODTIPOVI ==========

        public static void DodajFarmaceuta(FarmaceutBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var f = new Farmaceut
                {
                    MBr = dto.MBr,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    DatumDiplomiranja = dto.DatumDiplomiranja,
                    BrLicence = dto.BrLicence,
                    DatumPoslObnoveLicence = dto.DatumPoslednjeObnoveLicence,
                    Specijalnost = dto.Specijalnost
                };
                s.Save(f);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju farmaceuta.", ex);
            }
        }

        public static void UpdateFarmaceuta(FarmaceutBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var farmaceut = s.Get<Farmaceut>(dto.MBr);

                if (farmaceut == null)
                {
                    throw new KeyNotFoundException("Farmaceut sa datim MBr ne postoji.");
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

                s.Update(farmaceut);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri ažuriranju farmaceuta.", ex);
            }
        }


        public static void DodajTehnicara(TehnicarBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var t = new Tehnicar
                {
                    //MBr = dto.MBr,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja,
                    NivoObrazovanja = dto.NivoObrazovanja
                };
                s.Save(t);

                //foreach (var cert in dto.Sertifikacije)
                //{
                //    var c = new TehnicarSertifikacija
                //    {
                //        Naziv = cert.Naziv,
                //        Datum = cert.Datum,
                //        Tehnicar = t
                //    };
                //    s.Save(c);
                //}

                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju tehničara.", ex);
            }
        }

        public static void UpdateTehnicara(TehnicarBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var tehnicar = s.Get<Tehnicar>(dto.MBr);

                if (tehnicar == null)
                {
                    throw new KeyNotFoundException("Tehničar sa datim MBr ne postoji.");
                }

                tehnicar.Ime = dto.Ime;
                tehnicar.Prezime = dto.Prezime;
                tehnicar.DatumRodj = dto.DatumRodj;
                tehnicar.Adresa = dto.Adresa;
                tehnicar.Telefon = dto.Telefon;
                tehnicar.DatumZaposlenja = dto.DatumZaposlenja;
                tehnicar.NivoObrazovanja = dto.NivoObrazovanja;

                // Brišemo stare sertifikate
                //foreach (var stari in tehnicar.Sertifikacije.ToList())
                //{
                //    s.Delete(stari);
                //}

                // Dodajemo nove
                //foreach (var cert in dto.Sertifikacije)
                //{
                //    var c = new TehnicarSertifikacija
                //    {
                //        Naziv = cert.Naziv,
                //        Datum = cert.Datum,
                //        Tehnicar = tehnicar
                //    };
                //    s.Save(c);
                //}

                s.Update(tehnicar);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri ažuriranju tehničara.", ex);
            }
        }


        public static void DodajMenadzera(MenadzerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = new FarmacyLibrary.Entiteti.Menadzer
                {
                    MBr = dto.MBr,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja
                };
                s.Save(m);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju menadžera.", ex);
            }
        }

        public static void UpdateMenadzera(MenadzerBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var menadzer = s.Get<FarmacyLibrary.Entiteti.Menadzer>(dto.MBr);

                if (menadzer == null)
                {
                    throw new KeyNotFoundException("Menadžer sa datim MBr ne postoji.");
                }

                menadzer.Ime = dto.Ime;
                menadzer.Prezime = dto.Prezime;
                menadzer.DatumRodj = dto.DatumRodj;
                menadzer.Adresa = dto.Adresa;
                menadzer.Telefon = dto.Telefon;
                menadzer.DatumZaposlenja = dto.DatumZaposlenja;

                s.Update(menadzer);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri ažuriranju menadžera.", ex);
            }
        }

        public static void DodajZaposlenog(ZaposleniBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = new Zaposleni
                {
                    MBr = dto.MBr,
                    Ime = dto.Ime,
                    Prezime = dto.Prezime,
                    DatumRodj = dto.DatumRodj,
                    Adresa = dto.Adresa,
                    Telefon = dto.Telefon,
                    DatumZaposlenja = dto.DatumZaposlenja
                };
                s.Save(m);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju zaposlenog.", ex);
            }
        }

        public static void UpdateZaposlenog(ZaposleniBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // Pronađi postojećeg zaposlenog u bazi
                var zaposleni = s.Get<Zaposleni>(dto.MBr);

                if (zaposleni == null)
                {
                    throw new KeyNotFoundException("Zaposleni sa datim MBr ne postoji u bazi.");
                }

                // Ažuriraj polja
                zaposleni.Ime = dto.Ime;
                zaposleni.Prezime = dto.Prezime;
                zaposleni.DatumRodj = dto.DatumRodj;
                zaposleni.Adresa = dto.Adresa;
                zaposleni.Telefon = dto.Telefon;
                zaposleni.DatumZaposlenja = dto.DatumZaposlenja;

                // Sačuvaj izmene
                s.Update(zaposleni);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri ažuriranju zaposlenog.", ex);
            }
        }

        public static ZaposleniBasic? VratiZaposlenog(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // NH polimorfno: prvo probaj specifičan tip
                var f = s.Get<Farmaceut>(mbr);
                if (f != null)
                {
                    return new FarmaceutBasic
                    {
                        MBr = f.MBr,
                        Ime = f.Ime,
                        Prezime = f.Prezime,
                        DatumRodj = f.DatumRodj,
                        Adresa = f.Adresa,
                        Telefon = f.Telefon,
                        DatumZaposlenja = f.DatumZaposlenja,
                        DatumDiplomiranja = f.DatumDiplomiranja,
                        BrLicence = f.BrLicence,
                        DatumPoslednjeObnoveLicence = f.DatumPoslObnoveLicence,
                        Specijalnost = f.Specijalnost
                    };
                }

                var t = s.Get<Tehnicar>(mbr);
                if (t != null)
                {
                    var tb = new TehnicarBasic
                    {
                        MBr = t.MBr,
                        Ime = t.Ime,
                        Prezime = t.Prezime,
                        DatumRodj = t.DatumRodj,
                        Adresa = t.Adresa,
                        Telefon = t.Telefon,
                        DatumZaposlenja = t.DatumZaposlenja,
                        NivoObrazovanja = t.NivoObrazovanja
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

                var m = s.Get<FarmacyLibrary.Entiteti.Menadzer>(mbr);
                if (m != null)
                {
                    return new MenadzerBasic
                    {
                        MBr = m.MBr,
                        Ime = m.Ime,
                        Prezime = m.Prezime,
                        DatumRodj = m.DatumRodj,
                        Adresa = m.Adresa,
                        Telefon = m.Telefon,
                        DatumZaposlenja = m.DatumZaposlenja
                    };
                }

                var z = s.Get<Zaposleni>(mbr);
                if (z != null)
                {
                    return new ZaposleniBasic
                    {
                        MBr = z.MBr,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja
                    };
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izvlačenju zaposlenog iz baze.", ex);
            }

            return null;
        }

        public static Farmaceut? VratiOdgovornogFarmaceuta(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();

                var f = s.Get<Farmaceut>(id); // ovde NE ide Farmaceut
                if (f != null)
                {
                    return f;
                }

                return null; // ako nema farmaceuta
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju odgovornog farmaceuta.", ex);
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
                        MBr = z.MBr,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izvlacenju svih zaposlenih.", ex);
            }

            return list;
        }

        public static void ObrisiZaposlenog(long mbr)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var z = s.Get<Zaposleni>(mbr);
                if (z != null)
                {
                    s.Delete(z);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri brisanju zaposlenog.", ex);
            }
        }

        // ========== PRODAJNE JEDINICE ==========

        public static void IzmeniMenadzerApoteka(MenadzerApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var ent = s.Query<MenadzerApoteka>()
                    .FirstOrDefault(x => x.Menadzer.MBr == dto.MBrMenadzera
                                         && x.ProdajnaJedinica.Id == dto.ProdajnaJedinicaId);

                if (ent == null)
                {
                    throw new KeyNotFoundException("Veza Menadžer–Apoteka nije pronađena.");
                }

                ent.Od = dto.Od;
                ent.Do = dto.Do;

                s.Update(ent);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri promeni veze MenadzerApoteka.", ex);
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
                        MBr = z.MBr,
                        Ime = z.Ime,
                        Prezime = z.Prezime,
                        DatumRodj = z.DatumRodj,
                        Adresa = z.Adresa,
                        Telefon = z.Telefon,
                        DatumZaposlenja = z.DatumZaposlenja
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju menadžera za apoteku.", ex);
            }

            return list;
        }

        public static void DodajProdajnuJedinicu(ProdajnaJedinicaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var odgovorni = s.Load<Farmaceut>(dto.OdgovorniFarmaceutMbr);

                var pj = new ProdajnaJedinica
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
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju prodajne jedinice.", ex);
            }
        }

        public static void DodajApotekuSaLab(ApotekaSaLab dto)
        {
            try
            {
                using var s = DataLayer.GetSession();


                var pj = new ApotekaSaLab
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,
                    OdgovorniFarmaceut = dto.OdgovorniFarmaceut,
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju apoteke sa laboratorijom.", ex);
            }
        }

        public static void DodajSpecApoteku(SpecijalizovanaApoteka dto)
        {
            try
            {
                using var s = DataLayer.GetSession();


                var pj = new SpecijalizovanaApoteka
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,
                    SpecijalnostTipa = dto.SpecijalnostTipa,
                    OdgovorniFarmaceut = dto.OdgovorniFarmaceut,
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju specijalizovane apoteke.", ex);
            }
        }

        public static void DodajStandardnuApoteku(StandardnaApoteka dto)
        {
            try
            {
                using var s = DataLayer.GetSession();


                var pj = new StandardnaApoteka
                {
                    Naziv = dto.Naziv,
                    Ulica = dto.Ulica,
                    Broj = dto.Broj,
                    PostanskiBroj = dto.PostanskiBroj,
                    Mesto = dto.Mesto,
                    Napomena = dto.Napomena,
                    OdgovorniFarmaceut = dto.OdgovorniFarmaceut,
                };

                s.Save(pj);
                s.Flush();
                dto.Id = pj.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju standardne apoteke.", ex);
            }
        }

        public static ProdajnaJedinicaBasic VratiProdajnuJedinicu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Get<ProdajnaJedinica>(id);
                if (pj == null) return null;

                return new ProdajnaJedinicaBasic
                {
                    Id = pj.Id,
                    Naziv = pj.Naziv,
                    Ulica = pj.Ulica,
                    Broj = pj.Broj,
                    PostanskiBroj = pj.PostanskiBroj,
                    Mesto = pj.Mesto,
                    OdgovorniFarmaceutMbr = pj.OdgovorniFarmaceut?.MBr ?? 0
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju prodajne jedinice.", ex);
            }
        }

        public static ProdajnaJedinica? VratiProdajnuJedinicuTip(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();

                // 1) Apoteka sa laboratorijom
                var lab = s.Get<ApotekaSaLab>(id); // <-- ako ti se entitet zove drugačije, promeni ovde
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
                var spec = s.Get<SpecijalizovanaApoteka>(id);
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

                var standardna = s.Get<StandardnaApoteka>(id);
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
                        OdgovorniFarmaceut = standardna.OdgovorniFarmaceut,
                        Napomena = standardna.Napomena
                    };

                }


            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri učitavanju prodajne jedinice.", ex);
            }

            return null;
        }

        public static IList<ProdajnaJedinicaBasic> VratiSveProdajneJedinice()
        {
            var list = new List<ProdajnaJedinicaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                foreach (var pj in s.Query<ProdajnaJedinica>())
                {
                    list.Add(new ProdajnaJedinicaBasic
                    {
                        Id = pj.Id,
                        Naziv = pj.Naziv,
                        Ulica = pj.Ulica,
                        Broj = pj.Broj,
                        PostanskiBroj = pj.PostanskiBroj,
                        Mesto = pj.Mesto,
                        OdgovorniFarmaceutMbr = pj.OdgovorniFarmaceut?.MBr ?? 0
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izvlacenju podataka o prodajnoj jedinici.", ex);
            }

            return list;
        }

        public static void IzmeniProdajnuJedinicu(ProdajnaJedinicaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<ProdajnaJedinica>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = s.Load<Farmaceut>(dto.OdgovorniFarmaceutMbr);

                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izmeni podataka o prodajnoj jedinici.", ex);
            }
        }

        public static void IzmeniSpecApoetku(SpecijalizovanaApoteka dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<SpecijalizovanaApoteka>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = dto.OdgovorniFarmaceut;
                pj.SpecijalnostTipa = dto.SpecijalnostTipa;


                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izmeni podataka o specijalizovanoj apoteci.", ex);
            }
        }

        public static void IzmeniSApoetku(StandardnaApoteka dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<StandardnaApoteka>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = dto.OdgovorniFarmaceut;



                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izmeni podataka o standardnoj apoteci.", ex);
            }
        }

        public static void IzmeniApoetkuSaLab(ApotekaSaLab dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Load<ApotekaSaLab>(dto.Id);
                pj.Naziv = dto.Naziv;
                pj.Ulica = dto.Ulica;
                pj.Broj = dto.Broj;
                pj.PostanskiBroj = dto.PostanskiBroj;
                pj.Mesto = dto.Mesto;
                pj.OdgovorniFarmaceut = dto.OdgovorniFarmaceut;



                s.Update(pj);
                s.Flush();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri izmeni podataka o apoteci sa laboratorijom.", ex);
            }
        }

        public static void ObrisiProdajnuJedinicu(long id)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var pj = s.Get<ProdajnaJedinica>(id);
                if (pj != null)
                {
                    s.Delete(pj);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri brisanju prodajne jedinice iz baze.", ex);
            }
        }

        // ========== MENADŽER – APOTEKA ==========

        public static void DodeliMenadzeraApoteci(MenadzerApotekaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var m = s.Load<FarmacyLibrary.Entiteti.Menadzer>(dto.MBrMenadzera);
                var pj = s.Load<ProdajnaJedinica>(dto.ProdajnaJedinicaId);

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
                throw new InvalidOperationException("Greška pri dodeli menadžera apoteci.", ex);
            }
        }

        public static IList<MenadzerApotekaBasic> VratiApotekeMenadzera(long mbrMenadzera)
        {
            var list = new List<MenadzerApotekaBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var veze = s.Query<MenadzerApoteka>()
                    .Where(x => x.Menadzer.MBr == mbrMenadzera).ToList();

                list.AddRange(veze.Select(x => new MenadzerApotekaBasic
                {
                    MBrMenadzera = x.Menadzer.MBr,
                    ProdajnaJedinicaId = x.ProdajnaJedinica.Id,
                    Od = x.Od,
                    Do = x.Do
                }));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju apoteka menadžera.", ex);
            }

            return list;
        }

        public static void UkloniMenadzeraSaApoteke(long idA, long idM)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var ent = s.Query<MenadzerApoteka>()
                    .FirstOrDefault(x => x.Menadzer.MBr == idM
                                         && x.ProdajnaJedinica.Id == idA);

                if (ent != null)
                {
                    s.Delete(ent);
                    s.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri uklanjanju menadžera sa apoteke.", ex);
            }
        }

        // ========== PROIZVOĐAČ / GRUPE / LEK / OBLIK / PAKOVANJE ==========

        public static long DodajProizvodjaca(ProizvodjacBasic dto)
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
                dto.Id = p.Id;
                return p.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju proizvođača.", ex);
            }
        }

        public static long DodajPrimarnuGrupu(PrimarnaGrupaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var g = new PrimarnaGrupa { Naziv = dto.Naziv };
                s.Save(g);
                s.Flush();
                dto.Id = g.Id;
                return g.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju primarne grupe.", ex);
            }
        }

        public static long DodajSekundarnuKategoriju(SekundarnaKategorijaBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var k = new SekundarnaKategorija { Naziv = dto.Naziv };
                s.Save(k);
                s.Flush();
                dto.Id = k.Id;
                return k.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju sekundarne kategorije.", ex);
            }
        }

        public static long DodajLek(LekBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var lek = new Lek
                {
                    HemijskiNaziv = dto.HemijskiNaziv,
                    KomercijalniNaziv = dto.KomercijalniNaziv,
                    Dejstvo = dto.Dejstvo,
                    Proizvodjac = s.Load<Proizvodjac>(dto.ProizvodjacId),
                    PrimarnaGrupa = s.Load<PrimarnaGrupa>(dto.PrimarnaGrupaId)
                };
                s.Save(lek);

                // M:N sekundarne kategorije
                foreach (var kid in dto.SekundarneKategorijeIds.Distinct())
                {
                    var kat = s.Load<SekundarnaKategorija>(kid);
                    var ls = new LekSekundarna
                    {
                        Lek = lek,
                        Kategorija = kat,
                    };
                    s.Save(ls);
                }

                s.Flush();
                dto.Id = lek.Id;
                return lek.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju leka.", ex);
            }
        }
        
        public static long DodajOblik(OblikBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var o = new Oblik { Naziv = dto.Naziv };
                s.Save(o);
                s.Flush();
                dto.Id = o.Id;
                return o.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju oblika.", ex);
            }
        }

        public static long DodajPakovanje(PakovanjeBasic dto)
        {
            try
            {
                using var s = DataLayer.GetSession();
                var p = new Pakovanje
                {
                    Lek = s.Load<Lek>(dto.LekId),
                    Oblik = s.Load<Oblik>(dto.OblikId),
                    VelicinaPakovanja = dto.VelicinaPakovanja,
                    KolicinaAktivne = dto.KolicinaAktivne,
                    JedinicaMere = dto.JedinicaMere,
                    Ambalaza = dto.Ambalaza,
                    NacinCuvanja = dto.NacinCuvanja,
                    PreporuceniRokDana = dto.PreporuceniRokDana
                };
                s.Save(p);
                s.Flush();
                dto.Id = p.Id;
                return p.Id;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dodavanju pakovanja.", ex);
            }
        }

        public static IList<LekBasic> VratiSveLekove()
        {
            var list = new List<LekBasic>();
            try
            {
                using var s = DataLayer.GetSession();
                var lekovi = s.Query<Lek>().ToList();
                foreach (var l in lekovi)
                {
                    var secIds = s.Query<LekSekundarna>()
                                  .Where(x => x.Lek.Id == l.Id)
                                  .Select(x => x.Kategorija.Id)
                                  .ToList();

                    list.Add(new LekBasic
                    {
                        Id = l.Id,
                        HemijskiNaziv = l.HemijskiNaziv,
                        KomercijalniNaziv = l.KomercijalniNaziv,
                        Dejstvo = l.Dejstvo,
                        ProizvodjacId = l.Proizvodjac.Id,
                        PrimarnaGrupaId = l.PrimarnaGrupa.Id,
                        SekundarneKategorijeIds = secIds
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju svih lekova.", ex);
            }
            return list;
        }

        // ========== ISPORUKA & ZALIHE ==========
        
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
                    Magacioner = dto.MagacionerMbr.HasValue ? s.Load<Zaposleni>(dto.MagacionerMbr.Value) : null
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
                throw new InvalidOperationException("Greška pri kreiranju isporuke.", ex);
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
                        OdgovorniMagacionerMbr = z.OdgovorniMagacioner?.MBr
                    });
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Greška pri dohvatanju zaliha apoteke.", ex);
            }
            return list;
        }

    }
}
