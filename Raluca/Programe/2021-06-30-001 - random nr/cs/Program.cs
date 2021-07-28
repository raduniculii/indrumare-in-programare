using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# merge!");
            
            var doi = "2";
            var nrDoi = 2;
          
            Console.WriteLine(doi + doi);
            Console.WriteLine(nrDoi + nrDoi);
            
            Console.WriteLine("Introdu un numar: ");
            var nrUtilizator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine((nrUtilizator) + nrUtilizator);
            
           Random rnd = new Random();
           int Zar  = rnd.Next(1, 7);
           Console.WriteLine(Zar);
        
    
        }
    }
}