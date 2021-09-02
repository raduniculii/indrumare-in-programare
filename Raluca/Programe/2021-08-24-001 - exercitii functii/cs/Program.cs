using System;

//1. Faceti o functie care sa aiba 2 parametri si sa returneze rezultatul adunarii lor. Puteti repeta pentru alte operatii.
//2. Faceti o functie cu trei parametri si care sa returneze pe cel mai mare dintre ei. De ex: maximulMeu(2, 5, 3) va returna 5, pentru ca acesta e cel mai mare numar dintre cele 3; maximulMeu(3, 3, 1) va returna 3 (oricare, doar 3)
//3. Faceti o functie cu un parametru, care sa returneze patratul argumentului (numarul "trimis" catrea ea la apel) Hint: patratul poate fi obtinut inmultind numarul cu el insusi.
//4. Faceti o functie cu un parametru care sa afiseze pe consola mesajul: "Simon says: " urmat de mesajul pe care l-a primit ca argument la apel.

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Suma numerelor este " + adunareNumere(5.5,1.5));
            Console.WriteLine($"Numarul Maxim este " + numarMaxim(5,23,23));
            Console.WriteLine($"Patratul numarului este " + patratulNumarului(1.25));
            ziceSimon("Imi place culoarea albastru");
           
        }
    
    //1. Faceti o functie care sa aiba 2 parametri si sa returneze rezultatul adunarii lor. Puteti repeta pentru alte operatii.
        static double adunareNumere(double Nr1, double Nr2)
        {
            var Suma = Nr1 + Nr2;

            return Suma;
        }
        
        //2. Faceti o functie cu trei parametri si care sa returneze pe cel mai mare dintre ei. 
        //De ex: maximulMeu(2, 5, 3) va returna 5, pentru ca acesta e cel mai mare numar dintre cele 3; maximulMeu(3, 3, 1) va returna 3 (oricare, doar 3)
        static int numarMaxim(int NrA, int NrB, int NrC)
        {
            int Maxim = 0;
            
          if ((NrA >= NrB) && (NrA >= NrC))
                    {Maxim = NrA;}
            
            else if ((NrB >= NrA) && (NrB >= NrC))
                    {Maxim = NrB;} 
            else 
                    {Maxim = NrC;}
            
         return Maxim;
        }

//3. Faceti o functie cu un parametru, care sa returneze patratul argumentului (numarul "trimis" catrea ea la apel) Hint: patratul poate fi obtinut inmultind numarul cu el insusi.
        static double patratulNumarului(double Nr1)
        {
            double Patrat = Nr1 * Nr1;

            return Patrat;
        }

 //4. Faceti o functie cu un parametru care sa afiseze pe consola mesajul: "Simon says: " urmat de mesajul pe care l-a primit ca argument la apel.   
        static void ziceSimon(string Propozitie)
        { 
            Console.WriteLine($"Simon says " + Propozitie);
        }

            
    }

}
