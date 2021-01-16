using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÖdevBahisliZarOyunu
{
    class Oyun
    {
        public Oyuncu birinciOyuncu { get; set; }
        public Oyuncu ikinciOyuncu { get; set; }

        public void birinciOyuncuZarAt()
        {
            birinciOyuncu.Oyna();
        }
        public void ikinciOyuncuZarAt()
        {
            ikinciOyuncu.Oyna();
        }
        public Oyuncu Karsilastir()
        {
            if (birinciOyuncu.OyuncununZari.Deger > ikinciOyuncu.OyuncununZari.Deger)
            {


                return birinciOyuncu;
            }
            else if (birinciOyuncu.OyuncununZari.Deger < ikinciOyuncu.OyuncununZari.Deger)
            {

                return ikinciOyuncu;
            }
            else
            {
                return null;
            }

        }
    }
}
