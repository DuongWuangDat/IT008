using System;

namespace Program
{
    public class main
    {
        public static void Main(string[] args)
        {
            NhietKe temp = new NhietKe();
            Random rnd = new Random();
            temp.NhietKeChanged += Temp_NhietKeChanged;
            for(int i=0; i< 10; i++)
            {
                temp.nhietKe = Math.Round((rnd.NextDouble() + rnd.Next(-80, 80)), 2);
            }
        }

        private static void Temp_NhietKeChanged(object? sender, NhietKeChangedArgs e)
        {
            Console.WriteLine("Nhiet do moi la: " + e.nhietDo);
        }
    }
    public class NhietKe
    {
        private double _nhietKe;

        public double nhietKe
        {
            get { return _nhietKe; }
            set { 
                _nhietKe = value;
                OnNhietKeChange(value);
            }
        }
        private event EventHandler<NhietKeChangedArgs> _nhietKeChanged;
        public event EventHandler<NhietKeChangedArgs> NhietKeChanged
        {
            add { _nhietKeChanged += value;}
            remove { _nhietKeChanged -= value;}
        }
        void OnNhietKeChange(double nhietKe)
        {
            if(_nhietKeChanged != null)
            {
                _nhietKeChanged(this, new NhietKeChangedArgs(nhietKe));
            }
        }
    }
    public class NhietKeChangedArgs : EventArgs
    {
        public double nhietDo { get; set; }
        public NhietKeChangedArgs(double nhietDo)
        {
            this.nhietDo = nhietDo; 
        }
    }
}
