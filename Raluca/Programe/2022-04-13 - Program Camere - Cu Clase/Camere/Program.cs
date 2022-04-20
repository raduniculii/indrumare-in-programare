using System;
using System.Collections.Generic;
using System.Linq;

namespace Camere
{
    class Program
    {
        static void Main(string[] args)
        {
            var AreCheie = false;

            Camera CameraCurenta = null, Baie = null, Hol = null, Dormitor = null, Balcon = null, Sufragerie = null;
         

             Sufragerie = new Camera(){
                Mesaj = "Esti in sufragerie. Totul arata foarte straniu. Televizotul este pornit si se vede pe el fata din The Ring",
                Mesaj2 = "Esti in sufragerie. ",
                Optiuni = new Dictionary<string, Action>() {
                
                     {"Mergi in hol", () => {
                        CameraCurenta = Hol;
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
                        if (AreCheie){
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
                        AreCheie = true;
                        System.Console.WriteLine("Bravo, ai gasit cheia");
                        Balcon.Optiuni.Remove("Ridica cheia");
                    }}
                } 
            }; 

            CameraCurenta = Hol;

            var UsaIesire = new Usa()
            {
                EIncuiata = true,
                CameraA = Hol,
                CameraB = null
            };


            var UsaBaie = new Usa() {
                CameraA = Hol,
                CameraB = Baie
            };

            var UsaBalconDormitor = new Usa(){
                CameraA = Balcon,
                CameraB = Dormitor
            };


            var UsaBalconSufragerie = new Usa(){
                CameraA = Balcon,
                CameraB = Sufragerie
            };
            
            var UsaDormitorHol = new Usa(){
                CameraA = Hol,
                CameraB = Dormitor
            };

            var UsaSufragerieHol = new Usa(){
                CameraA = Hol,
                CameraB = Sufragerie
            };

            string RaspunsulUtilizatorului = "";

            int Raspuns = 0;

            while (CameraCurenta != null)
            {
                // Afisam optiunile si una dintre optiuni trebuie sa fie iesirea
                Console.WriteLine(CameraCurenta.Mesaj);
                Console.WriteLine("Ai urmatoarele optiuni, ce alegi?");
                int i = 1;
                foreach (var item in CameraCurenta.Optiuni)
                {
                    Console.WriteLine(i.ToString() + " " + item.Key);
                    i+=1;
                }
                Console.WriteLine($"{i} Iesi din Joc");
                RaspunsulUtilizatorului = Console.ReadLine();
                while ( !(int.TryParse(RaspunsulUtilizatorului, out Raspuns) && Raspuns >=1 && Raspuns <= i) )
                {
                    Console.WriteLine($"Alege un numar intre 1 si {i}");
                    RaspunsulUtilizatorului = Console.ReadLine();

                }
                Raspuns = int.Parse(RaspunsulUtilizatorului);
                if (Raspuns == i) break;

                CameraCurenta.Optiuni.ElementAt(Raspuns - 1).Value();
            }

            


            }
    }
}
