using System;

namespace Camere
{
    class Program
    {
        static void Main(string[] args)
        {
            var Sufragerie = new Camera(){
                Mesaj = "Esti in sufragerie. Totul arata foarte straniu. Televizotul este pornit si se vede pe el fata din The Ring",
                Mesaj2 = "Esti in sufragerie. "
            };

            var Hol = new Camera(){
                Mesaj = "Esti in Hol. Vrei sa iesi afara din casa.",
                Mesaj2 = "Esti in hol." 
            }; 

            var Dormitor = new Camera(){
                Mesaj = "Esti in Dormitor. Patul este nefacut si sunt urme de sange pe podea",
                Mesaj2 = "Esti in Dormitor." 
            }; 

            var Baie = new Camera(){
                Mesaj = "Esti in Baie. Becul este stins si nu vezi nimic",
                Mesaj2 = "Esti in Baie. Becul este ars. Iesi afara ca nu vezi nimic." 
            }; 
            
            var Balcon = new Camera(){
                Mesaj = "Esti in Balcon. Vrei sa te uiti pe geam dar nu vezi nimic ",
                Mesaj2 = "Esti in Balcon." 
            }; 

            var CameraCurenta = Hol;

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

            Console.WriteLine(CameraCurenta.Mesaj);


            }
    }
}
