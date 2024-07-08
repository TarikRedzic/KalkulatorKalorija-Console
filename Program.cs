using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

class Kalkulator
{
    private Dictionary<string, int> hrana;

    public Kalkulator()
    {
        hrana = new Dictionary<string, int>
        {
            //naglasiti da je ovo na 100g
            {"jabuka", 52},
            {"breskva", 46},
            {"narandza", 54},
            {"banana", 99},
            {"piletina", 144},
            {"riza", 368},
            {"jaje", 167},
            {"mlijeko", 66},
            {"kravlji sir", 72},
            {"hljeb", 252},
            {"krompir", 85},
            {"mrkva", 35},
            {"orah", 654}
        };
    }
    public bool Ponavlja(string pro)
    {
        if(hrana.ContainsKey(pro))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Metni(string pro, int kcal)
    {
        hrana.Add(pro, kcal);
        Console.WriteLine("Proizvod je uspješno dodan!");
    }
    
    public void Vadi(string pro)
    {
        hrana.Remove(pro);
        Console.WriteLine("Proizvod je uspješno uklonjen!");
    }

    public int GetKcal(string jelo)
    {
        int kcal = hrana[jelo];
        return kcal;
    }

    public void Ispis()
    {
        foreach (KeyValuePair<string, int> par in hrana)
        {
            //Console.WriteLine("{0} - {1} kcal/100g", par.Key, par.Value);
            string s = par.Key;
            int m = par.Value;
            Console.Write(String.Format("{0,-20} | ", s));
            Console.WriteLine("{0} kcal/100g", m);
        }
    }
}

class Program
{
    static void Main()
    {
        Kalkulator calc = new Kalkulator();

        int izbor;

        do
        {
            izbor = Uvod();
            switch(izbor)
            {
                case 0:
                    Console.WriteLine("Hvala na korištenju naše aplikacije!");
                    break;
                case 1:
                    IspisLista();
                    break;
                case 2:
                    DodajLista(calc);
                   // Console.WriteLine("Proizvod je uspješno dodan!");
                    break;
                case 3:
                    UkloniLista(calc);
                    //Console.WriteLine("Proizvod je uspješno uklonjen!");
                    break;
                case 4:
                    RacunLista(calc);
                    break;
                default:
                    Console.WriteLine("Molimo unesite jednu od ponudjenih opcija!");
                    break;
               
            }

        }
        while (izbor != 0);

        int Uvod()
        {
            Console.WriteLine("\n ---KALKULATOR KALORIJA--- \n");
            Console.Write("Odaberite jednu od ponudjenih opcija: \n");
            Console.Write("1 - Ispis proizvoda i njihovih vrijednosti. \n");
            Console.Write("2 - Unesite novi proizvod na listu. \n");
            Console.Write("3 - Uklonite proizvod sa liste. \n");
            Console.Write("4 - Pokrenite kalkulator. \n");
            Console.Write("0 - Ugasite kalkulator. \n");

            int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }

        int IspisZaRacun()
        {
            Console.WriteLine("Šta zelite uraditi?");
            Console.WriteLine("1 - Započnite računanje unosa kalorija.");
            Console.WriteLine("2 - Nastavite s računanjem unosa kalorija.");
            Console.WriteLine("0 - Završite s računanjem.");

            int n = Convert.ToInt32(Console.ReadLine());
            return n;
        }

        void IspisLista()
        {
            calc.Ispis();
        }

        void DodajLista(Kalkulator calc)
        {
            int kcal = 0;
            string pro;
            Console.WriteLine("Upišite proizvod koji zelite dodati: ");
            pro = Console.ReadLine();
            if (calc.Ponavlja(pro))
            {
                Console.WriteLine("Ovaj proizvod već postoji na listi!");
            }
            else
            {
                kcal = Convert.ToInt32(Console.ReadLine());
                calc.Metni(pro, kcal);
            }

        }

        void UkloniLista(Kalkulator calc)
        {
            string pro;
            Console.WriteLine("Upišite proizvod koji zelite ukloniti: ");
            pro = Console.ReadLine();
            if (!calc.Ponavlja(pro))
            {
                Console.WriteLine("Ovaj proizvod ne postoji na listi!");
            }
            else
            {
                calc.Vadi(pro);
            }
        }

        void RacunLista(Kalkulator calc)
        {
            int n, kcal = 0;
            do
            {
                n = IspisZaRacun();
                switch(n)
                {
                    case 0:
                        Console.WriteLine("Računanje zavrseno. Vas unos kalorija je iznosio {0}.", kcal);
                        break;
                    case 1:
                        kcal = 0;
                        kcal = (int)Unos(kcal);
                        Console.WriteLine("Trenutno stanje: {0} kcal.", kcal);
                        break;
                    case 2:
                        kcal += (int)Unos(kcal);
                        Console.WriteLine("Trenutno stanje: {0} kcal.", kcal);
                        break;
                    default:
                        Console.WriteLine("Molimo unesite jednu od ponudjenih opcija!");
                        break;
                }


            }
            while (n != 0);
        }

        double Unos(int kcal)
        {
            double gram;
            double rez = 0;
            Console.WriteLine("Unesite hranu koju ste pojeli: ");
            string jelo = Console.ReadLine();
            if (!calc.Ponavlja(jelo))
            {
                Console.WriteLine("Ovaj proizvod ne postoji na listi!");
            }
            else
            {
                kcal = calc.GetKcal(jelo);
                Console.WriteLine("Unesite količinu koju ste unijeli: ");
                gram = Convert.ToInt32(Console.ReadLine());
                rez = (gram / 100) * kcal;
            }
            
            return rez;
        }
    }
}
