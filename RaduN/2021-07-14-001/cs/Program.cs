using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        const int IX_NEVALID = -1;

        //astea nu mai sunt constante, ca sa le putem schimba ordinea si mai
        //stiu eu ce, asa ca folosim litere mici, ca si CONVENTIE (adica mergea
        //la fel programul si cu litere mari dar e conventie arhi-cunoscuta ca
        //avem constante cu caps lock si variabile normale fara)
        static int ixHol, ixBaie, ixDormitor, ixSufragerie, ixBalcon, ixAfara, ixCheie;

        static List<bool> primaDataIn = new List<bool>(){};
        static List<string> primulTextPentru = new List<string>(){};
        static List<string> textulUrmatorPentru = new List<string>(){};
        static List<string> textOptiunePentru = new List<string>(){};
        static List<List<int>> listaDeOptiuniPentru = new List<List<int>>(){};

        //in C# specificam tipul returnat (in cazul nostru int) si tipul
        //parametrilor, in cazul nostru o lista / un array de string-uri
        static int oferaOptiuniSiPreiaRaspunsValid(List<int> listaDeOptiuni)
        {
            if(listaDeOptiuni == null || listaDeOptiuni.Count == 0) return IX_NEVALID;

            Console.WriteLine("Ai urmatoarele optiuni:");
            int index = 0;
            while(index < listaDeOptiuni.Count)
            {
                Console.WriteLine("   [" + (index + 1).ToString() + "] " + textOptiunePentru[listaDeOptiuni[index]]);

                index = index + 1;
            }

            Console.WriteLine($@"Ce alegi (1-{listaDeOptiuni.Count})?");

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
                if(!int.TryParse(alegereUtilizator, out nr) || nr < 1 || nr > listaDeOptiuni.Count){
                    Console.WriteLine($@"Optiune inexistenta, te rog reintrodu o optiune de la 1 la {listaDeOptiuni.Count}.");
                    alegereUtilizator = "";
                }
            }

            return listaDeOptiuni[nr - 1];
        }

        static void AfiseazaMesajCameraSiActualizeazaPrimaData(int indexCamera)
        {
            if(primaDataIn[indexCamera]){
                Console.WriteLine(primulTextPentru[indexCamera]);

                primaDataIn[indexCamera] = false;
            }
            else {
                Console.WriteLine(textulUrmatorPentru[indexCamera]);
            }
        }

        static int AdaugaOptiune(string primulText, string textulUrmator, string textOptiune)
        {
            primaDataIn.Add(true);
            primulTextPentru.Add(primulText);
            textulUrmatorPentru.Add(textulUrmator);
            textOptiunePentru.Add(textOptiune);
            
            //punem null aici si o definim unde doar avem nevoie
            listaDeOptiuniPentru.Add(null);

            //returnam indexul elementului abia adaugat
            return primaDataIn.Count - 1;
        }

        static void ConfigureazaOptiuni()
        {
            ixHol = AdaugaOptiune(
                $@"Esti in holul unei case din care trebuie neaparat sa iesi."
                , $@"Esti in hol."
                , "usa de la hol."
            );

            ixBaie = AdaugaOptiune(
                $@"Esti in baie. Aprinzi lumina si vrei sa te speli pe fata.
Se arde becul si ai ramas in intuneric."
                , $@"Esti in baie si e bezna."
                , "usa de la baie"
            );
            
            ixDormitor = AdaugaOptiune(
                $@"Dormitorul arata sinistru."
                , $@"Esti in dormitor."
                , "usa de la dormitor."
            );

            ixSufragerie = AdaugaOptiune(
                $@"Sufrageria arata primitor, desi tu nu ai timp sa stai la TV."
                , $@"Esti in sufragerie."
                , "usa de la sufragerie."
            );

            ixBalcon = AdaugaOptiune(
                $@"Din balcon se vede afara. Esti la etajul 12."
                , $@"Esti in balcon."
                , "usa de la balcon"
            );

            ixAfara = AdaugaOptiune(
                null
                , null
                , "usa de intrare/iesire din apartament"
            );

            ixCheie = AdaugaOptiune(
                null
                , null
                , "ridica cheia"
            );

            listaDeOptiuniPentru[ixHol] = new List<int>(){ ixAfara, ixBaie, ixDormitor, ixSufragerie };
            listaDeOptiuniPentru[ixDormitor] = new List<int>(){ ixHol, ixBalcon };
            listaDeOptiuniPentru[ixSufragerie] = new List<int>(){ ixHol, ixBalcon };
            listaDeOptiuniPentru[ixBalcon] = new List<int>(){ ixDormitor, ixSufragerie, ixCheie };
        }

        static void Main(string[] args)
        {
            List<string> listaNume = new List<string>(){
                "Ion", "Maria", "George", "Ana"
            };

            foreach (string nume in listaNume)
            {
                System.Console.WriteLine(nume);
            }

            return;

            //functia facuta de noi
            ConfigureazaOptiuni();

            //in C# putem defini variabilele cu var si apoi sa le dam o valoare
            //si compilatorul "ghiceste" tipul variabilei la fel ca in js sau python
            //dar putem si sa le specificam direct tipul, cum ar fi string, bool, int, s.a.m.d.
            int pozitieCurenta = ixHol;
            bool areCheie = false;
            int raspunsUtilizator = IX_NEVALID;

            while(pozitieCurenta != ixAfara)
            {
                AfiseazaMesajCameraSiActualizeazaPrimaData(pozitieCurenta);
                raspunsUtilizator = oferaOptiuniSiPreiaRaspunsValid(listaDeOptiuniPentru[pozitieCurenta]);

                if(pozitieCurenta == ixHol && raspunsUtilizator == ixAfara)
                {
                    if(areCheie)
                    {
                        pozitieCurenta = ixAfara;
                    }
                    else
                    {
                        Console.WriteLine("Usa de intrare/iesire din apartament e incuiata si tu nu ai cheie...");
                        Console.WriteLine("Va trebui sa incerci altceva.");
                    }
                }
                else if(pozitieCurenta == ixBaie)
                {
                    Console.WriteLine($@"Nu ai nici o alta optiune decat sa te intorci in hol.");
                    pozitieCurenta = ixHol;
                }
                else if(raspunsUtilizator == ixCheie)
                {
                    Console.WriteLine("Ai luat cheia, acum poti deschide ceva.");
                    areCheie = true;
                    listaDeOptiuniPentru[ixBalcon].Remove(ixCheie);
                }
                else
                {
                    pozitieCurenta = raspunsUtilizator;
                }
            }

            Console.WriteLine("Ai reusit sa scapi din apartament, felicitari!");
        }
    }
}
