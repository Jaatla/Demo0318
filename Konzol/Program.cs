// See https://aka.ms/new-console-template for more information
using ClassLibrary.Data;
using ClassLibrary.Models;

Console.WriteLine("Hello, World!");

Context db = new Context();

if (!db.Alkalmazott.Any()) {
    var sorok = File.ReadAllLines(@"c:\adat\alkalmazott.csv").Skip(1);
    foreach (var line in sorok)
        db.Alkalmazott.Add(new Alkalmazott(line));
    db.SaveChanges();
}

foreach (var item in db.Alkalmazott)
    Console.WriteLine(item);
