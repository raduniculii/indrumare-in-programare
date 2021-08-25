using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        const int IX_HOL = 0;
        const int IX_BAIE = 1;
        const int IX_DORMITOR = 2;
        const int IX_SUFRAGERIE = 3;
        const int IX_BALCON = 4;
        const int IX_AFARA = 5;
        const int IX_CHEIE = 6;

        static List<bool> primaDataIn = new List<bool>(){ true, true, true, true, true, true, true };
        static List<string> primulText = new List<string>(){
            $@"Esti in holul unei case din care trebuie neaparat sa iesi."
            , $@"Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric.
"
            , $@"Dormitorul arata sinistru."
            , $@"Sufrageria arata primitor, desi tu nu ai timp sa stai la TV."
            , $@"Din balcon se vede afara. Esti la etajul 12."
            , null
        };
        static List<string> textulUrmator = new List<string>(){
            $@"Esti in hol."
            , $@"Esti in baie si e bezna."
            , $@"Esti in dormitor."
            , $@"Esti in sufragerie."
            , $@"Esti in balcon."
            , ""
            , null
        };
        static List<string> textOptiune = new List<string>(){
              "usa de la hol."
            , "usa de la baie"
            , "usa de la dormitor."
            , "usa de la sufragerie."
            , "usa de la balcon"
            , "usa de intrare/iesire din apartament"
            , "ridica cheia"
        };

        //in C# specificam tipul returnat (in cazul nostru int) si tipul
        //parametrilor, in cazul nostru o lista / un array de string-uri
        static int oferaOptiuniSiPreiaRaspunsValid(int[] listaDeOptiuni)
        {
            Console.WriteLine("Ai urmatoarele optiuni:");
            int index = 0;
            while(index < listaDeOptiuni.Length)
            {
                Console.WriteLine("   [" + (index + 1).ToString() + "] " + textOptiune[listaDeOptiuni[index]]);

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

            return listaDeOptiuni[nr - 1];
        }

        static void AfiseazaMesajCameraSiActualizeazaPrimaData(int indexCamera)
        {
            if(primaDataIn[indexCamera]){
                Console.WriteLine(primulText[indexCamera]);

                primaDataIn[indexCamera] = false;
            }
            else {
                Console.WriteLine(textulUrmator[indexCamera]);
            }
        }

        static void Main(string[] args)
        {
            //in C# putem defini variabilele cu var si apoi sa le dam o valoare
            //si compilatorul "ghiceste" tipul variabilei la fel ca in js sau python
            //dar putem si sa le specificam direct tipul, cum ar fi string, bool, int, s.a.m.d.
            int pozitieCurenta = IX_HOL;
            bool areCheie = false;

            while(pozitieCurenta != IX_AFARA){
                if(pozitieCurenta == IX_HOL){
                    AfiseazaMesajCameraSiActualizeazaPrimaData(IX_HOL);

                    int[] listaPozitiiUrmatoare = new int[]{
                        IX_AFARA
                        , IX_BAIE
                        , IX_DORMITOR
                        , IX_SUFRAGERIE
                    };
                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaPozitiiUrmatoare);

                    pozitieCurenta = raspunsUtilizator;
                    
                    //cum areCheie e boolean (adica true sau false), am inlocuit areCheie != "da" cu (nu areCheie, care in limbaj e !areCheie)
                    if(pozitieCurenta == IX_AFARA && !areCheie)
                    {
                        Console.WriteLine("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
                        Console.WriteLine("Va trebui sa incerci altceva.");
                        pozitieCurenta = IX_HOL;
                    }
                }
                else if(pozitieCurenta == IX_BAIE){
                    AfiseazaMesajCameraSiActualizeazaPrimaData(IX_BAIE);

                    Console.WriteLine($@"Nu ai nici o alta optiune decat sa te intorci in hol.");
                    pozitieCurenta = IX_HOL;
                }
                else if(pozitieCurenta == IX_DORMITOR){
                    AfiseazaMesajCameraSiActualizeazaPrimaData(IX_DORMITOR);

                    int[] listaPozitiiUrmatoare = new int[]{
                        IX_HOL
                        , IX_BALCON
                    };
                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaPozitiiUrmatoare);

                    pozitieCurenta = raspunsUtilizator;
                }
                else if(pozitieCurenta == IX_SUFRAGERIE){
                    AfiseazaMesajCameraSiActualizeazaPrimaData(IX_SUFRAGERIE);

                    int[] listaPozitiiUrmatoare = new int[]{
                        IX_HOL
                        , IX_BALCON
                    };
                    int raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaPozitiiUrmatoare);

                    pozitieCurenta = raspunsUtilizator;
                }
                else if(pozitieCurenta == IX_BALCON){
                    AfiseazaMesajCameraSiActualizeazaPrimaData(IX_BALCON);

                    int raspunsUtilizator = 0;
                    
                    if(areCheie){
                        int[] listaPozitiiUrmatoare = new int[]{
                            IX_BALCON
                            , IX_SUFRAGERIE
                        };
                        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaPozitiiUrmatoare);
                    }
                    else {
                        int[] listaPozitiiUrmatoare = new int[]{
                            IX_BALCON
                            , IX_SUFRAGERIE
                            , IX_CHEIE
                        };
                        raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaPozitiiUrmatoare);
                    }

                    pozitieCurenta = raspunsUtilizator;

                    if(pozitieCurenta == IX_CHEIE){
                        Console.WriteLine("Ai luat cheia, acum poti deschide ceva.");
                        areCheie = true;
                        pozitieCurenta = IX_BALCON;
                    }
                }
            }

            Console.WriteLine("Ai reusit sa scapi din apartament, felicitari!");
        }
    }
}
