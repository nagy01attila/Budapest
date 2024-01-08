using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        List<Kozterulet> kozteruletek = BeolvasKozteruletek("bp.csv");

        // 1. feladat 
        Console.WriteLine("1. feladat: Összesen " + kozteruletek.Count + " közterület található.");

        // 2. feladat
        int xiiiKeruletDb = 0;
        foreach (var kozterulet in kozteruletek)
        {
            if (kozterulet.Kerulet == "XIII")
                xiiiKeruletDb++;
        }
        Console.WriteLine("2. feladat: XIII. kerületben " + xiiiKeruletDb + " közterület van.");

        // 3. feladat 
        Console.Write("3. feladat: Kérem, adjon meg egy irányítószámot: ");
        string inputIrsz = Console.ReadLine();
        bool vanIlyenIrsz = false;
        foreach (var kozterulet in kozteruletek)
        {
            if (kozterulet.Irsz == inputIrsz)
            {
                vanIlyenIrsz = true;
                break;
            }
        }
        Console.WriteLine(vanIlyenIrsz ? "Igen, van ilyen irányítószám." : "Nincs ilyen irányítószám.");

        // 4. feladat 
        Console.Write("4. feladat: Kérem, adjon meg egy kezdőszöveget az adott közterület nevéhez: ");
        string inputSzoveg = Console.ReadLine();
        Console.WriteLine("Azon közterületek, melyek neve a megadott szöveggel kezdődik:");
       

       
    }

    static List<Kozterulet> BeolvasKozteruletek(string fajlnev)
    {
        List<Kozterulet> kozteruletek = new List<Kozterulet>();
        try
        {
            string[] sorok = File.ReadAllLines(fajlnev);
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] oszlopok = sorok[i].Split(';');
                Kozterulet kozterulet = new Kozterulet
                {
                    Nev = oszlopok[0],
                    Kerulet = oszlopok[1],
                    Irsz = oszlopok[2]
                };
                kozteruletek.Add(kozterulet);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Hiba: A(z) " + fajlnev + " fájl nem található.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Hiba történt: " + ex.Message);
        }
        return kozteruletek;
    }
}

class Kozterulet
{
    public string Nev { get; set; }
    public string Kerulet { get; set; }
    public string Irsz { get; set; }
}
