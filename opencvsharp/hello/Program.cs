// See https://aka.ms/new-console-template for more information
using OpenCvSharp;

namespace opencv4test
{
    class hello
    {
        static void Main(string[] args) {
            Mat image = new Mat("D:\\images\\1.jpg", ImreadModes.Grayscale);
            Cv2.ImShow("demo", image);
            Cv2.WaitKey(0);
        }
    }   
}