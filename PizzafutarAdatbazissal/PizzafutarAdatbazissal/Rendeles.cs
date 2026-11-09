using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzafutarAdatbazissal
{
    internal class Rendeles
    {
        private int id;
        private Pizza pizza;
        private int db;
        private Cim cim;
        private TimeSpan ido;

        public Rendeles(int id, Pizza pizza, int db, Cim cim, TimeSpan ido)
        {
            this.id = id;
            this.pizza = pizza;
            this.db = db;
            this.cim = cim;
            this.ido = ido;
        }

        public int Id { get => id; }
        public int Db { get => db; set => db = value; }
        public TimeSpan Ido { get => ido; set => ido = value; }
        internal Pizza Pizza { get => pizza; set => pizza = value; }
        internal Cim Cim { get => cim; set => cim = value; }


        override public string ToString()
        {
            return $"{pizza.Nev} ({pizza.Meret} cm) - {pizza.Ar} Ft x {db} db, {cim.Nev}, {cim.Utca} {cim.Hazszam}, {ido}";
        }
    }
}
