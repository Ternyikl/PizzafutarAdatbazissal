using K4os.Compression.LZ4.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzafutarAdatbazissal
{
    internal class Feladatok
    {
        private List<Rendeles> rendelesek;
        public Feladatok()
        {
            Adatbazis adatbazis = new Adatbazis();
            rendelesek = adatbazis.Feltolt();
            Kiir();
            Console.WriteLine();
            F03();
            Console.WriteLine();
            F04();
            Console.WriteLine();
            F05();
            Console.WriteLine();
            F06();
        }

        public void Kiir()
        {
            foreach (var item in rendelesek)
            {
                Console.WriteLine(item);
            }
        }

        public void F03()
        {
            var olcsoPizzak = rendelesek.Select(r => r.Pizza).Where(x => x.Ar < 1500).Distinct().OrderByDescending(p => p.Meret).ThenBy( p => p.Nev).ToList();
            olcsoPizzak.ForEach(p => Console.WriteLine(p));
        }

        public void F04()
        {
            var osszesites = rendelesek.GroupBy(r => new { r.Pizza.Nev, r.Pizza.Meret })
                .Select(g => new{ g.Key.Nev, g.Key.Meret, Osszes = g.Sum(r => r.Db) })
                .OrderByDescending(x => x.Osszes)
                .ToList().First();
            Console.WriteLine($"{osszesites.Nev} ({osszesites.Meret} cm): {osszesites.Osszes} db");
        }

        public void F05()
        {
            var esti = rendelesek.Where( x => x.Ido >= new TimeSpan(18,0,0) && x.Ido <= new TimeSpan(19,0,0)).ToList().Count;

            Console.WriteLine($"Rendelések 18 és 19 óra között: {esti}");
        }

        public void F06()
        {
            var mindHarom = rendelesek.GroupBy(r => new { r.Pizza.Nev }).Select(g => new {g.Key.Nev, Osszes = g.Count(r => r.Pizza.Meret)});
            mindHarom.ForEach(p => Console.WriteLine($""));
        }
    }
}
