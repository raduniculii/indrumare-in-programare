using System;
using System.Collections.Generic;
using System.Linq;

namespace Camere
{
    class Program
    {
        static void Main(string[] args)
        {
            var AreCheieBucatarie = false;
            var AreCheieIesire = false;

            Camera CameraCurenta = null, Baie = null, Hol = null, Dormitor = null, Balcon = null, Sufragerie = null, Bucatarie = null;
         

            Sufragerie = new Camera(){
                Mesaj = "Esti in sufragerie. Totul arata foarte straniu. Televizotul este pornit si se vede pe el fata din The Ring",
                Mesaj2 = "Esti in sufragerie. ",
                Optiuni = new Dictionary<string, Action>() {
                
                     {"Mergi in hol", () => {
                        CameraCurenta = Hol;
                    }},
                    {"Mergi in bucatarie", () => {
                        if (AreCheieBucatarie){
                            CameraCurenta = Bucatarie;
                        }
                        else {
                            System.Console.WriteLine("E incuiata bucataria si nu ai cheia!");
                        }
                    }},

                     {"Mergi in balcon", () => {
                        CameraCurenta = Balcon;
                    
                    }}
                } 
            };

            Hol = new Camera(){
                Mesaj = "Esti in Hol. Vrei sa iesi afara din casa.",
                Mesaj2 = "Esti in hol.",
                Optiuni = new Dictionary<string, Action>() {
                    {"Deschide usa de iesire", () => {
                        System.Console.WriteLine("Incerci sa deschizi usa");
                        if (AreCheieIesire){
                          System.Console.WriteLine("Esti liber, poti iesi");  
                          CameraCurenta = null;
                        }
                        else {
                            System.Console.WriteLine("E incuiat, tzapa!");
                        }
                    }},
                     {"Mergi in baie", () => {
                        CameraCurenta = Baie;
                    }},
                     {"Mergi in dormitor", () => {
                        CameraCurenta = Dormitor;
                    }},
                     {"Mergi in sufragerie", () => {
                        CameraCurenta = Sufragerie;
                    
                    }}

                    
                } 
            }; 

            Dormitor = new Camera(){
                Mesaj = "Esti in Dormitor. Patul este nefacut si sunt urme de sange pe podea",
                Mesaj2 = "Esti in Dormitor." ,
                Optiuni = new Dictionary<string, Action>() {
                
                     {"Mergi in hol", () => {
                        CameraCurenta = Hol;
                    }},
                     {"Mergi in balcon", () => {
                        CameraCurenta = Balcon;
                    
                    }}
                } 
            }; 

            Baie = new Camera(){
                Mesaj = "Esti in Baie. Becul este stins si nu vezi nimic",
                Mesaj2 = "Esti in Baie. Becul este ars. Iesi afara ca nu vezi nimic." ,
                Optiuni = new Dictionary<string, Action>() {
                
                     {"Iesi inapoi in hol", () => {
                        CameraCurenta = Hol;
                    }}
                } 
            }; 
            
            Balcon = new Camera(){
                Mesaj = "Esti in Balcon. Vrei sa te uiti pe geam dar nu vezi nimic ",
                Mesaj2 = "Esti in Balcon." ,
                Optiuni = new Dictionary<string, Action>() {
                
                     {"Mergi in dormitor", () => {
                        CameraCurenta = Dormitor;
                    }},
                     {"Mergi in sufragerie", () => {
                        CameraCurenta = Sufragerie;
                    
                    }},
                    
                     {"Ridica cheia", () => {
                        AreCheieBucatarie = true;
                        System.Console.WriteLine("Bravo, ai gasit cheia");
                        Balcon.Optiuni.Remove("Ridica cheia");
                    }}
                } 
            }; 

            Bucatarie = new Camera(){
                Mesaj = "Esti in Bucatarie. Vasele sunt nespalate dar asta nu e problema ta acum ",
                Mesaj2 = "Esti in Bucatarie din nou." ,
                Optiuni = new Dictionary<string, Action>() {
                
                    {"Mergi in sufragerie", () => {
                        CameraCurenta = Sufragerie;
                    
                    }},
                    
                     {"Ridica cheia", () => {
                        AreCheieIesire = true;
                        System.Console.WriteLine("Bravo, ai gasit cheia de iesire");
                        Bucatarie.Optiuni.Remove("Ridica cheia");
                    }}
                } 
            };  

            CameraCurenta = Hol;

            var UsaIesire = new Usa(Hol, null)
            {
                EIncuiata = true,
            };


            var UsaBaie = new Usa(Hol, Baie);

            var UsaBalconDormitor = new Usa(Balcon, Dormitor);


            var UsaBalconSufragerie = new Usa(Balcon, Sufragerie);
            
            var UsaDormitorHol = new Usa(Hol, Dormitor);

            var UsaSufragerieHol = new Usa(Hol, Sufragerie);

            string RaspunsulUtilizatorului = "";

            int Raspuns = 0;

            while (CameraCurenta != null)
            {
                // Afisam optiunile si una dintre optiuni trebuie sa fie iesirea
                Console.ForegroundColor = ConsoleColor.Green;
                if (!CameraCurenta.AFostVizitata)
                {
                    Console.WriteLine(CameraCurenta.Mesaj);
                    CameraCurenta.AFostVizitata = true;
                }
                else
                {
                    Console.WriteLine(CameraCurenta.Mesaj2);
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Ai urmatoarele optiuni, ce alegi?");
                Console.ForegroundColor = ConsoleColor.Gray;
                int i = 1;
                foreach (var item in CameraCurenta.Optiuni)
                {
                    Console.WriteLine(i.ToString() + " " + item.Key);
                    i+=1;
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Q Iesi din Joc");
                Console.ForegroundColor = ConsoleColor.Gray;
                RaspunsulUtilizatorului = Console.ReadLine();
                while ( RaspunsulUtilizatorului.ToUpper() != "Q" && !(int.TryParse(RaspunsulUtilizatorului, out Raspuns) && Raspuns >=1 && Raspuns < i) )
                {
                    Console.WriteLine($"Alege un numar intre 1 si {i-1} sau poti iesi din joc cu tasta q");
                    RaspunsulUtilizatorului = Console.ReadLine();
                    Console.Clear();
                }
                if (RaspunsulUtilizatorului.ToUpper() == "Q") break;

                CameraCurenta.Optiuni.ElementAt(Raspuns - 1).Value();
                Console.Clear();
            }

            


            }
    }
}
