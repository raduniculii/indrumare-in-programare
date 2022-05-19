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

            var pachetAmestecat = pachetCarti.OrderBy(c => rnd.Next()).ToList();

            var manaJucator = new List<CarteJoc>();
            var n = 5;


            manaJucator = pachetAmestecat.GetRange(0 , n);
            pachetAmestecat.RemoveRange(0, n);

            System.Console.WriteLine("Cartile jucatorului sunt:");

            foreach (var carte in manaJucator)
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

            System.Console.WriteLine("Spune pozitia cartilor pe care le arunci?");
            string cartiAruncate = Console.ReadLine();

            var impartite = cartiAruncate.Split(" ");


            foreach (var pozitie in impartite)
            {

                manaJucator[int.Parse(pozitie)-1] = pachetAmestecat[0];
                pachetAmestecat.RemoveAt(0);

            }
            System.Console.WriteLine("Noile carti sunt:");

            foreach (var carte in manaJucator)
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

/*
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
            }*/
        }

    }
}




/*
1. Nume carti - valet, popa, as
2. Caractere ASCII
3. Amestecat pachetul de carti
4. creat copie a pachetului de carti, luati fiecare carte una cate una random si sa le puneti in celalalt pachet.  
5. afiseaza primele 5 carti
6. mecanism pentru hold

7. de facut n-ul
8. calculare puncte 

https://www.casinoreports.ca/video-poker/rules/

Coins	1	2	3	4	5
Royal Flush	250	500	750	1000	4000
Straight Flush	50	100	150	200	250
Four of a Kind	25	50	75	100	125
Full House	9	18	27	36	45
Flush	6	12	18	24	30
Straight	4	8	12	16	20
Three of a Kind	3	6	9	12	15
Two Pair	2	4	6	8	10
Jacks or Better	1	2	3	4	5

*/