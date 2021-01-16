using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdevBahisliZarOyunu
{
   class Oyuncu
    {

        public string Ad { get; set; }

        public double butce { get; set; }
        public string Yas { get; set; }

        public double bahisMiktari { get; set; }

        public Zar OyuncununZari { get; set; }

        public void Oyna()
        {
            OyuncununZari.At();

        }
        public Oyuncu()
        {

        }
        public Oyuncu(string ad)
        {
            Ad = ad;
        }

    }
}
