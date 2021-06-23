using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace KolokwiumProgramowanieObiektowe2021
{
    class Owoc
    {
        public string Kolor { get; set; }
        public int Wielkosc { get; set; }
        public float Waga { get; set; }
    }


    class Program
    {
        public bool czyZerwac = true;
        public static void LadujJson()
        {
            using (StreamReader r = new StreamReader("drzewo.json"))
            {
                int iloscCiezkichOwocow = 0;
                string json = r.ReadToEnd();
                List<Owoc> items = JsonConvert.DeserializeObject<List<Owoc>>(json);

                for(int i =0; i < items.Count(); i++ )
                {
                   if (items[i].Waga > 0.5f) 
                   {
                        iloscCiezkichOwocow++;
                   }  
                }
                Console.WriteLine(" Mamy " + iloscCiezkichOwocow + " cieżkich owoców");
            }
        }

        public static bool ZerwijOwoc()
        {
            Random rnd = new Random() ;
            int losowaLiczba;
            using (StreamReader r = new StreamReader("drzewo.json"))
            {
                string json = r.ReadToEnd();
                List<Owoc> items = JsonConvert.DeserializeObject<List<Owoc>>(json);

                losowaLiczba = rnd.Next(0, items.Count());
                if (items[losowaLiczba].Wielkosc == 420)
                {
                    Console.WriteLine("Zerwałeś granat - uciekaj !");
                    return false;
                }
                if (items[losowaLiczba].Wielkosc < 100)
                {
                    Console.WriteLine("Doszło do zatrucia ! :( ");
                    return false;
                }
                if (items[losowaLiczba].Wielkosc >= 100)
                {
                    Console.WriteLine("Dobry dojrzały owoc - smacznego !");
                    return true;
                }
                return false;
            }

        }


        static void Main(string[] args)
        {
            LadujJson();
            while (true)
            {
                string komenda = Console.ReadLine();
                if (komenda.Equals("zerwij_owoc"))
                {
                    bool dobry = ZerwijOwoc();
                    if (!dobry) { break; }
                }
                else { break; }
            }
            Console.WriteLine("Koniec programu");
            Console.ReadLine();
        }
    }
}

