using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void functieTest(string nume, int varsta){
            System.Console.WriteLine($@"salut {nume} ai {varsta} ani.");
        }

        static string functieTestCuReturn(string nume, int varsta){
            //Since 'functieTestCuReturn' returns void, a return keyword must not be followed by an object expression

            return $@"salut {nume} ai {varsta} ani.";
        }

        static int citesteNumar(string mesaj, int min, int max)
        {
            int nrCitit = 0;

            System.Console.WriteLine(mesaj);
            nrCitit = int.Parse(Console.ReadLine());

            while(nrCitit < min || nrCitit > max)
            {
                System.Console.WriteLine($@"Numarul trebuie sa fie intre {min} si {max}");
                System.Console.WriteLine(mesaj);
                nrCitit = int.Parse(Console.ReadLine());
            }

            return nrCitit;
        }

        //static returnType numeFc(tipParam_1 numeParam1, ...){
        //    comenzile din functie
        //}

        static void Main(string[] args)
        {
            List<string> listaDeNume = new List<string>(){ "John", "William", "Catherine", "Sam" };

            // listaDeNume.Add("John");
            // listaDeNume.Add("William");
            // listaDeNume.Add("Catherine");
            // listaDeNume.Add("Sam");

            int index = 0;

            listaDeNume.RemoveAt(1);
            Console.WriteLine($@"Cine e la 1? {listaDeNume[1]}");

            while(index < listaDeNume.Count){
                Console.WriteLine(listaDeNume[index]);
                index = index + 1;
            }
        }

        static void VechiulMain()
        {
            var pozitieCurenta = "hol";
            var pozitieNoua = "";
            bool areCheie = false;

            bool primaDataIn_Hol = true;
            bool primaDataIn_Baie = true;
            bool primaDataIn_Dormitor = true;
            bool primaDataIn_Sufragerie = true;
            bool primaDataIn_Balcon = true;

            Random rnd = new Random();
            int option = rnd.Next(1, 6);
            string textulGhicitoarei = "";

            switch (option)
            {
                case 1:
                    textulGhicitoarei = "Traiti-ar fmilia";
                    break;
                case 2:
                    textulGhicitoarei = "O sa ai copii frumosi";
                    break;
                case 3:
                    textulGhicitoarei = "Viata e grea, da' trece";
                    break;
                case 4:
                    textulGhicitoarei = "4 ca la teatru";
                    break;
                case 5:
                    textulGhicitoarei = "zzz";
                    break;
                default:
                    break;
            }

            Console.WriteLine($@"Mama oOmida zice: {textulGhicitoarei}");

            functieTest("Gigi", 12);
            functieTest("Petre", 16);
            functieTest(varsta: 17, nume: "Maria");

            while(pozitieCurenta != "afara"){
                if(pozitieCurenta == "hol"){
                    if(primaDataIn_Hol == true){
                        Console.WriteLine("Esti in holul unei case din care trebuie neaparat sa iesi.");

                        primaDataIn_Hol = false;
                    }
                    else {
                        Console.WriteLine("Esti in hol.");
                    }

                    Console.WriteLine($@"Ai urmatoarele optiuni:
    [1] usa de intrare/iesire din apartament
    [2] usa de la baie
    [3] usa de la dormitor
    [4] usa de la sufragerie
Ce alegi(1-4)?");
                
                    pozitieNoua = "";
                    while(pozitieNoua == ""){
                        pozitieNoua = Console.ReadLine();

                        if(pozitieNoua == "1"){
                            if(areCheie == true){
                                pozitieCurenta = "afara";
                            }
                            else {
                                Console.WriteLine("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
                                Console.WriteLine("Va trebui sa incerci altceva.");
                            }
                        }
                        else if(pozitieNoua == "2"){
                            pozitieCurenta = "baie";
                        }
                        else if(pozitieNoua == "3"){
                            pozitieCurenta = "dormitor";
                        }
                        else if(pozitieNoua == "4"){
                            pozitieCurenta = "sufragerie";
                        }
                        else {
                            Console.WriteLine("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 4.");
                            pozitieNoua = "";
                        }
                    }
                }
                else if(pozitieCurenta == "baie"){
                    if(primaDataIn_Baie == true){
                        Console.WriteLine($@"Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
");

                        primaDataIn_Baie = false;
                    }
                    else {
                        Console.WriteLine("Esti in baie si e bezna.");
                    }

                    Console.WriteLine("Nu ai nici o alta optiune decat sa te intorci in hol.");
                    pozitieCurenta = "hol";
                }
                else if(pozitieCurenta == "dormitor"){
                    if(primaDataIn_Dormitor == true){
                        Console.WriteLine("Dormitorul arata sinistru.");

                        primaDataIn_Dormitor = false;
                    }
                    else {
                        Console.WriteLine("Esti in dormitor.");
                    }

                    Console.WriteLine($@"Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?");
                
                    pozitieNoua = "";
                    while(pozitieNoua == ""){
                        pozitieNoua = Console.ReadLine();

                        if(pozitieNoua == "1"){
                            pozitieCurenta = "hol";
                        }
                        else if(pozitieNoua == "2"){
                            pozitieCurenta = "balcon";
                        }
                        else {
                            Console.WriteLine("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                            pozitieNoua = "";
                        }
                    }
                }
                else if(pozitieCurenta == "sufragerie"){
                    if(primaDataIn_Sufragerie == true){
                        Console.WriteLine("Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.");

                        primaDataIn_Sufragerie = false;
                    }
                    else {
                        Console.WriteLine("Esti in sufragerie.");
                    }

                    Console.WriteLine($@"Ai urmatoarele optiuni:
    [1] usa catre hol
    [2] usa catre balcon
Ce alegi(1-2)?");
                
                    pozitieNoua = "";
                    while(pozitieNoua == ""){
                        pozitieNoua = Console.ReadLine();

                        if(pozitieNoua == "1"){
                            pozitieCurenta = "hol";
                        }
                        else if(pozitieNoua == "2"){
                            pozitieCurenta = "balcon";
                        }
                        else {
                            Console.WriteLine("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                            pozitieNoua = "";
                        }
                    }
                }
                else if(pozitieCurenta == "balcon"){
                    if(primaDataIn_Balcon == true){
                        Console.WriteLine("Din balcon se vede afara. Esti la etajul 12.");

                        primaDataIn_Balcon = false;
                    }
                    else {
                        Console.WriteLine("Esti in balcon.");
                    }

                    if(areCheie == true){
                        Console.WriteLine($@"Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
Ce alegi(1-2)?");
                    }
                    else {
                        Console.WriteLine($@"Pe jos se vede o cheie ruginita
Ai urmatoarele optiuni:
    [1] usa catre dormitor
    [2] usa catre sufragerie
    [3] ridica cheia de pe jos
Ce alegi(1-3)?");
                    }
                
                    pozitieNoua = "";
                    while(pozitieNoua == ""){
                        pozitieNoua = Console.ReadLine();

                        if(pozitieNoua == "1"){
                            pozitieCurenta = "dormitor";
                        }
                        else if(pozitieNoua == "2"){
                            pozitieCurenta = "sufragerie";
                        }
                        else if(pozitieNoua == "3" && areCheie != true){
                            pozitieCurenta = "balcon";
                            Console.WriteLine("Ai luat cheia, acum poti deschide ceva.");
                            areCheie = true;
                        }
                        else {
                            Console.WriteLine("Optiune inexistenta, te rog reintrodu o optiune de la 1 la 2.");
                            pozitieNoua = "";
                        }
                    }
                }
            }

            Console.WriteLine("Ai reusit sa scapi din apartament, felicitari!");
        }
    }
}
