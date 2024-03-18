// See https://aka.ms/new-console-template for more information
using ClassLibrary.Data;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

static class Program {
    static void ki(IEnumerable<object> adatok) {
        Console.WriteLine();
        foreach (var item in adatok)
            Console.WriteLine(item.ToString());
    }

    static int ESzam(string szoveg) {
        //Console.WriteLine(szoveg);
        //int sz = 0;
        //foreach (var item in szoveg)
        //    if (item == 'e') sz++;
        //return sz;

        return szoveg.Count(x=>x=='E');
    }

   static void Main(string[] args) {
        Console.WriteLine("Hello, World!");

        Context db = new Context();

        if (!db.Alkalmazott.Any()) {
            var sorok = File.ReadAllLines(@"c:\adat\alkalmazott.csv").Skip(1);
            foreach (var line in sorok)
                db.Alkalmazott.Add(new Alkalmazott(line));
            db.SaveChanges();
        }

        //foreach (var item in db.Alkalmazott)
        //    Console.WriteLine(item);

        ki(db.Alkalmazott);
        ki(db.Alkalmazott.Select(x => x.Nev));
        ki(db.Alkalmazott.Select(x => new { x.Nev, x.Fonok, x.OsztId })); 
        
        ki(db.Alkalmazott.Select(x => new { csicska=x.Nev, evesFizetes=x.Fizetes*12+x.Jutalom }).OrderByDescending(x=>x.csicska));

        ki(db.Alkalmazott.Select(x => new { x.Nev, x.Beosztas, x.Belepes }).OrderByDescending(x => x.Belepes));


        ki(db.Alkalmazott.Select(x => new { csicska = x.Nev, evesFizetes = x.Fizetes * 12 + x.Jutalom }).OrderBy(x => x.evesFizetes));

        ki(db.Alkalmazott.Where(x => x.Nev == "SKÓT"));
        ki(db.Alkalmazott.Where(x => x.Fizetes<1200));

        //Listázza ki azon alkalmazottak adatait, akik 1982 - 06 - 04 után léptek be a céghez.

        ki(db.Alkalmazott.Where(x => x.Belepes > DateTime.Parse("1982-06-04")));

        ki(db.Alkalmazott.Where(x => x.Fizetes > 1200 && x.Fizetes<2000));

        //Listázza ki azon alkalmazottak adatait, akiknek a főnöke 7902 vagy 7566 vagy 7788 -as kódú.

        int[] fonokoksz = { 7902, 7566, 7788 };
        List<int> fonokok = fonokoksz.ToList();

        ki(db.Alkalmazott.Where(x => fonokok.Contains(x.Fonok)));
        
        ki(db.Alkalmazott.Where(x => x.Nev.Substring(0,1)=="S" && x.Nev.Substring(0, 2) !="SZ"));

        //18) Listázza ki azon alkalmazottak adatait, akinek a neve 4 karakter hosszú!

        ki(db.Alkalmazott.Where(x => x.Nev.Length==4));
        ki(db.Alkalmazott.Select(x=>x.Beosztas).Distinct());
        ki(db.Alkalmazott.Select(x=>x.Nev.PadLeft(15,'*')).Distinct()); 
        ki(db.Alkalmazott.Select(x=>x.Nev.PadRight(15,'*')).Distinct());


        var lh = db.Alkalmazott.Select(g => g.Nev).Max(x=>x.Length);
        ki(db.Alkalmazott.Select(x => x.Nev.PadLeft(lh, '_')).Distinct());

        string s = "alma";
        s.Count(x=>x=='a');
        Console.WriteLine(s.Count(x => x == 'a'));

        ki(db.Alkalmazott.Select(x => new { x.Nev, ebetukSzama= ESzam(x.Nev) }));

        //Listázza ki, az alkalmazottak nevét és, hogy az alkalmazottak nevében hányadik karakter az A betű.

        ki(db.Alkalmazott.Select(x => new { x.Nev, abetukHelye= x.Nev.IndexOf('A')==-1?"nincs": x.Nev.IndexOf('A').ToString() }));


    }
}
