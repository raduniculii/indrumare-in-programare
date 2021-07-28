using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var min = 0;
            var max = 100;//71
            var incercare = 0;
            var raspunsDacaENumarulCorect = "";
            var raspunsDacaEMaiMare = "";

            Console.WriteLine("Alege-ti, te rog, un numar intre " + min + " si " + max + " si apoi apasa enter.");
            Console.ReadLine();

            while(raspunsDacaENumarulCorect != "da" && min <= max){
                incercare = (max + min) / 2;
                Console.WriteLine("E numarul tau cumva " + incercare + "?");
                raspunsDacaENumarulCorect = Console.ReadLine();
                if(raspunsDacaENumarulCorect != "da"){
                    Console.WriteLine("Numarul " + incercare + " e mai mare decat numarul tau?");
                    raspunsDacaEMaiMare = Console.ReadLine();
                    if(raspunsDacaEMaiMare == "da"){
                        //trebuie sa incerc un numar mai mic
                        max = incercare - 1;
                    }
                    else {
                        //trebuie sa incerc unul mai mare
                        min = incercare + 1;
                    }
                }
            }

            if(raspunsDacaENumarulCorect == "da"){
                Console.WriteLine("Bravo mie! Ti-am ghicit numarul.");
                Console.WriteLine("Presupun ca bravo si tie ca ai zis corect daca e mai mic sau mai mare...");
            }
            else {
                Console.WriteLine("Apoi sigur mi-ai raspuns aiurea undeva.");
            }

            Console.WriteLine("C# a terminat.");
        }
    }
}
