using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace KolokwiumProgramowanieObiektowe2021
{
    ///gdyby to był txt... było by milej
    class Owoc
    {
        public string Kolor { get; set; }
        public int Wielkosc { get; set; }
        public float Waga { get; set; }
    }


    

    class Program
    {
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

        static void Main(string[] args)
        {
            LadujJson();
            Console.ReadLine();
        }
    }
}

