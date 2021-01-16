using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ÖdevBahisliZarOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Oyun bahisliZarOyunu = new Oyun();

        private void birincioyuncuadbutonu_Click(object sender, EventArgs e)
        {
            string oyuncuAdi = birincioyuncuadtextbox.Text;
            bahisliZarOyunu.birinciOyuncu = new Oyuncu(oyuncuAdi);
            bahisliZarOyunu.birinciOyuncu.OyuncununZari = new Zar();
            birincioyuncuadlabel.Text = bahisliZarOyunu.birinciOyuncu.Ad;
            MessageBox.Show("başlangıç bakiyeniz 100 TL dir");
            bahisliZarOyunu.birinciOyuncu.butce = 100;
        }

        private void ikincioyuncuadbuton_Click(object sender, EventArgs e)
        {
            bahisliZarOyunu.ikinciOyuncu = new Oyuncu(ikincioyuncuadtextbox.Text);
            bahisliZarOyunu.ikinciOyuncu.OyuncununZari = new Zar();
            ikincioyuncuadlabel.Text = bahisliZarOyunu.ikinciOyuncu.Ad;
            MessageBox.Show("başlangıç bakiyeniz 100 TL dir");
            bahisliZarOyunu.ikinciOyuncu.butce = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bahisliZarOyunu.birinciOyuncu.bahisMiktari = Convert.ToDouble(birincioyuncubahistextbox.Text);
            if (bahisliZarOyunu.birinciOyuncu.butce >= bahisliZarOyunu.birinciOyuncu.bahisMiktari)
            {
                bahisliZarOyunu.birinciOyuncu.butce -= bahisliZarOyunu.birinciOyuncu.bahisMiktari;
                birincioyuncununbahisi.Text = birincioyuncubahistextbox.Text;
                birincioyuncubakiyelabel.Text = Convert.ToString(bahisliZarOyunu.birinciOyuncu.butce);
            }
            else if (bahisliZarOyunu.birinciOyuncu.butce < bahisliZarOyunu.birinciOyuncu.bahisMiktari)
            {
                MessageBox.Show("Bütçenizi aşan bahis girdiniz.Lütfen tekrar bir değer giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bahisliZarOyunu.ikinciOyuncu.bahisMiktari = Convert.ToDouble(ikincioyuncubahistextbox.Text);
            if (bahisliZarOyunu.ikinciOyuncu.butce >= bahisliZarOyunu.ikinciOyuncu.bahisMiktari)
            {
                bahisliZarOyunu.ikinciOyuncu.butce -= bahisliZarOyunu.ikinciOyuncu.bahisMiktari;
                ikincioyuncununbahisi.Text = ikincioyuncubahistextbox.Text;
                ikincioyuncubakiyelabel.Text = Convert.ToString(bahisliZarOyunu.ikinciOyuncu.butce);
            }
            else if (bahisliZarOyunu.ikinciOyuncu.butce < bahisliZarOyunu.ikinciOyuncu.bahisMiktari)
            {
                MessageBox.Show("Bütçenizi aşan bahis girdiniz.Lütfen tekrar bir değer giriniz.");
            }
        }

        private void birincioyuncuzaratbuton_Click(object sender, EventArgs e)
        {
            bahisliZarOyunu.birinciOyuncuZarAt();
            birincioyuncununzardegeri.Text = bahisliZarOyunu.birinciOyuncu.OyuncununZari.Deger.ToString();
            ikincioyuncuzaratbuton.Enabled = true;
        }

        private void ikincioyuncuzaratbuton_Click(object sender, EventArgs e)
        {
            bahisliZarOyunu.ikinciOyuncuZarAt();
            ikincioyuncununzardegeri.Text = bahisliZarOyunu.ikinciOyuncu.OyuncununZari.Deger.ToString();
            Oyuncu kazanan = bahisliZarOyunu.Karsilastir();

            if (kazanan == bahisliZarOyunu.birinciOyuncu)
            {
                kazananlabel.Text = $"{kazanan.Ad}";
                bahisliZarOyunu.birinciOyuncu.butce = bahisliZarOyunu.birinciOyuncu.butce + bahisliZarOyunu.birinciOyuncu.bahisMiktari + bahisliZarOyunu.ikinciOyuncu.bahisMiktari;
                birincioyuncubakiyelabel.Text = Convert.ToString(bahisliZarOyunu.birinciOyuncu.butce);
                if (bahisliZarOyunu.ikinciOyuncu.butce == 0)
                {
                    MessageBox.Show($"OYUN BİTTİ..KAZANAN:{bahisliZarOyunu.birinciOyuncu.Ad}");
                    foreach (Control item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox textB = (TextBox)item;
                            textB.Clear();
                            birincioyuncubakiyelabel.Text = "100";
                            ikincioyuncubakiyelabel.Text = "100";
                            birincioyuncuadlabel.Text = "1. Oyuncunun Adı";
                            ikincioyuncuadlabel.Text = "2. Oyuncunun Adı";
                            birincioyuncununzardegeri.Text = "1. Oyununun Attığı Zar";
                            ikincioyuncununzardegeri.Text = "2. Oyuncunun Attığı Zar";
                            kazananlabel.Text = "Kazananın İsmi";
                            birincioyuncununbahisi.Text = "1. Oyunucunun Bahisi";
                            ikincioyuncununbahisi.Text = "2. Oyuncunun Bahisi";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Yeni bahisleri giriniz..");
                }
            }
            else if (kazanan == bahisliZarOyunu.ikinciOyuncu)
            {
                kazananlabel.Text = $"{kazanan.Ad}";
                bahisliZarOyunu.ikinciOyuncu.butce = bahisliZarOyunu.ikinciOyuncu.butce + bahisliZarOyunu.ikinciOyuncu.bahisMiktari + bahisliZarOyunu.birinciOyuncu.bahisMiktari;
                ikincioyuncubakiyelabel.Text = Convert.ToString(bahisliZarOyunu.ikinciOyuncu.butce);
                if (bahisliZarOyunu.birinciOyuncu.butce == 0)
                {
                    MessageBox.Show($"OYUN BİTTİ..KAZANAN:{bahisliZarOyunu.ikinciOyuncu.Ad}");
                    foreach (Control item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox textB = (TextBox)item;
                            textB.Clear();
                            birincioyuncubakiyelabel.Text = "100";
                            ikincioyuncubakiyelabel.Text = "100";
                            birincioyuncuadlabel.Text = "1. Oyuncunun Adı";
                            ikincioyuncuadlabel.Text = "2. Oyuncunun Adı";
                            birincioyuncununzardegeri.Text = "1. Oyununun Attığı Zar";
                            ikincioyuncununzardegeri.Text = "2. Oyuncunun Attığı Zar";
                            kazananlabel.Text = "Kazananın İsmi";
                            birincioyuncununbahisi.Text = "1. Oyunucunun Bahisi";
                            ikincioyuncununbahisi.Text = "2. Oyuncunun Bahisi";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Yeni bahisleri giriniz..");
                }
            }
            else
            {
                kazananlabel.Text = "Berabere";
                if (bahisliZarOyunu.birinciOyuncu.bahisMiktari>bahisliZarOyunu.ikinciOyuncu.bahisMiktari)
                {
                    bahisliZarOyunu.birinciOyuncu.butce = bahisliZarOyunu.birinciOyuncu.butce + bahisliZarOyunu.birinciOyuncu.bahisMiktari + bahisliZarOyunu.ikinciOyuncu.bahisMiktari;
                }
                else
                {
                    bahisliZarOyunu.ikinciOyuncu.butce = bahisliZarOyunu.ikinciOyuncu.butce + bahisliZarOyunu.ikinciOyuncu.bahisMiktari + bahisliZarOyunu.birinciOyuncu.bahisMiktari;
                }
                if (bahisliZarOyunu.birinciOyuncu.butce == 0 || bahisliZarOyunu.ikinciOyuncu.butce == 0)
                {
                    MessageBox.Show($"OYUN BİTTİ..KAZANAN:{kazanan.Ad}");
                    foreach (Control item in this.Controls)
                    {
                        if (item is TextBox)
                        {
                            TextBox textB = (TextBox)item;
                            textB.Clear();
                            birincioyuncubakiyelabel.Text = "100";
                            ikincioyuncubakiyelabel.Text = "100";
                            birincioyuncuadlabel.Text = "1. Oyuncunun Adı";
                            ikincioyuncuadlabel.Text = "2. Oyuncunun Adı";
                            birincioyuncununzardegeri.Text = "1. Oyununun Attığı Zar";
                            ikincioyuncununzardegeri.Text = "2. Oyuncunun Attığı Zar";
                            kazananlabel.Text = "Kazananın İsmi";
                            birincioyuncununbahisi.Text = "1. Oyunucunun Bahisi";
                            ikincioyuncununbahisi.Text = "2. Oyuncunun Bahisi";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Yeni bahisleri giriniz..");
                }

            }

        }


    }

}
