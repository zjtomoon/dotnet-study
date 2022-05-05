// See https://aka.ms/new-console-template for more information

using System;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace cv_example
{
    class hello
    {
        public static void Main(string[] args)
        {
            Mat image = CvInvoke.Imread(@"D:\\images\\1.jpg");
            if (image.IsEmpty)
            {
                Console.WriteLine("文件图片找不到");
                return;
            }
            
            Console.WriteLine($"图像宽度为：{image.Cols}");//获取图片的列
            Console.WriteLine($"图像高度为：{image.Rows}");//获取图片的行
            Console.WriteLine($"图像通道数为：{image.NumberOfChannels}");//获取图片通道数
            
            CvInvoke.NamedWindow("test",NamedWindowType.AutoSize);
            CvInvoke.Imshow("test",image);
            CvInvoke.CvtColor(image,image,ColorConversion.Bgr2Gray);
            
            CvInvoke.Imshow("outImage",image);
            CvInvoke.WaitKey(0);
            CvInvoke.DestroyWindow("test");
            CvInvoke.DestroyAllWindows();
        }
    }

}
