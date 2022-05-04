namespace Camere
{
    class Usa
    {
        public bool EIncuiata { get; set; }

        public Camera CameraA { get; set; }

        public Camera CameraB { get; set; }

        public Usa (Camera CameraA, Camera CameraB)
        {
            this.CameraA = CameraA;
            this.CameraB = CameraB;
        }


    }

}
