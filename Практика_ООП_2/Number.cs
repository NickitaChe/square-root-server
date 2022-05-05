using System;


namespace Number
{
    public class Number
    {
        /*
         * Указания к дополнению Класса
         * Шаг 1. Добавить переменную, используя следующую букву латинского языка
         * Шаг 2. Реализовать инициализацию
         * Шаг 3. Реализовать вывод
         * Шаг 4. реализовать основные 
         * Шаг 5. добавиьт в дубликейт
        */

        //Хронение
        int a = 0;
        double b = 0;
        string type = "None";
        int c1 = 0, c2 = 1;
        //Инициализация
        public Number()
        {
            a = 0;
            b = 0;
            c1 = 0; c2 = 1;
            type = "None";
        }
        public Number(int num)
        {
            a = (int)num;
            type = "int";
        }
        public Number(double num)
        {
            b = num;
            type = "double";
        }

        public Number(string numtype, string num)
        {
            switch (numtype)
            {
                case "int":
                    Dublicate(new Number(Convert.ToInt32(num)));
                    return;
                case "double":
                    Dublicate(new Number(Convert.ToDouble(num)));
                    return;
                case "real":
                    string[] temp = num.Split('/');
                    Dublicate(new Number(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1])));
                    return;
            }
            throw new SystemException("BadType");
        }

        public Number(int num1, int num2)
        {
            if (num2 == 0)
            {
                throw new SystemException("BadNumerator");
            }
            c1 = num1;
            c2 = num2;
            type = "real";
            Reduction();
        }
        //Вывод
        override public string ToString()
        {
            string temp = "0";
            switch (type)
            {
                case "int":
                    return temp = a.ToString();
                case "double":
                    return temp = b.ToString();
                case "real":
                    temp = c1.ToString() + "/" + c2.ToString();
                    return temp;
            }
            return temp;
        }

        //Операторы для двух чисел
        public static Number operator *(Number A, Number B)
        {
            Number temp = new Number();
            temp.type = A.type;
            if (A.type == B.type)
            {
                switch (A.type)
                {
                    case "int":
                        temp.a = A.a * B.a;
                        return temp;
                    case "double":
                        temp.b = A.b * B.b;
                        return temp;
                    case "real":
                        temp.c1 = A.c1 * B.c1;
                        temp.c2 = A.c2 * B.c2;
                        temp.Reduction();
                        return temp;
                }
            }
            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator +(Number A, Number B)
        {
            Number temp = new Number();
            temp.type = A.type;
            if (A.type == B.type)
            {
                switch (A.type)
                {
                    case "int":
                        temp.a = A.a + B.a;
                        return temp;
                    case "double":
                        temp.b = A.b + B.b;
                        return temp;
                    case "real":
                        //временные дроби
                        int a1 = A.c1, a2 = A.c2, b1 = B.c1, b2 = B.c2;
                        a1 *= b2;
                        b1 *= a2;

                        temp.c1 = a1 + b1;
                        temp.c2 = (A.c2 * B.c2);


                        temp.Reduction();
                        return temp;
                }
            }
            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator -(Number A, Number B)
        {
            Number temp = new Number();
            temp.type = A.type;
            if (A.type == B.type)
            {
                switch (A.type)
                {
                    case "int":
                        temp.a = A.a - B.a;
                        return temp;
                    case "double":
                        temp.b = A.b - B.b;
                        return temp;
                    case "real":
                        //временные дроби
                        int a1 = A.c1, a2 = A.c2, b1 = B.c1, b2 = B.c2;
                        a1 *= b2;
                        b1 *= a2;

                        temp.c1 = a1 - b1;
                        temp.c2 = (A.c2 * B.c2);


                        temp.Reduction();
                        return temp;
                }
            }
            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator /(Number A, Number B)
        {
            Number temp = new Number();
            temp.type = A.type;
            if (A.type == B.type)
            {
                switch (A.type)
                {
                    case "int":
                        if (B.a == 0)
                        {
                            throw new SystemException("ZeroDivision");
                        }
                        temp.a = A.a / B.a;
                        return temp;
                    case "double":
                        if (B.b == 0)
                        {
                            throw new SystemException("ZeroDivision");
                        }
                        temp.b = A.b / B.b;
                        return temp;
                    case "real":

                        if (B.c1 == 0)
                        {
                            throw new SystemException("ZeroDivision");
                        }

                        temp.c1 = A.c1 * B.c2;
                        temp.c2 = A.c2 * B.c1;
                        temp.Reduction();
                        return temp;
                }
            }
            throw new SystemException("BadType");
            return temp;
        }


        public static Number operator *(Number A, int B)
        {
            Number temp = new Number();
            temp.type = A.type;

            switch (A.type)
            {
                case "int":
                    temp.a = A.a * B;
                    return temp;
                case "double":
                    temp.b = A.b * B;
                    return temp;
                case "real":
                    temp.c1 = A.c1 * B;
                    temp.c2 = A.c2;
                    temp.Reduction();
                    return temp;
            }

            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator *(int B, Number A)
        {
            switch (A.type)
            {
                case "int":
                    return new Number(B) * A;
                case "double":
                    return new Number((double)B) * A;
                case "real":
                    return new Number(B, 1) * A;
            }

            throw new SystemException("BadType");


        }
        public static Number operator +(Number A, int B)
        {
            Number temp = new Number();
            temp.type = A.type;

            switch (A.type)
            {
                case "int":
                    temp.a = A.a + B;
                    return temp;
                case "double":
                    temp.b = A.b + B;
                    return temp;
                case "real":
                    temp.c1 = A.c1 + B * A.c2;
                    temp.c2 = A.c2;
                    temp.Reduction();
                    return temp;
            }

            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator +(int B, Number A)
        {
            switch (A.type)
            {
                case "int":
                    return new Number(B) + A;
                case "double":
                    return new Number((double)B) + A;
                case "real":
                    return new Number(B, 1) + A;
            }

            throw new SystemException("BadType");

        }
        public static Number operator -(Number A, int B)
        {
            Number temp = new Number();
            temp.type = A.type;

            switch (A.type)
            {
                case "int":
                    temp.a = A.a - B;
                    return temp;
                case "double":
                    temp.b = A.b - B;
                    return temp;
                case "real":
                    temp.c1 = A.c1 - B * A.c2;
                    temp.c2 = A.c2;
                    temp.Reduction();
                    return temp;
            }

            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator -(int B, Number A)
        {
            switch (A.type)
            {
                case "int":
                    return new Number(B) - A;
                case "double":
                    return new Number((double)B) - A;
                case "real":
                    return new Number(B, 1) - A;
            }

            throw new SystemException("BadType");

        }
        public static Number operator /(Number A, int B)
        {
            Number temp = new Number();
            temp.type = A.type;
            if (B == 0) throw new SystemException("BadInt");

            switch (A.type)
            {
                case "int":
                    temp.a = A.a / B;
                    return temp;
                case "double":
                    temp.b = A.b / B;
                    return temp;
                case "real":
                    temp.c1 = A.c1 / B;
                    temp.c2 = A.c2;
                    temp.Reduction();
                    return temp;
            }

            throw new SystemException("BadType");
            return temp;
        }
        public static Number operator /(int B, Number A)
        {
            switch (A.type)
            {
                case "int":
                    return new Number(B) / A;
                case "double":
                    return new Number((double)B) / A;
                case "real":
                    return new Number(B, 1) / A;
            }

            throw new SystemException("BadType");

        }


        //Логические операторы
        public static bool operator ==(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a == B.a;
                case "double":
                    return A.b == B.b;
                case "real":

                    return A.c1 * B.c2 == B.c1 * A.c2;
            }

            throw new SystemException("BadType");

        }
        public static bool operator !=(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a != B.a;
                case "double":
                    return A.b != B.b;
                case "real":
                    return A.c1 * B.c2 != B.c1 * A.c2;
            }

            throw new SystemException("BadType");
        }
        public static bool operator >(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a > B.a;
                case "double":
                    return A.b > B.b;
                case "real":
                    return A.c1 * B.c2 > B.c1 * A.c2;
            }

            throw new SystemException("BadType");
        }
        public static bool operator <(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a < B.a;
                case "double":
                    return A.b < B.b;
                case "real":
                    return A.c1 *B.c2 < B.c1 * A.c2;
            }

            throw new SystemException("BadType");
        }
        public static bool operator >=(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a >= B.a;
                case "double":
                    return A.b >= B.b;
                case "real":
                    return A.c1 * B.c2 >= B.c1 * A.c2;
            }

            throw new SystemException("BadType");
        }
        public static bool operator <=(Number A, Number B)
        {
            switch (A.type)
            {
                case "int":
                    return A.a <= B.a;
                case "double":
                    return A.b <= B.b;
                case "real":
                    return A.c1 * B.c2 <= B.c1 * A.c2;
            }

            throw new SystemException("BadType");
        }

        //Математические операции
        public double Pow(int Power)
        {
            double temp = 0;
            switch (type)
            {
                case "int":
                    temp = Math.Pow((double)a, (double)Power);
                    return temp;
                case "double":
                    temp = Math.Pow((double)b, (double)Power);
                    return temp;
                case "real":
                    temp = Math.Pow((double)c1, (double)Power) / Math.Pow((double)c2, (double)Power); ;
                    return temp;
            }
            throw new SystemException("BadType");
        }
        public Number Abs()
        {
            Number temp = new Number();
            temp.Dublicate(this);
            switch (type)
            {
                case "int":
                    temp.a = (int)Math.Abs(a);
                    return temp;
                case "double":
                    temp.b = (double)Math.Abs(b);
                    return temp;
                case "real":
                    temp.c1 = (int)Math.Abs(c1);
                    temp.c2 = (int)Math.Abs(c2);

                    return temp;
            }
            throw new SystemException("BadType");
        }
        public Number Sqrt()
        {
            double temp = 0;

            switch (this.type)
            {
                case "int":
                    temp = Math.Sqrt(a);
                    return new Number((int)temp);
                case "double":
                    temp = Math.Sqrt(b);
                    return new Number(temp);
                case "real":
                    //временные дроби
                    temp = Math.Sqrt(c1) / Math.Sqrt(c2);
                    return new Number((int)temp * 100, 100);
            }

            throw new SystemException("BadType");
        }
        void Dublicate(Number A)
        {
            a = A.a;
            b = A.b;
            c1 = A.c1;
            c2 = A.c2;
            type = A.type;
            return;
        }
        int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
        int Reduction()
        {
            int gcd =GCD(c1, c2);
            if (gcd != 0)
            {
                c1 /= gcd;
                c2 /= gcd;
            }
            if (c2 != 0 && c1 != 0) return c2;
            return 0;
        }
        public int checkSqrt()
        {
            switch (this.type)
            {
                case "int":
                    if (a == 0)
                    {
                        return 1;
                    }
                    else if (a > 0)
                        return 2;
                    return 0;
                case "double":
                    if (b == 0)
                    {
                        return 1;
                    }
                    else if (b > 0)
                        return 2;
                    return 0;
                case "real":
                    if (c1 == 0)
                    {
                        return 1;
                    }
                    else if (c1 / c2 > 0)
                        return 2;
                    return 0;
            }

            throw new SystemException("BadType");
        }
    }
}
