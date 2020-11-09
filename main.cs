using System;

namespace RestoranMain
{
    class Program
    {
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
        static DateTime Rezervacija(out int UnetiSto)
        {

            //deklaracija promenljivih
            int UnetiMesec; //UnetiMesec - mesec u kom korisnik zeli da napravi rezervaciju
            int UnetaGodina;//UnetaGodina - godina u kojoj korisnik zeli da napravi rezervaciju
            int UnetiDan;//UnetiDan - dan kojeg korisnik zeli da napravi rezervaciju
            int UnetoVreme;//UnetoVreme - deo dana u kom korisnik zeli da napravi rezervaciju
            //UnetiSto - sto za kojim korisnik zeli da napravi rezervaciju
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
            int KorisnikJeSiguran = 0;
        PocetakRezervacije:
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
                if (TrenutnoVremeIDatum.Month > UnetiMesec)//
                {
                    Console.WriteLine("Pravite rezervaciju za sledecu godinu.");
                    UnetaGodina = TrenutnoVremeIDatum.Year + 1;
                }
                else UnetaGodina = TrenutnoVremeIDatum.Year;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + (Convert.ToInt32(TrenutnoVremeIDatum.Year) //ako je jednako treba dodati /TrenutnoVremeIDatum.Year+1
                + Convert.ToInt32(UnetiMesec < Convert.ToInt32(TrenutnoVremeIDatum.Month) ? 1 : 0))
                + (UnetiMesec == TrenutnoVremeIDatum.Month ? "/" + Convert.ToInt32(TrenutnoVremeIDatum.Year + 1) : "")
                + ". godine?");
                //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto:
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan mesec\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
                if (KorisnikJeSiguran == 4) goto PocetakRezervacije;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
            //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni mesec
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
                if (UnetiMesec == TrenutnoVremeIDatum.Month && UnetiDan < TrenutnoVremeIDatum.Day) UnetaGodina++;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju "
                + UnetiDan
                + ". dana u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + (Convert.ToInt32(TrenutnoVremeIDatum.Year)
                + Convert.ToInt32(UnetiMesec < Convert.ToInt32(TrenutnoVremeIDatum.Month) ? 1 : 0))
                + ". godine?"); //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan dan\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 4) goto PocetakRezervacije;// vraca se na unos meseca
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
            //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni dan
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
                if (UnetoVreme == 1) UnetoVreme = 14;
                else UnetoVreme = 18;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + UnetaGodina
                + ". godine u "
                + UnetoVreme
                + " časova?");
                //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto:
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešno vreme\n3-Ne želite da napravite rezervaciju\n4-Želite da napravite rezervaciju ispočetka");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
                if (KorisnikJeSiguran == 4) goto PocetakRezervacije;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
            //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeno vreme
            do
            {
                Console.WriteLine("Unesite broj stola koji želite da rezervišete. Ima ih 5:");
                while (!int.TryParse(Console.ReadLine(), out UnetiSto) || UnetiSto > 5 || UnetiSto < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 5. Pokušajte ponovo: ");
                    Console.WriteLine("Unesite broj stola koji želite da rezervišete. Ima ih 5:");
                }
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
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
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 4. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
                if (KorisnikJeSiguran == 4) goto PocetakRezervacije;// vraca se na unos meseca
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
            //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni sto
            DateTime IzabranoVremeIDatum=new DateTime(UnetaGodina,UnetiMesec,UnetiDan,UnetoVreme, 0, 0);
            //Datum i vreme kada korisnik želi da napravi rezervaciju
            return IzabranoVremeIDatum;
        }
        static void Main(string[] args)
        {
            int a=0;
            DateTime datum = Rezervacija(out a);
            Console.WriteLine(datum);

        }
    }
}
