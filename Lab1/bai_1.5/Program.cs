using System;
using System.IO;
namespace Program
{
    public class main
    {
        public static void Main(string[] args)
        {
            Console.Write("Nhap duong dan thu muc: ");
            string path= Console.ReadLine();
           
            DirectoryInfo directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                Console.WriteLine("Thu muc khong ton tai");
                return;
            }
            foreach (FileInfo file in directory.GetFiles())
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
