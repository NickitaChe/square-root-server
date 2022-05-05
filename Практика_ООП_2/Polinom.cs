using System;


namespace Polinom
{
    using Number;
    public class Полином
    {
        Number a, b, c, x1, x2;
        bool Indikator1 = true, Indikator2 = true;
        public void SetAssignment(Number Curr1, Number Curr2, Number Curr3)
        {
            this.a = Curr1;
            this.b = Curr2;
            this.c = Curr3;
        }
        public string Xresult()
        {
            Number Zero = a - a;

            Number D = b * b - 4 * a * c;

            switch (D.checkSqrt())
            {
                case 0:

                    Indikator1 = false;
                    Indikator2 = false;
                    return "Корня не существует в данном множестве";

                case 1:
                    try
                    {
                        var X1 = (-1 * b + D.Sqrt()) / (2 * a);
                        if (CastomPolinom(X1) == Zero)
                        {
                            this.x1 = X1;
                            this.x2 = X1;
                            return "X1= " + X1.ToString();
                        }
                        else
                        {
                            Indikator1 = false;
                            Indikator2 = false;
                            return "Ошибка! Корня не существует в данном множестве";

                        }
                    }
                    catch (SystemException error)
                    {
                        return "Ошибка! Введиите новые коэффициенты" + error.ToString();
                    }

                case 2:
                    Number X2, X3;
                    try
                    {
                        X2 = (-1 * b + D.Sqrt()) / (2 * a);
                        X3 = (-1 * b - D.Sqrt()) / (2 * a);


                        if (CastomPolinom(X2) == Zero && CastomPolinom(X3) == Zero)
                        {

                            this.x1 = X2;
                            this.x2 = X3;
                            return "X1= " + X2.ToString() + "   X2= " + X3.ToString();
                        }
                        else
                        {
                            if (CastomPolinom(X2) != Zero && CastomPolinom(X3) == Zero)
                            {

                                this.x1 = X3;
                                this.x2 = X3;
                                Indikator1 = false;
                                return "X1= " + X3.ToString();
                            }
                            else
                            {
                                if (CastomPolinom(X2) == Zero && CastomPolinom(X3) != Zero)
                                {

                                    this.x1 = X2;
                                    this.x2 = X2;
                                    Indikator2 = false;
                                    return "X1= " + X2.ToString();

                                }
                                else
                                {
                                    Indikator1 = false;
                                    Indikator2 = false;
                                    return "Ошибка! Нет действительных корней для данного множества";
                                }
                            }
                        }
                    }
                    catch (SystemException error)
                    {
                        return "Ошибка! Введиите новые коэффициенты" + error.ToString();
                    }
                default:
                    return "Ошибка! Введиите новые коэффициенты";
            }
        }
        public Number CastomPolinom(Number X)
        {
            Number CastomPolinom = this.a * X * X + this.b * X + this.c;
            return CastomPolinom;
        }
        public string ClassicPolinom()
        {
            if (a == a - a && b == b - b && c == c - c)
                return ("0");
            if (b > b - b && c > c - c)
                return (a + "x^2 + " + b + "x + " + c + "=0");
            if (b < b - b && c > c - c)
                return (a + "x^2" + b + "x + " + c + "=0");
            if (b > b - b && c < c - c)
                return (a + "x^2 + " + b + "x " + c + "=0");
            if (b < b - b && c < c - c)
                return (a + "x^2" + b + "x " + c + "=0");
            return "Ошибка!";
        }
        public string CanonPolinom()
        {
            // Console.WriteLine("Канонический вид:");


            Number Zero;

            Zero = a - a;



            if (Indikator1 && Indikator2)
            {

                if (x1 != x2)
                {
                    if (x1 > Zero && x2 > Zero)
                        return (a + "(x - " + x1 + ")(x - " + x2 + ")" + "=0");
                    if (x1 < Zero && x2 > Zero)
                        return (a + "(x + " + x1.Abs() + ")(x - " + x2 + ")" + "=0");
                    if (x1 > Zero && x2 < Zero)
                        return (a + "(x - " + x1 + ")(x + " + x2.Abs() + ")" + "=0");
                    if (x1 < Zero && x2 < Zero)
                        return (a + "(x + " + x1.Abs() + ")(x + " + x2.Abs() + ")" + "=0");
                }
                else
                {

                    if (x1 > Zero)
                        return (a + "( x - " + x1 + ")^2" + "=0");
                    else
                    {
                        if (x1 < Zero)
                            return (a + "(x + " + x1.Abs() + ")^2" + "=0");

                    }
                }
            }
            else if (!Indikator1 || !Indikator2)
                return ("Корней не существует в данном множестве");

            return "Ошибка!";
        }
    }
}
