using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzafutarAdatbazissal
{
    internal class Pizza
    {
        private int id;
        private string nev;
        private int meret;
        private int ar;

        public Pizza(int id, string nev, int meret, int ar)
        {
            this.id = id;
            this.nev = nev;
            this.meret = meret;
            this.ar = ar;
        }

        public int Id { get => id; }
        public string Nev { get => nev; set => nev = value; }
        public int Meret { get => meret; set => meret = value; }
        public int Ar { get => ar; set => ar = value; }

        override public string ToString()
        {
            return $"{nev} ({meret} cm) - {ar} Ft";
        }
    }
}
