using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzafutarAdatbazissal
{
    internal class Cim
    {
        private int id;
        private string nev;
        private string utca;
        private string hazszam;

        public Cim(int id, string nev, string utca, string hazszam)
        {
            this.id = id;
            this.nev = nev;
            this.utca = utca;
            this.hazszam = hazszam;
        }

        public int Id { get => id; }
        public string Nev { get => nev; set => nev = value; }
        public string Utca { get => utca; set => utca = value; }
        public string Hazszam { get => hazszam; set => hazszam = value; }

        override public string ToString()
        {
            return $"{nev}, {utca} {hazszam}";
        }
    }
}
