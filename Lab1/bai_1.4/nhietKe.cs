using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhietKe
{
    public class nhietKe
    {
		public double NhietDo
		{
			get { 
				Random random = new Random();
				return random.NextDouble() + random.Next(-80,80); 
			}
		}
		public void displayNhietDo()
		{
			Console.WriteLine("Nhiet do trong ngay la: " + Math.Round(NhietDo,2));
		}

	}
}
