using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var pozitieCurenta = "hol";
            var pozitieNoua = "";
            bool areCheie = false;
            bool primaDataIn_Hol = true;
            var primaDataIn_Baie = "da";
            var primaDataIn_Dormitor = "da";
            var primaDataIn_Sufragerie = "da";
            var primaDataIn_Balcon = "da";

            while(pozitieCurenta != "afara"){
                if(pozitieCurenta == "hol"){
                    if(primaDataIn_Hol){
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
                            if(areCheie){
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
                    if(primaDataIn_Baie == "da"){
                        Console.WriteLine($@"Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
");

                        primaDataIn_Baie = "nu";
                    }
                    else {
                        Console.WriteLine("Esti in baie si e bezna.");
                    }

                    Console.WriteLine("Nu ai nici o alta optiune decat sa te intorci in hol.");
                    pozitieCurenta = "hol";
                }
                else if(pozitieCurenta == "dormitor"){
                    if(primaDataIn_Dormitor == "da"){
                        Console.WriteLine("Dormitorul arata sinistru.");

                        primaDataIn_Dormitor = "nu";
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
                    if(primaDataIn_Sufragerie == "da"){
                        Console.WriteLine("Sufrageria arata primitor, desi tu nu ai timp sa stai la TV.");

                        primaDataIn_Sufragerie = "nu";
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
                    if(primaDataIn_Balcon == "da"){
                        Console.WriteLine("Din balcon se vede afara. Esti la etajul 12.");

                        primaDataIn_Balcon = "nu";
                    }
                    else {
                        Console.WriteLine("Esti in balcon.");
                    }

                    if(areCheie){
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
                        else if(pozitieNoua == "3" && areCheie){
                            pozitieCurenta = "balcon";
                            areCheie = true;
                            Console.WriteLine("Acum ai luat cheia si poti deschide ceva.");
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
