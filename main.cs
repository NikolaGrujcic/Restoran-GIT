using System;
class MainClass {
  static void IspisMeseci(string[] MeseciUGodini, DateTime TrenutnoVremeIDatum)
            {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 1; i <= 12; i++)
            {
                if (Convert.ToInt32(TrenutnoVremeIDatum.Month) <= i) Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(i + "-" + MeseciUGodini[i - 1]);
            }
        }
        static void Rezervacija(string[] args)
        {
            //deklaracija promenljivih
            int UnetiMesec; //UnetiMesec - mesec u kom korisnik zeli da napravi rezervaciju
            DateTime TrenutnoVremeIDatum = DateTime.Now; //Promenljiva koja sadrži trenutno vreme i datum
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
            IspisMeseci(MeseciUGodini, TrenutnoVremeIDatum); //ispisivanje meseci
            int KorisnikJeSiguran=0;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out UnetiMesec) || UnetiMesec > 12 || UnetiMesec < 1)
                {
                    Console.Clear();
                    IspisMeseci(MeseciUGodini, TrenutnoVremeIDatum);
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 12. Pokušajte ponovo: ");
                }
                if (TrenutnoVremeIDatum.Month > UnetiMesec) Console.WriteLine("Pravite rezervaciju za sledecu godinu.");
                Console.WriteLine("Da li ste sigurni da želite da napravite rezervaciju u mesecu "
                + MeseciUGodini[UnetiMesec-1]
                +" "
                + (Convert.ToInt32(TrenutnoVremeIDatum.Year)
                +Convert.ToInt32(UnetiMesec<Convert.ToInt32(TrenutnoVremeIDatum.Month) ? 1: 0))
                + ". godine?"); //if koji proverava da li korisnik stvarno zeli unetog meseca da rezervise sto
                Console.WriteLine("1-Da\n2-Ne\n3-Ne želite da napravite rezervaciju");
                while(!int.TryParse(Console.ReadLine(), out KorisnikJeSiguran) || KorisnikJeSiguran > 3 || KorisnikJeSiguran < 1)
                    Console.WriteLine("Pogrešan unos. Trebate uneti broj od 1 do 3. Pokušajte ponovo: ");
                if (KorisnikJeSiguran == 3) ;//treba dodati goto koji ide nazad u glavni program
            } while (!Convert.ToBoolean(KorisnikJeSiguran-2));//Petlja koja se ponavlja sve dok korisnik ne potvrdi da je uneo zeljeni mesec
            
            Console.WriteLine("Izaberite broj dana u mesecu "
                + MeseciUGodini[UnetiMesec+1]
                + " kada biste zeleli da napravite rezervaciju. ");
            for (int i = 1; i <= Convert.ToInt32(DateTime.DaysInMonth(TrenutnoVremeIDatum.Year, TrenutnoVremeIDatum.Month)); i++)
            {
                Console.Write("{0,-3}", i);
                if (i % 7 == 0) Console.WriteLine();
            }
        }
  public static void Main (string[] args) {
    Console.WriteLine ("Hello World");
  }
}