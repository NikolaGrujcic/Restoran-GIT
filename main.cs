using System;
namespace RestoranRezervacija
{
    class Program
    {
        
        static void IspisMeseci(string[] MeseciUGodini, DateTime TrenutnoVremeIDatum)
            {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i <= 12; i++)
            {
                if (Convert.ToInt32(TrenutnoVremeIDatum.Month) <= i) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i + "-" + MeseciUGodini[i - 1]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        
        }
        static void IspisDana(DateTime TrenutnoVremeIDatum, int UnetiMesec, int UnetaGodina)
        {
            for (int i = 1; i <= System.DateTime.DaysInMonth(UnetaGodina,UnetiMesec); i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                if (TrenutnoVremeIDatum.Month == UnetiMesec && TrenutnoVremeIDatum.Day > i) Console.ForegroundColor = ConsoleColor.DarkRed;
                if (TrenutnoVremeIDatum.Month == UnetiMesec && TrenutnoVremeIDatum.Day == i) Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("{0,-3}", i);
                if (i % 7 == 0) Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void Main(string[] args)
        {
            //deklaracija promenljivih
            int UnetiMesec; //UnetiMesec - mesec u kom korisnik zeli da napravi rezervaciju
            int UnetaGodina;//UnetaGodina - godina u kojoj korisnik zeli da napravi rezervaciju
            DateTime TrenutnoVremeIDatum = DateTime.Now; //Promenljiva koja sadrži trenutno vreme i datum
            DateTime IzabranoVremeIDatum;
            Console.WriteLine("Izaberite broj meseca kada biste zeleli da napravite rezervaciju.");
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
            
            int KorisnikJeSiguran=0;
            do
            {
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
                    UnetaGodina = TrenutnoVremeIDatum.Year+1;
                }
                else UnetaGodina = TrenutnoVremeIDatum.Year;
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
                + MeseciUGodini[UnetiMesec - 1]
                + " "
                + (Convert.ToInt32(TrenutnoVremeIDatum.Year)
                + Convert.ToInt32(UnetiMesec < Convert.ToInt32(TrenutnoVremeIDatum.Month) ? 1 : 0))
                + ". godine?"); //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto
                Console.WriteLine("1-Da\n2-Izabrali ste pogrešan mesec\n3-Ne želite da napravite rezervaciju");
                while (!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 3. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
                Console.Clear();
            } while (!Convert.ToBoolean(KorisnikJeSiguran - 2));
            //Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni mesec
            Console.WriteLine("Izaberite broj dana u mesecu "
                + MeseciUGodini[UnetiMesec-1]
                + " kada biste zeleli da napravite rezervaciju. ");
            IspisDana(TrenutnoVremeIDatum,UnetiMesec, UnetaGodina);
        }
    }
}
