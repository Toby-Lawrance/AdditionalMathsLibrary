using System;
using TobyNumbers;

namespace FractionTesting
{
    class Program
    {
        static bool Assert<T>(T a, T b)
        {
            if(!a.Equals(b))
            {
                throw new Exception($"Assertion failed: {a} != {b}");
            }
            Console.WriteLine($"{a} == {b}");
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Fraction tests:");
            Fraction f1 = new Fraction(1,2);
            Fraction f2 = new Fraction(1.0 / 2.0);
            Fraction f3 = new Fraction(0.5M);
            Fraction f4 = new Fraction(0.25);
            Fraction f5 = new Fraction(1, 3);
            Fraction f6 = new Fraction(-1, 7);
            Fraction f7 = new Fraction(-0.2);

            if(!(f1 == f2 && f1 == f3 && f2 == f3))
            {
                Console.WriteLine("type checking failed");
            }

            Assert<string>(f1.ToString(), "1/2");
            Assert<string>(f2.ToString(), "1/2");
            Assert<string>(f3.ToString(), "1/2");
            Assert<string>(f4.ToString(), "1/4");
            Assert<string>(f5.ToString(), "1/3");
            Assert<string>(f6.ToString(), "-1/7");
            Assert<string>(f7.ToString(), "-1/5");

            Assert<string>((f1 + f2).ToString(), "1/1");
            Assert<string>((f1 - f2).ToString(), "0/1");
            Assert<string>((f1 * f2).ToString(), "1/4");
            Assert<string>((f1 / f2).ToString(), "1/1");

            Assert<bool>((f1 < 1), true);
            Assert<bool>((f5 > 1), false);

            Assert<string>((--f5).ToString(), "-2/3");
            Assert<string>((++f3).ToString(), "3/2");

            Assert<string>(f5.ToString(), "-2/3"); //Changes sticking

            Fraction f10 = new Fraction(7.5);
            Assert<int>((int)f10, 7);
            Assert<decimal>(f10, 7.5M);

            Fraction f11 = new Fraction(-0.2);
            Fraction f12 = new Fraction(0.5);
            Assert<string>((f11 + f12).ToString(), "3/10");
            Assert<string>((f11 - f12).ToString(), "-7/10");
            Assert<string>((f11 * f12).ToString(), "-1/10");
            Assert<string>((f11 / f12).ToString(), "-2/5");

        }
    }
}
