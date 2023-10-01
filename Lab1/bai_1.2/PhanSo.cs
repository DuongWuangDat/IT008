using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nPhanSo
{
    internal class PhanSo : IComparable<PhanSo>
    {
        private int tu;
        private int mau;

        public int Tu { get; set; }
        public int Mau { get; set; }

        // Chuyển từ string sang phân số
        public static PhanSo ConVertToPhanSo(string s)
        {
            PhanSo ps = new PhanSo();
            if (s.Contains('/'))
            {
                int tu, mau;
                string[] sps = s.Split('/');
                if (int.TryParse(sps[0], out tu) && int.TryParse(sps[1], out mau))
                {
                    ps = new PhanSo(tu, mau);
                    if (mau == 0)
                        throw new Exception("Phan so khong duoc co mau bang 0");
                }
                else
                    throw new Exception("Phan so khong hop le");
            }
            else
                ps = new PhanSo(int.Parse(s));
            return ps;
        }


        public override string ToString()
        {
            return this.tu + "/" + this.mau;
        }

        private int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Hàm rút gọn phân số
        public PhanSo RutGon()
        {
            int gcd = FindGCD(tu, mau);
            tu /= gcd;
            mau /= gcd;
            return this;
        }

        // Phương thức so sánh phân số
        public int CompareTo(PhanSo? other)
        {
            if (this > other)
                return 1;
            else if (this < other) 
                return -1;
            else 
                return 0;
        }

        public PhanSo(int a = 0, int b = 1)
        {
            tu = a;
            mau = b;
            this.RutGon();
        }



        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            PhanSo result = new()
            {
                tu = a.tu * b.mau + a.mau * b.tu,
                mau = a.mau * b.mau
            };
            result.RutGon();
            return result;
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            PhanSo result = new() { tu = a.tu * b.mau - a.mau * b.tu, mau = a.mau * b.mau };
            result.RutGon();
            return result;
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            PhanSo result = new() { tu = a.tu * b.tu, mau = a.mau * b.mau };
            result.RutGon();
            return result;
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            PhanSo result = new() { tu = a.tu * b.mau, mau = a.mau * b.tu };
            result.RutGon();
            return result;
        }

        public static bool operator ==(PhanSo a, PhanSo b)
        {
            return (a.tu == b.tu) && (a.mau == b.mau);
        }

        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        // Chuyển kiểu ngầm định từ số nguyên sang phân số
        public static implicit operator PhanSo(int a)
        {
            return new() { tu = a, mau = 1 };
        }

        // Chuyển kiểu tường minh từ phân số sang số thực
        public static explicit operator double(PhanSo a)
        {
            return (double)(a.tu / a.mau);
        }

        public static bool operator <(PhanSo a, PhanSo b)
        {
            return ((double)(a - b) < 0);
        }
        public static bool operator >(PhanSo a, PhanSo b)
        {
            return !(a < b);
        }

    }
}

