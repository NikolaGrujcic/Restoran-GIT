using System;

namespace RestoranMain
{
    class Program
    {
        static void IzbaciRezervacijeKojeSuProsle(ref (DateTime, int)[] NizRezervacija)
        {
            for (int i = 0; i < NizRezervacija.Length; i++)
            {
                if(NizRezervacija[i].Item1<=DateTime.Now)
                {
                    for (int j = i; j < NizRezervacija.Length - 1; i++) NizRezervacija[j] = NizRezervacija[j + 1];
                    Array.Resize(ref NizRezervacija, NizRezervacija.Length - 1);
                }
            }
        }
        //Metodom kojom se izbacuju sve rezervacije iz proslosti
        static void IspisMeseci(string[] MeseciUGodini, DateTime TrenutnoVremeIDatum)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i <= 12; i++)
            {
                if (Convert.ToInt32(TrenutnoVremeIDatum.Month) <= i) Console.ForegroundColor = ConsoleColor.Green;
                if (Convert.ToInt32(TrenutnoVremeIDatum.Month) == i) Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(i + "-" + MeseciUGodini[i - 1]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        //Metoda koja sluzi za ispis meseci u godini
        static void IspisDana(DateTime TrenutnoVremeIDatum, int UnetiMesec, int UnetaGodina)
        {
            for (int i = 1; i <= System.DateTime.DaysInMonth(UnetaGodina, UnetiMesec); i++)
            {
                if (UnetaGodina == TrenutnoVremeIDatum.Year) Console.ForegroundColor = ConsoleColor.Green;
                else Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (TrenutnoVremeIDatum.Month == UnetiMesec && TrenutnoVremeIDatum.Day > i) Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (TrenutnoVremeIDatum.Month == UnetiMesec && TrenutnoVremeIDatum.Day == i) Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0,-3}", i);
                if (i % 7 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
        //Metoda koja sluzi za ispis dana u izabranom mesecu
        static void Rezervacija(ref (DateTime, int)[] NizRezervacija)
        {
            
            //deklaracija promenljivih
            int UnetiMesec; //UnetiMesec - mesec u kom korisnik zeli da napravi rezervaciju
            int UnetaGodina;//UnetaGodina - godina u kojoj korisnik zeli da napravi rezervaciju
            int UnetiDan;//UnetiDan - dan kojeg korisnik zeli da napravi rezervaciju
            int UnetoVreme;//UnetoVreme - deo dana u kom korisnik zeli da napravi rezervaciju
            int UnetiSto;//UnetiSto - sto za kojim korisnik zeli da napravi rezervaciju
            DateTime TrenutnoVremeIDatum = DateTime.Now; //Promenljiva koja sadrži trenutno vreme i datum

            string[] MeseciUGodini = {
                "Januar",
                "Februar",
                "Mart",
                "April",
                "Maj",
                "Jun",
                "Jul",
                "Avgust",
                "Septembar",
                "Oktobar",
                "Novembar",
                "Decembar"
                }; //Lista imena svakog meseca u godini
            int KorisnikJeSiguran = 0; //Promenljiva koja služi za proveru unosa
            
            while (true)
            {
                bool vracanje = false;
             Console.Clear();
                do
            {
                Console.WriteLine("Unesite broj meseca kada biste zeleli da napravite rezervaciju:");
                IspisMeseci(MeseciUGodini, TrenutnoVremeIDatum); //ispisivanje meseci
                while (!int.TryParse(Console.ReadLine(), out UnetiMesec) || UnetiMesec > 12 || UnetiMesec < 1)
                {
                    Console.Clear();
                    IspisMeseci(MeseciUGodini, TrenutnoVremeIDatum);

                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 12. Pokušajte ponovo: ");
                }
                if (TrenutnoVremeIDatum.Month > UnetiMesec)
                {
                    Console.WriteLine("Pravite rezervaciju za sledecu godinu.");
                    UnetaGodina = TrenutnoVremeIDatum.Year + 1;
                }
                else UnetaGodina = TrenutnoVremeIDatum.Year;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + (Convert.ToInt32(TrenutnoVremeIDatum.Year)
                + Convert.ToInt32(UnetiMesec < Convert.ToInt32(TrenutnoVremeIDatum.Month) ? 1 : 0))
                + (UnetiMesec == TrenutnoVremeIDatum.Month ? "/" + Convert.ToInt32(TrenutnoVremeIDatum.Year + 1) : "")
                + ". godine?");
                //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto:
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan mesec\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 4 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) return;
                if (KorisnikJeSiguran == 4) vracanje=true;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
                //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni mesec
                if (vracanje) continue;//vracanje na pocetak rezervisanja
                do
            {
                Console.WriteLine("Unesite broj dana u mesecu "
                    + MeseciUGodini[UnetiMesec - 1]
                    + " "
                    + UnetaGodina
                    + (UnetiMesec == TrenutnoVremeIDatum.Month ? "/" + Convert.ToInt32(TrenutnoVremeIDatum.Year + 1) : "")
                    + ". godine kada želite da napravite rezervaciju: ");
                IspisDana(TrenutnoVremeIDatum, UnetiMesec, UnetaGodina); //ispisivanje dana
                while (!int.TryParse(Console.ReadLine(), out UnetiDan) || UnetiDan > System.DateTime.DaysInMonth(UnetaGodina, UnetiMesec) || UnetiDan < 1)
                {
                    Console.Clear();
                    IspisDana(TrenutnoVremeIDatum, UnetiMesec, UnetaGodina);
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do "
                        + System.DateTime.DaysInMonth(UnetaGodina, UnetiMesec)
                        + ". Pokušajte ponovo: ");
                }
                if (UnetiMesec == TrenutnoVremeIDatum.Month && UnetiDan < TrenutnoVremeIDatum.Day) UnetaGodina = TrenutnoVremeIDatum.Year + 1;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju "
                + UnetiDan
                + ". dana u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + UnetaGodina
                + ". godine?"); //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan dan\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 4 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 4) vracanje = true;// vraca se na unos meseca
                if (KorisnikJeSiguran == 3) return;
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
                //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni dan
                if (vracanje) continue;//vracanje na pocetak rezervisanja
                do
            {
                Console.WriteLine("Unesite broj dela dana kada biste zeleli da napravite rezervaciju:");
                Console.WriteLine("1-Želite da napravite rezervaciju u 14 časova. " +
                        "\n2-Želite da napravite rezervaciju u 18 časova");
                while (!int.TryParse(Console.ReadLine(), out UnetoVreme) || UnetoVreme > 2 || UnetoVreme < 1)
                {
                    Console.Clear();
                    Console.WriteLine("1-Želite da napravite rezervaciju u 14 časova. " +
                        "\n2-Želite da napravite rezervaciju u 18 časova");
                    Console.WriteLine("Pogrešan unos. Trebate uneti 1 ili 2. Pokušajte ponovo: ");
                }
                if (UnetoVreme == 1)
                {
                    UnetoVreme = 14;
                }
                else UnetoVreme = 18;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju "
                + UnetiDan
                + ". dana u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + UnetaGodina
                + ". godine u "
                + UnetoVreme
                + " časova?");
                //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto:
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešno vreme\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 4 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) return;
                if (KorisnikJeSiguran == 4) vracanje = true;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
                //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeno vreme
                if (vracanje) continue;//vracanje na pocetak rezervisanja
                do
            {
                Console.WriteLine("Unesite broj stola koji želite da rezervišete. Ima ih 5:");
                while (!int.TryParse(Console.ReadLine(), out UnetiSto) || UnetiSto > 5 || UnetiSto < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 5. Pokušajte ponovo: ");
                    Console.WriteLine("Unesite broj stola koji želite da rezervišete. Ima ih 5:");
                }
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju "
                + UnetiDan
                + ". dana u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + UnetaGodina
                + ". godine u "
                + UnetoVreme
                + " časova za stolom "
                + UnetiSto
                + "?");
                //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto:
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan sto\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 4 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) return;
                if (KorisnikJeSiguran == 4) vracanje = true;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
                //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni sto
                if (vracanje) continue;//vracanje na pocetak rezervisanja
                DateTime IzabranoVremeIDatum = new DateTime(UnetaGodina, UnetiMesec, UnetiDan, UnetoVreme, 0, 0);
            //Datum i vreme kada korisnik želi da napravi rezervaciju
            if (TrenutnoVremeIDatum > IzabranoVremeIDatum)
            {
                Console.WriteLine("To vreme je već prošlo. Unesite 1 ako želite da izmenite rezervaciju ili 2 ako ne želite da pravite rezervaciju");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti 1 ili 2. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 1) continue;
                else return;
            }
            for (int i = 0; i < NizRezervacija.Length; i++)
            {
                if (NizRezervacija[i] == (IzabranoVremeIDatum, UnetiSto))
                {
                    Console.WriteLine("Ta rezervacija nije dostupna. Unesite 1 ako želite da izmenite rezervaciju ili 2 ako ne želite da pravite rezervaciju");
                    while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                        Console.WriteLine("Pogrešan unos. Trebate uneti 1 ili 2. Pokušajte ponovo: ");
                    if (KorisnikJeSiguran == 1) vracanje = true;
                    else return;
                }
            }
            //Petlja koja proverava da li rezervacija već postoji
            if (vracanje) continue;
            Array.Resize(ref NizRezervacija, NizRezervacija.Length + 1);
            NizRezervacija[NizRezervacija.Length-1] = (IzabranoVremeIDatum, UnetiSto);
                break;
            }
        }
        static void Main(string[] args)
        {
        
            (DateTime, int)[] NizRezervacija = new (DateTime, int)[0];

            int IzborRezervacija;
            while (true)
            {
                Console.WriteLine("Ako želite da pogledate spisak rezervacija unesite 1, ako želite da napravite novu rezervaciju unesite 2: ");
                while (!int.TryParse(Console.ReadLine(), out IzborRezervacija) || IzborRezervacija > 2 || IzborRezervacija < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Pogrešan unos. Trebate uneti 1 ili 2. Pokušajte ponovo: ");
                    Console.WriteLine("Ako želite da pogledate spisak rezervacija unesite 1, ako želite da napravite novu rezervaciju unesite 2: ");
                }
                if (IzborRezervacija == 1)
                {
                    IzbaciRezervacijeKojeSuProsle(ref NizRezervacija);
                    Console.Clear();
                    if (NizRezervacija.Length == 0) Console.WriteLine("Nema rezervacija.");
                    Array.Sort(NizRezervacija);
                    for (int i = 0; i < NizRezervacija.Length; i++)
                        Console.WriteLine((i + 1) 
                            + ". Datum i vreme: " + NizRezervacija[i].Item1
                            + " Sto: " + NizRezervacija[i].Item2);
                }
                else
                {
                    Console.Clear();
                    Rezervacija(ref NizRezervacija);
                }
            }

        }
    }
}
