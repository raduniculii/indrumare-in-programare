using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        //ListaDeOptiuni cu numere intregi
        public static List<int> getList()
            {
                List<int> listaDeNumere = new List<int>();
                    listaDeNumere.Add(12);
                    listaDeNumere.Add(52);
                    listaDeNumere.Add(16);
                    listaDeNumere.Add(6);
                    listaDeNumere.Add(14);
                int j = 0;      
                Console.WriteLine($"Lista de numere este: ");
                while (j < listaDeNumere.Count)
                {
                    Console.WriteLine(listaDeNumere[j]);
                    j = j+1;   
                }
                Console.WriteLine();
                return listaDeNumere;
            }
        
        //ListaDeOptiuni cu nume
        public static List<string> getListNume()
            {
                List<string> listaDeNume = new List<string>();
                    listaDeNume.Add("Andrei");
                    listaDeNume.Add("Bogdan");
                    listaDeNume.Add("Cristina");
                    listaDeNume.Add("Dragos");
                    listaDeNume.Add("Elena");
                    listaDeNume.Add("Bogdan");
                int j = 0;      
                Console.WriteLine($"Lista de nume este: ");
                while (j < listaDeNume.Count)
                {
                    Console.WriteLine(listaDeNume[j]);
                    j = j+1;   
                }
                Console.WriteLine();
                return listaDeNume;
            }
        
        //ListaDeOptiuni cu numere negatove si pozitive
         public static List<int> getListPozitivSiNegativ()
            {
                List<int> listaDeNumere = new List<int>();
                    listaDeNumere.Add(-12);
                    listaDeNumere.Add(52);
                    listaDeNumere.Add(2);
                    listaDeNumere.Add(-16);
                    listaDeNumere.Add(-16);
                    listaDeNumere.Add(-6);
                    listaDeNumere.Add(14);
                    listaDeNumere.Add(0);
                    listaDeNumere.Add(14);
                int j = 0;      
                Console.WriteLine($"Lista de numere este: ");
                while (j < listaDeNumere.Count)
                {
                    Console.WriteLine(listaDeNumere[j]);
                    j = j+1;   
                }
                Console.WriteLine();
                return listaDeNumere;
            }
        
        //1. Un program care sa afiseze suma numerelor dintr-o lista
        public static int adunareNumereLista()
            {
                List <int> listaDeNumere = getList();
                int i = 0;
                int Suma = 0;
                while (i < listaDeNumere.Count)
                {
                    Suma = Suma + listaDeNumere[i];
                    i = i+1;                 
                }
                return Suma;
            }
        
        //2. Un program care sa calculeze media numerelor din lista (pt c# folositi double in loc de int pentru medie, astfel incat sa va calculeze si valori cu virgula, nu doar intregi)

        public static double medieNumereLista()
        {
            List <int> listaDeNumere = getList();
            int i = 0;
            int Suma = 0;
            double Media = 0;
            while (i < listaDeNumere.Count)
            {
                Suma = Suma + listaDeNumere[i];
                
                i = i+1;  
            }
            Media = Suma / i;
            return Media;
        }

        //3. Un program care sa gaseasca cel mai mic (sau mare) numar dintr-o lista de numere

        public static int minimNumereLista()
        {
            List <int> listaDeNumere = getList();
            int i = 1;
            int Minim = listaDeNumere[0];         
            while (i < listaDeNumere.Count)
            {
                if (listaDeNumere[i] < Minim)
                {
                    Minim = listaDeNumere[i];
                }           
                i = i+1;   
            }
            return Minim;
        }
            
        //4. Un program care sa zica la ce index avem un anumit nume in lista, sau daca nu e gasit sa afiseze "nu am gasit" si sa planga 10 minute.
        public static void indexNumeLista(string Nume)
                {
                    List <string> listaDeNume = getListNume();                                  
                    int Index = 0;
                    bool NumeGasit = false;
                    while (Index < listaDeNume.Count)
                    {
                        if (Nume == listaDeNume[Index])
                        {
                            NumeGasit = true;
                            Console.WriteLine($"Numele " + Nume + " este pe pozitia " + (Index + 1) + " din lista.");
                            Index = Index + 1; 
                        }
                        else 
                        {
                            Index = Index + 1; 
                        }
                    }
                        if (NumeGasit == false)
                        {
                            Console.WriteLine( Nume + $" nu este in lista, asa ca nu ai decat sa plangi cat vrei!");
                        }                    
                } 

        //5. Un program care sa afiseze valoarile unei liste in ordine inversa
        public static List <int> inversareListaLaAfisare()
                {
                    List <int> listaDeNumere = getList();  
                    int j = listaDeNumere.Count - 1;    
                    Console.WriteLine($"Lista afisata in ordine inversa este: ");
                    while (j >= 0)
                    {
                        Console.WriteLine(listaDeNumere[j]);
                        j = j-1;   
                    }
                    return listaDeNumere;
                } 
        
        //6. Un program care e despre a fi pozitiv. Sa "curete" lista de numere negative, sa lea stearga si sa lase doar ce e pozitiv. 
        //ATENTIE, vor aparea niste probleme aici, faceti teste si cu o lista care are mai multe numere negative unul langa altul si vedeti de ce nu va merge din prima... 
        //poate puneti writeline sau console log sau print si vedeti de ce nu merge cum ati crezut.

        public static List <int> ListaNumerePozitive()
        {
            List <int> listaDeNumere = getListPozitivSiNegativ();
            int i = 0;
            while (i < listaDeNumere.Count)
            {
                if (listaDeNumere[i] < 0)
                {
                    listaDeNumere.RemoveAt(i);
                }
                else
                {
                    i = i + 1;
                }
            }
            int j = 0;      
            Console.WriteLine($"Lista de numere pozitive este: ");
            while (j < listaDeNumere.Count)
            {
                Console.WriteLine(listaDeNumere[j]);
                j = j+1;   
            }
            return listaDeNumere;
        }

        //7. Un program care sa inverseze valorile dintr-o lista, nu doar sa le afiseze invers ca la punctul 5,
        //adica daca are [1, 2, 3, 4, 5] sa aiba la sfarsit 5 la indexul 0, 4 la 1, ... si 1 la indexul 4 (ultimul).
        
        public static List <int> inversareLista()
        {
            List <int> listaDeNumere = getList();
            int i = 0;
            int z = listaDeNumere.Count - 1;
            int TineMinte;          
            while (i < (listaDeNumere.Count/2))
            {
                TineMinte =  listaDeNumere[z];
                listaDeNumere[z] = listaDeNumere[i]; //z devine elementul de pe pozitia simetrica cu elementul de pe pozitia i
                listaDeNumere[i] = TineMinte;                   
                z = z-1;
                i = i+1;  
            }
            int j = 0;      
            Console.WriteLine($"Lista in ordine inversa este: ");
            while (j < listaDeNumere.Count)
            {
                Console.WriteLine(listaDeNumere[j]);
                j = j+1;   
            }
            return listaDeNumere;
        } 

        //8. Un program care sa sorteze o lista (adica sa aseze valorile in ordine crescatoare) fara sa va folositi de functiile de sort pe care le au deja limbajele de programare. 
        //Asta ca sa faceti muschi pentru manipulat liste. S-ar putea sa va fie foarte greu.
        public static List <int> ListaInOrdineCrescatoare()
        {
            List <int> listaDeNumere = getListPozitivSiNegativ();
            int i = 0;
            int j = 1;
            int TineMinte = 0;
            while (i < listaDeNumere.Count - 1)
            {
                while (j < listaDeNumere.Count)
                {
                    if (listaDeNumere[i] <= listaDeNumere[j])
                    {
                        j = j + 1;
                    }
                    else
                    {
                        TineMinte = listaDeNumere[j];
                        listaDeNumere[j] = listaDeNumere[i];
                        listaDeNumere[i] = TineMinte;
                        j = i + 2;
                    }                    
                }
                j = i + 2;
                i = i + 1;   
            }
            
            int ix = 0;      
            Console.WriteLine($"Lista de numere in ordine crescatoare este: ");
            while (ix < listaDeNumere.Count)
            {
                Console.WriteLine(listaDeNumere[ix]);
                ix = ix + 1;   
            }
            return listaDeNumere; 
        }


        static void Main(string[] args)
        {
            //Apelare functie exercitiu 1
            Console.WriteLine($"Suma numerelor din lista este " + adunareNumereLista());
            Console.WriteLine();

            //Apelare functie exercitiu 2    
            Console.WriteLine($"Media numerelor din lista este " + medieNumereLista());
            Console.WriteLine();

            //Apelare functie exercitiu 3
            Console.WriteLine($"Minimul numerelor din lista este " + minimNumereLista());
            Console.WriteLine();

            //Apelare functie exercitiu 4
            inversareListaLaAfisare();
            Console.WriteLine();

            //Apelare functie exercitiu 5
            indexNumeLista("Maria");
            Console.WriteLine();

            indexNumeLista("Bogdan");
            Console.WriteLine();

            //Apelare functie exercitiu 6
            ListaNumerePozitive();
            Console.WriteLine();

            //Apelare functie exercitiu 7
            inversareLista();
            Console.WriteLine(); 
            
            //Apelare functie exercitiu 8
            ListaInOrdineCrescatoare();
            Console.WriteLine();
        }
    }
}