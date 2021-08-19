using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        //in C# specificam tipul returnat (in cazul nostru int) si tipul
        //parametrilor, in cazul nostru o lista / un array de string-uri
        static int oferaOptiuniSiPreiaRaspunsValid(string[] listaDeOptiuni)
        {
            Console.WriteLine("Ai urmatoarele optiuni:");
            int index = 0;
            while(index < listaDeOptiuni.Length)
            {
                Console.WriteLine("   [" + (index + 1).ToString() + "] " + listaDeOptiuni[index]);

                index = index + 1;
            }

            Console.WriteLine($@"Ce alegi (1-{listaDeOptiuni.Length})?");

            string alegereUtilizator = "";
            int nr = 0;
            while(alegereUtilizator == ""){
                alegereUtilizator = Console.ReadLine();
                //int.TryParse incearca sa transforme un string in numar intreg si daca nu reuseste 
                //lasa numarul 0 si returneaza valoarea booleana false
                //de aceea am pus prima conditie (not intr.TryParse --- !int.TryParse), adica
                //pe romaneste: daca nu poti transforma stringul in numar
                //Daca a reusit transformarea, parametrul #2 (in cazul nostru nr) primeste in el valoarea
                //citita (paranteza: cand vedeti cuvintele out sau ref inainte de parametri,
                //inseamna ca functia va poate schimba variabila)
                if(!int.TryParse(alegereUtilizator, out nr) || nr < 1 || nr > listaDeOptiuni.Length){
                    Console.WriteLine($@"Optiune inexistenta, te rog reintrodu o optiune de la 1 la {listaDeOptiuni.Length}.");
                    alegereUtilizator = "";
                }
            }

            return nr - 1;
        }

        static void Main(string[] args)
        {
            //in C# putem defini variabilele cu var si apoi sa le dam o valoare
            //si compilatorul "ghiceste" tipul variabilei la fel ca in js sau python
            //dar putem si sa le specificam direct tipul, cum ar fi string, bool, int, s.a.m.d.
            string pozitieCurenta = "hol";
            bool areCheie = false;

            bool primaDataIn_Hol = true;
            bool primaDataIn_Baie = true;
            bool primaDataIn_Dormitor = true;
            bool primaDataIn_Sufragerie = true;
            bool primaDataIn_Balcon = true;

            while(pozitieCurenta != "afara"){
                if(pozitieCurenta == "hol"){
                    if(primaDataIn_Hol){
                        Console.WriteLine($@"Esti in holul unei case din care trebuie neaparat sa iesi.");

                        primaDataIn_Hol = false;
                    }
                    else {
                        Console.WriteLine($@"Esti in hol.");
                    }

                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(new string[]{
                        "usa de intrare/iesire din apartament"
                        , "usa de la baie"
                        , "usa de la dormitor"
                        , "usa de la sufragerie"
                    });

                    string[] listaPozitiiUrmatoare = new string[]{
                        "afara" //0
                        , "baie" //1
                        , "dormitor" //2
                        , "sufragerie" //3
                    };

                    pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
                    
                    //cum areCheie e boolean (adica true sau false), am inlocuit areCheie != "da" cu (nu areCheie, care in limbaj e !areCheie)
                    if(pozitieCurenta == "afara" && !areCheie)
                    {
                        Console.WriteLine("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
                        Console.WriteLine("Va trebui sa incerci altceva.");
                        pozitieCurenta = "hol";
                    }
                }
                else if(pozitieCurenta == "baie"){
                    if(primaDataIn_Baie){
                        Console.WriteLine($@"Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
            Se arde becul si ai ramas in intuneric.
            ");

                        primaDataIn_Baie = false;
                    }
                    else {
                        Console.WriteLine($@"Esti in baie si e bezna.");
                    }

                    Console.WriteLine($@"Nu ai nici o alta optiune decat sa te intorci in hol.");
                    pozitieCurenta = "hol";
                }
                else if(pozitieCurenta == "dormitor"){
                    if(primaDataIn_Dormitor){
                        Console.WriteLine($@"Dormitorul arata sinistru.");

                        primaDataIn_Dormitor = false;
                    }
                    else {
                        Console.WriteLine($@"Esti in dormitor.");
                    }

                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(new string[]{
                        "usa catre hol"
                        , "usa catre balcon"
                    });

                    string[] listaPozitiiUrmatoare = new string[]{
                        "hol" //0
                        , "balcon" //1
                    };

                    pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
                }
                else if(pozitieCurenta == "sufragerie"){
                    if(primaDataIn_Sufragerie){
                        Console.WriteLine($@"Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.");

                        primaDataIn_Sufragerie = false;
                    }
                    else {
                        Console.WriteLine($@"Esti in sufragerie.");
                    }

                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(new string[]{
                        "usa catre hol"
                        , "usa catre balcon"
                    });

                    string[] listaPozitiiUrmatoare = new string[]{
                        "hol" //0
                        , "balcon" //1
                    };

                    pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];
                }
                else if(pozitieCurenta == "balcon"){
                    if(primaDataIn_Balcon){
                        Console.WriteLine($@"Din balcon se vede afara. Esti la etajul 12.");

                        primaDataIn_Balcon = false;
                    }
                    else {
                        Console.WriteLine($@"Esti in balcon.");
                    }

                    int raspunsUtilizator = 0;
                    
                    if(areCheie){
                        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(new string[]{
                            "usa catre dormitor"
                            , "usa catre sufragerie"
                        });
                    }
                    else {
                        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(new string[]{
                            "usa catre dormitor"
                            , "usa catre sufragerie"
                            , "ridica cheia de pe jos"
                        });
                    }

                    string[] listaPozitiiUrmatoare = new string[]{
                        "dormitor" //0
                        , "sufragerie" //1
                        , "balcon" //2
                    };

                    pozitieCurenta = listaPozitiiUrmatoare[raspunsUtilizator];

                    if(pozitieCurenta == "balcon"){
                        Console.WriteLine("Ai luat cheia, acum poti deschide ceva.");
                        areCheie = true;
                    }
                }
            }

            Console.WriteLine("Ai reusit sa scapi din apartament, felicitari!");
        }
    }
}
