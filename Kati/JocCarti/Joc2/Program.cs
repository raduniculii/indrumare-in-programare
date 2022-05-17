using System;
using System.Collections.Generic;
using System.Linq;

namespace Joc2
{
    class Program
    {
        static void Main(string[] args)
        {
            const char CHR_INIMA_ROSIE = (char)3;
            const char CHR_ROMB = (char)4;
            const char CHR_TREFLA = (char)5;
            const char CHR_NEAGRA = (char)6;

            void arataCuRosu(string str){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(str);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            void arataInima()
            {
                arataCuRosu(CHR_INIMA_ROSIE.ToString());
            }
            void arataRomb() => arataCuRosu(CHR_ROMB.ToString());
            void arataTrefla() => Console.Write(CHR_TREFLA.ToString());
            void arataNeagra() => Console.Write(CHR_NEAGRA.ToString());

            var pachetCarti = new List<CarteJoc>();
            var culori = new List<string>()
            {
                "inima rosie", "romb", "trefla", "inima neagra"
            };
            foreach (var culoare in culori)
            {
                for (int i = 2; i < 15; i++)
                {
                    var carteNoua = new CarteJoc(){ 
                        Culoare = culoare, Valoare = i             
                    };

                if ( i <= 10){
                    carteNoua.Nume =i.ToString();

                }
                else if (i == 11)
                {
                    carteNoua.Nume = "J";
                }
                else if (i == 12)
                {
                    carteNoua.Nume = "Q";
                }         
                else if (i == 13)
                {
                    carteNoua.Nume = "K";
                }                
                else
                {
                    carteNoua.Nume = "A";
                }                          

                    pachetCarti.Add(carteNoua);
                }    
            }

            Random rnd = new Random();

            var pachetAmestecat = pachetCarti.OrderBy(c => rnd.Next());

            System.Console.WriteLine("Cartile de joc sunt:");

            foreach (var carte in pachetAmestecat)
            {
                System.Console.Write($"{carte.Nume}");
                if (carte.Culoare == "inima rosie")
                {
                    arataInima();
                }
                else if (carte.Culoare == "romb")
                {
                    arataRomb();
                }
                else if (carte.Culoare == "trefla")
                {
                    arataTrefla();
                }    
                else 
                {
                    arataNeagra();
                }            
                System.Console.WriteLine();
            }
        }

    }
}




/*
1. Nume carti - valet, popa, as
2. Caractere ASCII
3. Amestecat pachetul de carti

*/