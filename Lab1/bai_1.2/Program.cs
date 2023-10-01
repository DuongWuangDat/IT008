using System;
using nPhanSo;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Console.Write("Nhap phep tinh (vd: 1/2 + 1/2): ");
                string input = Console.ReadLine();
                string[] phepTinh = input.Split(' ');
                PhanSo a = PhanSo.ConVertToPhanSo(phepTinh[0]);
                PhanSo b = PhanSo.ConVertToPhanSo(phepTinh[2]);
                string printedString;
                switch (phepTinh[1])
                {
                    case "+":
                        printedString = (a + b).ToString();
                        break;
                    case "-":
                        printedString = (a - b).ToString();
                        break;
                    case "*":
                        printedString = (a * b).ToString();
                        break;
                    case "/":
                        printedString = (a / b).ToString();
                        break;
                    case "==":
                        if (a == b)
                            printedString = "Dung";
                        else
                            printedString = "Sai";
                        break;
                    case "!=":
                        if (a != b)
                            printedString = "Dung";
                        else
                            printedString = "Sai";
                        break;
                    case "<":
                        if (a < b)
                            printedString = "Dung";
                        else
                            printedString = "Sai";
                        break;
                    case ">":
                        if (a > b)
                            printedString = "Dung";
                        else
                            printedString = "Sai";
                        break;
                    default:
                        printedString = "Toan tu ban nhap vao khong dung!";
                        break;
                }
                Console.WriteLine(printedString + "\n\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Test Array.Sort();
            finally
            {
                PhanSo[] mangPhanSo = new PhanSo[]
                {
                    new PhanSo(1,2),
                    new PhanSo(3,2),
                    new PhanSo(5,3),
                    new PhanSo(6,11),
                    new PhanSo(4,5),
                };
                Console.WriteLine("Mang ban dau: ");
                foreach (var phanSo in mangPhanSo)
                {
                    Console.WriteLine(phanSo.ToString());
                }

                Array.Sort(mangPhanSo);

                Console.WriteLine("Mang da sap xep: ");
                foreach (var phanSo in mangPhanSo)
                {
                    Console.WriteLine(phanSo.ToString());
                }
            }
        }
    }
}