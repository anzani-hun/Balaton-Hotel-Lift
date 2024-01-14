using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Lift
{
    class Program

    {
        struct lift_adatok
        {
            // Az adatokat szóköz karakterrel választottuk el egymástól //
            public DateTime ido;            // használat időpontja
            public int kartyaSorSzam;       // kártya sorszáma
            public int induloSzint;         // az induló szint sorszáma
            public int celSzint;            // a célszint sorszáma
        }

        static void Main()
        {

            lift_adatok seged;

            List<lift_adatok> BalatonLift = new List<lift_adatok>();


            // fájl összes sorát beolvassa egy string tömbbe --> File.ReadAllLines és az eredményt egy string[] tömbbe helyezi.
            string[] olvaso = File.ReadAllLines("lift.txt");


            for (int i = 0; i < olvaso.Count(); i++)
            {
                //legfeljebb 1000 sor lehet
                if ((olvaso[i].Length > 0) && (i <= 1000))

                {
                    string[] sor = olvaso[i].Split(' ');

                    seged.ido = Convert.ToDateTime(sor[0]);
                    seged.kartyaSorSzam = Convert.ToInt32(sor[1]);
                    seged.induloSzint = Convert.ToInt32(sor[2]);
                    seged.celSzint = Convert.ToInt32(sor[3]);

                    BalatonLift.Add(seged);

                }
            }



            // Határozza meg és írja ki a minta szerint, hogy a vizsgált időszakban hány alkalommal használták a liftet! //
            Console.WriteLine("\n3.Feladat: ");

            int osszesen = 0;
            int mentek;

            for (int i = 0; i < BalatonLift.Count; i++)

            {
                mentek = (BalatonLift[i].induloSzint + BalatonLift[i].celSzint);
                if (mentek > 0) osszesen++;
            }
            Console.WriteLine($"A liftet összesen {osszesen}x hasznáták");


            // Írja ki a képernyőre a minta szerint, hogy a vizsgált időszak mettől meddig tartott! //
            Console.WriteLine("\n4.Feladat: ");

            // a kezdeti és végdátum meghatározása
            DateTime maximum = BalatonLift[osszesen - 1].ido;
            DateTime minimum = BalatonLift[0].ido;
            Console.WriteLine($"A vizsgált időszak {minimum}-tól   {maximum}-ig tartott!");



            // Határozza meg és írja ki a képernyőre a minta szerint, hogy melyik volt a legnagyobb sorszámú célszint az időszakban! //
            Console.WriteLine("\n5.Feladat: ");
            int legnagyobbSzint = 0;
            int max_ertek = 0;

            for (int i = 0; i < BalatonLift.Count; i++)     //MAX emelet kiszámítása
            {
                if (BalatonLift[i].celSzint > BalatonLift[legnagyobbSzint].celSzint) legnagyobbSzint = i;
            }


            for (int k = 0; k < BalatonLift.Count; k++)     //MAX kártyaszám használat kiszámítása

            { if (BalatonLift[k].kartyaSorSzam > BalatonLift[max_ertek].kartyaSorSzam) max_ertek = k; }



            Console.WriteLine($"Célszint max: {BalatonLift[legnagyobbSzint].celSzint}");




            // Kérje be a felhasználótól egy kártya számát és egy célszint számát szöveges típusú  adatként! //
            Console.WriteLine("\n6.Feladat: ");         // utazas kártyával megadott emeletre

            int kartya;
            int emelet;
            
            do
            {
                Console.Write("Kérek egy kártyaszámot: ");
                kartya = Convert.ToInt32(Console.ReadLine());
            }
            while (kartya > max_ertek || kartya <= 0);

            do
            {
                Console.Write("Kérek emeletszámot: ");
                emelet = Convert.ToInt32(Console.ReadLine());
            }

            //max 5 emelet van
            while (emelet <= 0 || emelet > 5);


            int utaz = 0;

            for (int j = 0; j < BalatonLift.Count; j++)
            {
                if ((BalatonLift[j].kartyaSorSzam == kartya) && (BalatonLift[j].celSzint == emelet)) 
                    utaz++;
            }

            if (utaz > 0)
                Console.WriteLine($"A megadott kártyával [{kartya}] volt utazás a megadott [{emelet}] emeletre");
            
            else if (utaz == 0) 
                Console.WriteLine("Nem utaztak!");
            





            /* Döntse el, hogy az előző feladatban megadott (beállított) ká1tyával utaztak-e a vizsgált
                időszakban a megadott (beállított) célszintre! A keresését ne folytassa, ha a választ
                meg tudja adni! A képernyőre írást a minta szerint végezze! */
            Console.WriteLine("\n7.Feladat: ");







            /* Készítsen statisztikát a naponkénti lifthasználat számáról! A megoldást úgy készítse el,
             *        hogy az inputállományba később további napok adatai is bekerülhessenek! */
            Console.WriteLine("\n8.Feladat: ");





            Console.ReadKey();
        }

    }
}
