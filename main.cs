using System;

class MainClass
{
    static void NapustiProgram()
    {
            Console.WriteLine("Da li ste sigurni da želite da napustite program? Unesite 1 ako želite da napustite program, ako želite da se vratite na početak unesite 2");
            int NapustanjeUnos = 0; //Promenljiva koja služi za proveru unosa
            while (!int.TryParse(Console.ReadLine(), out NapustanjeUnos)
             || NapustanjeUnos > 2 || NapustanjeUnos < 1)
            {
                Console.Clear();
                Console.WriteLine("Da li ste sigurni da želite da napustite program? Unesite 1 ako želite da napustite program, ako želite da se vratite na početak unesite 2");
                Console.WriteLine("Pogrešan unos. Trebate uneti 1 ili 2. Pokušajte ponovo: ");
            }
            if (NapustanjeUnos == 1) Environment.Exit(0);
        
    }
    public static void Main(string[] args)
    {
        NapustiProgram();
    }
}