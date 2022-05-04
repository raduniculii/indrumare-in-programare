using System;
using System.Collections.Generic;

namespace Joc2
{
    class Program
    {
        static void Main(string[] args)
        {
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

                    pachetCarti.Add(carteNoua);
                }    
            }
            System.Console.WriteLine("Cartile de joc sunt:");

            foreach (var carte in pachetCarti)
            {
                System.Console.WriteLine($"{carte.Valoare} de {carte.Culoare}");
            }

        }
    }
}
