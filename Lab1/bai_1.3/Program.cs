using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
namespace BT
{
    class lon_nho
    {
        public static void max(int[] a = null, double[] b = null, string[] c = null)
        {


            if (a != null)
            {
                int kt = a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] > kt)
                    {
                        kt = a[i];
                    }
                }
                Console.WriteLine("số nguyên lớn nhất trong dãy số nguyên là " + kt);
            }
            if (b != null)
            {
                double kt = b[0];
                for (int i = 1; i < b.Length; i++)
                {
                    if (b[i] > kt)
                    {
                        kt = b[i];
                    }
                }
                Console.WriteLine("số thực lớn nhất trong dãy số thực là " + kt);
            }
            if (c != null)
            {
                int kt = c[0].Length;
                string s = c[0];
                for (int i = 1; i < c.Length; i++)
                {
                    if (c[i].Length > kt)
                    {
                        kt = c[i].Length;
                        s = c[i];
                    }
                }
                Console.WriteLine("chuỗi dài nhất trong các chuỗi là: " + s);
            }
        }
        public static void min(int[] a = null, double[] b = null, string[] c = null)
        {


            if (a != null)
            {
                int kt = a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    if (a[i] < kt)
                    {
                        kt = a[i];
                    }
                }
                Console.WriteLine("số nguyên nhỏ nhất trong dãy số nguyên là " + kt);
            }
            if (b != null)
            {
                double kt = b[0];
                for (int i = 1; i < b.Length; i++)
                {
                    if (b[i] < kt)
                    {
                        kt = b[i];
                    }
                }
                Console.WriteLine("số thực nhỏ nhất trong dãy số thực là " + kt);
            }
            if (c != null)
            {
                int kt = c[0].Length;
                string s = c[0];
                for (int i = 1; i < c.Length; i++)
                {
                    if (c[i].Length < kt)
                    {
                        kt = c[i].Length;
                        s = c[i];
                    }
                }
                Console.WriteLine("chuỗi ngắn nhất trong các chuỗi là: " + s);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int[] a = { 1, 2, 3, 4, 5 };
            double[] b = { 1.2, 2.2, 3.2, 4.2 };
            string[] c = { "a", "ab", "abc", "abcd", "abcde" };
            max(a, null, null);
            max(null, b, null);
            max(null, null, c);
            min(a, null, null);
            min(null, b, null);
            min(null, null, c);

        }
    }
}
