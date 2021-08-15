using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            
    Console.WriteLine("Acum vom lucra la generarea unui cod random pentru a determina castigatorii unui concurs");
    Console.WriteLine("La concurs au participat 550 de oameni, iar fiecaruia i-a fost atribuit un numar");
    Console.WriteLine("Numerele extrase mai jos vor fi cei 5 castigatori de astazi");

var nr = 0;
while (nr<5) {
    Console.WriteLine("Un castigator este:");
    var nrCalc = Math.Round(System.Random * 550); 
    Console.WriteLine(nrCalc); 
    Console.WriteLine("Participantul cu numarul de mai sus, te rugam sa-ti scrii numele");
    Console.ReadLine(); 
    nr = nr + 1;
}

Console.WriteLine("Felicitari tuturor participantilor! Ne revedem maine cu o noua serie de castigatori!")




        }
    }
}
