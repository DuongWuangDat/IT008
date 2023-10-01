using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class PhanSo
{
    private int tu;
    private int mau;

    public int Tu { get; set; }
    public int Mau { get; set; }

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
    public void RutGon()
    {
        int gcd = FindGCD(tu, mau);
        tu /= gcd;
        mau /= gcd;
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
}