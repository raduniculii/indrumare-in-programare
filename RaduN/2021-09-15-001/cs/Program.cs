using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static int adunaLista(List<int> lista)
        {
            int index = 0;
            int sum = 0;
            while(index < lista.Count){
                sum += lista[index];  // echivalent cu sum = sum + lista[index];
                index++; // echivalent cu index += 1 echivalent cu index = index + 1;
            }
            
            return sum;
        }

        static int patrat(int nr)
        {
            return nr * nr;
        }

        static int adunaPatrateleDinLista(List<int> lista)
        {
            int index = 0;
            int sum = 0;
            while(index < lista.Count)
            {
                sum += patrat(lista[index]); // echivalent cu sum = sum + lista[index]
                index++; // echivalent cu index += 1 echivalent cu index = index + 1
            }
            
            return sum;
        }

        static void Main(string[] args)
        {
            var lst = new List<int>(){ 1, 2, 4 };

            //C# nu ne afiseaza continutul liste daca o punem doar asa in Console.WriteLine, asa ca o transformam intr-un string, unind elementele int din lista cu  ", " intre ele.
            Console.WriteLine($@"Suma numerelor {string.Join<int>(", ", lst)} este {adunaLista(lst)}");
            lst.Add(12);
            Console.WriteLine($@"Suma numerelor {string.Join<int>(", ", lst)} este {adunaLista(lst)}");

            int nrTest = 2;
            Console.WriteLine($@"Patratul lui {nrTest} este: {patrat(nrTest)}");
            nrTest = 9;
            Console.WriteLine($@"Patratul lui {nrTest} este: {patrat(nrTest)}");

            lst = new List<int>(){ 1, 2 };

            Console.WriteLine($@"Suma patratelor numerelor {string.Join<int>(", ", lst)} este {adunaPatrateleDinLista(lst)}");
            lst.Add(4);
            Console.WriteLine($@"Suma patratelor numerelor {string.Join<int>(", ", lst)} este {adunaPatrateleDinLista(lst)}");


            var listaNoua = new List<int>(){ 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine(string.Join<int>(", ", listaNoua));
            var listaDePatrate = listaNoua.ConvertAll<int>((x) => x * x); //mergea si cu listaNoua.ConvertAll<int>(patrat), adica doar voia o functie care sa primeasca un numar si sa returneze ceva. (x) => x*x e un lambda care face asta in c#

            Console.WriteLine(string.Join<int>(", ", listaDePatrate));
            Console.WriteLine(adunaLista(listaDePatrate));

            Console.WriteLine(adunaLista(listaNoua.ConvertAll<int>(patrat)));


            //(x) => x*x sau (x) => patrat(x) e tot una cu 
            //static int myAnonymousFunction(int element){
            //   return patrat(element);
            //}
        }
    }
}
