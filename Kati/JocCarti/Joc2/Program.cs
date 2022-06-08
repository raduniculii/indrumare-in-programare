using System;
using System.Collections.Generic;
using System.Linq;

namespace Joc2
{

    class AparitiiValoare {
        public int Valoare { get; set; }
        public int Aparitii { get; set; }
        public AparitiiValoare (int val){
            Valoare = val;
            Aparitii = 1;
        
        }
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            const char CHR_INIMA_ROSIE = (char)3;
            const char CHR_ROMB = (char)4;
            const char CHR_TREFLA = (char)5;
            const char CHR_NEAGRA = (char)6;

            void arataCuRosu(string str)
            {
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
                    var carteNoua = new CarteJoc()
                    {
                        Culoare = culoare,
                        Valoare = i
                    };

                    if (i <= 10)
                    {
                        carteNoua.Nume = i.ToString();

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


            manaJucator = pachetAmestecat.GetRange(0, n);
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

                manaJucator[int.Parse(pozitie) - 1] = pachetAmestecat[0];
                pachetAmestecat.RemoveAt(0);

            }
            System.Console.WriteLine("Noile carti sunt:");
            AfiseazaMana(manaJucator);

            manaJucator.Sort((c1, c2) => c1.Valoare.CompareTo(c2.Valoare));

            List<AparitiiValoare> numaraValorile(List<CarteJoc> manaJucator)
            {
                var Aparitii = new List<AparitiiValoare>();
                foreach (var carte in manaJucator)
                {
                    var gasit = false;

                    foreach (var aparitie in Aparitii)
                    {
                        if (aparitie.Valoare == carte.Valoare)
                        {
                            aparitie.Aparitii++;
                            gasit = true;
                            break;

                        }
                    }

                    if (!gasit)
                    {
                        Aparitii.Add(new AparitiiValoare(carte.Valoare));
                    }

                }
                Aparitii.Sort((a, b) => b.Aparitii.CompareTo(a.Aparitii));  // sorteaza descendent 
                                                                            // 3.compareTo 5 => (3-5)=-2
                                                                            // negativ = a e primul
                                                                            // pozitiv = b e primul 

                return Aparitii;
            }
            bool isRoyalFlush(List<CarteJoc> manaJucator)
            {
                var numarulPrimeiCarti = manaJucator[0].Valoare;
                return isStraightFlush(manaJucator) && numarulPrimeiCarti == 10;

                // Royal Flush >> consecutiv de aceasi culoare de la 10 pana la as

            }

            bool isStraightFlush(List<CarteJoc> manaJucator)
            {
                return isFlush(manaJucator) && isStraight(manaJucator);

                // Straight Flush>> consecutiv de aceasi culoare  care nu e royal flush

            }

            bool isFourOfAKind(List<CarteJoc> manaJucator)
            {
                var Aparitii = numaraValorile(manaJucator);

                return Aparitii[0].Aparitii == 4;

                // 2 - 3
                // 7 - 1 
                // 10 - 1

                // from student in students
                //     group student by student.LastName into newGroup
                //     orderby newGroup.Key
                //     select newGroup;

                // Four of a Kind>> 4 de acelasi numar


            }

            bool isFullHouse(List<CarteJoc> manaJucator)
            {
                var Aparitii = numaraValorile(manaJucator);

                return (Aparitii[0].Aparitii == 3) && (Aparitii[1].Aparitii == 2);

                // Full House>> 3 cu 2 de numar 

            }

            bool isFlush(List<CarteJoc> manaJucator)
            {
                var culoareaPrimeiCarti = manaJucator[0].Culoare;
                foreach (var carte in manaJucator)
                {
                    if (carte.Culoare != culoareaPrimeiCarti)
                    {
                        return false;
                    }
                }
                return true;


                // var toateLaFel = true;
                // foreach(var carte in manaJucator){
                //     if(carte.Culoare != culoareaPrimeiCarti){
                //         toateLaFel = false;
                //     }
                // }
                // return toateLaFel;


                //cu greseala 
                // var toateLaFel = false;
                // foreach(var carte in manaJucator){
                //     if(carte.Culoare == primaCuloare){
                //         toateLaFel = true;
                //     }
                //     else toateLaFel = false;
                // }


                // Flush>> 5 de aceasi culoare si sa nu fie royal sau straight flush

            }

            bool isStraight(List<CarteJoc> manaJucator)
            {

                for (int i = 0; i < manaJucator.Count - 1; i++)
                {
                    if (manaJucator[i + 1].Valoare - manaJucator[i].Valoare != 1) return false;

                }
                return true;

                // var valoarePrecedenta = manaJucator[0].Valoare;

                // foreach (var valoare in manaJucator.Skip(1).Select(c => c.Valoare))
                // {
                //     if (valoare - 1 != valoarePrecedenta){
                //         return false;
                //     }

                // }
                // return true;

                // Straight	>> numere consecutive si sa nu fie royal sau straight flush

            }

            bool isThreeOfAKind(List<CarteJoc> manaJucator)
            {
                var Aparitii = numaraValorile(manaJucator);

                return (Aparitii[0].Aparitii == 3) && (!isFullHouse(manaJucator));

                // Three of a Kind>> 3 de acelasi fel


            }

            bool isTwoPairs(List<CarteJoc> manaJucator)
            {
                var Aparitii = numaraValorile(manaJucator);

                return (Aparitii[0].Aparitii == 2) && (Aparitii[1].Aparitii == 2);


                // Two Pair	>> 2 perechi

            }

            bool isJacksOrBetter(List<CarteJoc> manaJucator)
            {
                var Aparitii = numaraValorile(manaJucator);

                return (Aparitii[0].Aparitii == 2) && (Aparitii[0].Valoare >= 11) && (!isTwoPairs(manaJucator));

                // Jacks or Better>> 1 pereche de la valet in sus

            }

            System.Console.WriteLine("Noua mana este:");
            AfiseazaMana(manaJucator);

            if (isRoyalFlush(manaJucator))
            {
                System.Console.WriteLine("Ai prins chinta roiala mare");
            }
            else if (isStraightFlush(manaJucator))
            {
                System.Console.WriteLine("Ai prins chinta roiala");
            }
            else if (isFourOfAKind(manaJucator))
            {
                System.Console.WriteLine("Ai prins careu");
            }
            else if (isFullHouse(manaJucator))
            {
                System.Console.WriteLine("Ai prins full");
            }
            else if (isFlush(manaJucator))
            {
                System.Console.WriteLine("Ai prins culoare");
            }
            else if (isStraight(manaJucator))
            {
                System.Console.WriteLine("Ai prins chinta");
            }
            else if (isThreeOfAKind(manaJucator))
            {
                System.Console.WriteLine("Ai prins trei bucati");
            }
            else if (isTwoPairs(manaJucator))
            {
                System.Console.WriteLine("Ai prins doua perechi");
            }
            else if (isJacksOrBetter(manaJucator))
            {
                System.Console.WriteLine("Ai prins o pereche");
            }
            else
            {
                System.Console.WriteLine("Nu ai prins nimic.");
            }

            void AfiseazaMana(List<CarteJoc> manaJucator)
            {
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

Coins	            1	2	3	4	5
Royal Flush	       250	500	750	1000	4000  >> consecutiv de aceasi culoare de la 10 pana la as
Straight Flush	    50	100	150	200	250   >> consecutiv de aceasi culoare  care nu e royal flush
Four of a Kind	    25	50	75	100	125   >> 4 de acelasi numar
Full House  	    9	18	27	36	45    >> 3 cu 2 de numar 
Flush	            6	12	18	24	30    >> 5 de aceasi culoare si sa nu fie royal sau straight flush
Straight	        4	8	12	16	20    >> numere consecutive si sa nu fie royal sau straight flush
Three of a Kind	    3	6	9	12	15    >> 3 de acelasi fel
Two Pair	        2	4	6	8	10    >> 2 perechi
Jacks or Better	    1	2	3	4	5     >> 1 pereche de la valet in sus


*/