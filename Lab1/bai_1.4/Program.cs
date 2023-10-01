using System;

namespace Program
{
    public delegate void UpdateNhietKeHandler(double temp);
    public class main
    {
        public static void Main(string[] args)
        {
            NhietKe temp = new NhietKe();
            Random rnd = new Random();
            temp.UpdateNhietKe += Temp_UpdateNhietKe;
            for(int i=0; i< 10; i++)
            {
                temp.nhietKe = Math.Round((rnd.NextDouble() + rnd.Next(-80, 80)), 2);
            }
        }

        private static void Temp_UpdateNhietKe(double temp)
        {
            Console.WriteLine("Nhiet do moi la: " +  temp);
        }
    }
    public class NhietKe
    {
        public event UpdateNhietKeHandler UpdateNhietKe;
        private double _nhietKe;

        public double nhietKe
        {
            get { return _nhietKe; }
            set { 
                _nhietKe = value;
                UpdateNhietKe(nhietKe);
            }
        }

    }
}
