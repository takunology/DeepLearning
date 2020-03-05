using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace JpegToData
{
    class Program
    {
        static string FilePath = "";
        static float[,] JpegData = new float[0, 0];
        static int Width = 0;
        static int Height = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Get Brihtness.");

            GetData();
            WriteToFile();

            Console.WriteLine("Finish.");
#if DEBUG
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{JpegData[i, j]}"+"\t");
                }
                Console.WriteLine();
            }
#endif
        }

        static void GetData()
        {
            
            FilePath = "../../../training/0/zero01.jpg";
            Bitmap bitmap = new Bitmap(FilePath);

            Width = bitmap.Width;
            Height = bitmap.Height;

            JpegData = new float[Height, Width];

            for (int i = 0; i < Height; i++)
            {
                for(int j = 0; j < Width; j++)
                {
                    Color pixel = bitmap.GetPixel(i, j); //[i, j]の色情報にアクセス
                    JpegData[i, j] = pixel.GetBrightness();
                }
            }
        }

        static void WriteToFile()
        {
            Encoding encode = Encoding.GetEncoding("utf-8");
            FilePath = "../../../data/0/0.txt";
            Directory.CreateDirectory("../../../data/0");

            StreamWriter streamWriter = new StreamWriter(FilePath, false, encode);

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    streamWriter.Write($"{JpegData[i, j]},");
                }
            }
        }
    }
}
