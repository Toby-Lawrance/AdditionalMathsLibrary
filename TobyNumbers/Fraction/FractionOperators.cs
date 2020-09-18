using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobyNumbers
{
    public partial class Fraction
    {
        //Add
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return a.Add(b);
        }

        public static Fraction operator +(Fraction a, byte b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, decimal b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, double b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, short b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, int b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, long b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, sbyte b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, ushort b)
        {
            return a.Add(new Fraction(b));
        }

        public static Fraction operator +(Fraction a, uint b)
        {
            return a.Add(new Fraction(b));
        }

        //Subtract
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a.Subtract(b);
        }

        public static Fraction operator -(Fraction a, byte b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, decimal b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, double b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, short b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, int b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, long b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, sbyte b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, ushort b)
        {
            return a.Subtract(new Fraction(b));
        }

        public static Fraction operator -(Fraction a, uint b)
        {
            return a.Subtract(new Fraction(b));
        }

        //Multiply
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return a.Multiply(b);
        }

        public static Fraction operator *(Fraction a, byte b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, decimal b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, double b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, short b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, int b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, long b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, sbyte b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, ushort b)
        {
            return a.Multiply(new Fraction(b));
        }

        public static Fraction operator *(Fraction a, uint b)
        {
            return a.Multiply(new Fraction(b));
        }

        //Divide
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a.Divide(b);
        }

        public static Fraction operator /(Fraction a, byte b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, decimal b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, double b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, short b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, int b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, long b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, sbyte b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, ushort b)
        {
            return a.Divide(new Fraction(b));
        }

        public static Fraction operator /(Fraction a, uint b)
        {
            return a.Divide(new Fraction(b));
        }

        //Comparison
        public static bool operator ==(Fraction f1, Fraction f2)
        {
            if(!(f1 is null))
            {
                return f1.Equals(f2);
            }
            return false;
        }

        public static bool operator ==(Fraction a, byte b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, decimal b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, double b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, short b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, int b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, long b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, sbyte b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, ushort b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator ==(Fraction a, uint b)
        {
            return a == (new Fraction(b));
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static bool operator !=(Fraction a, byte b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, decimal b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, double b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, short b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, int b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, long b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, sbyte b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, ushort b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator !=(Fraction a, uint b)
        {
            return !(a == (new Fraction(b)));
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.GreaterThan(f2);
        }

        public static bool operator >(Fraction a, byte b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, decimal b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, double b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, short b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, int b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, long b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, sbyte b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, ushort b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator >(Fraction a, uint b)
        {
            return a > (new Fraction(b));
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f2.GreaterThan(f1);
        }

        public static bool operator <(Fraction a, byte b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, decimal b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, double b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, short b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, int b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, long b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, sbyte b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, ushort b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator <(Fraction a, uint b)
        {
            return a < (new Fraction(b));
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return f1.GreaterThan(f2) || f1 == f2;
        }

        public static bool operator >=(Fraction a, byte b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, decimal b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, double b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, short b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, int b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, long b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, sbyte b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, ushort b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator >=(Fraction a, uint b)
        {
            return a >= (new Fraction(b));
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return f2.GreaterThan(f1) || f1 == f2;
        }

        public static bool operator <=(Fraction a, byte b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, decimal b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, double b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, short b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, int b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, long b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, sbyte b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, ushort b)
        {
            return a <= (new Fraction(b));
        }

        public static bool operator <=(Fraction a, uint b)
        {
            return a <= (new Fraction(b));
        }

        //Extra operators
        public static Fraction operator ++(Fraction f)
        {
            return new Fraction(f.Numerator + f.Denominator, f.Denominator,false);
        }

        public static Fraction operator --(Fraction f)
        {
            if(f.Denominator > f.Numerator)
            {
                return new Fraction(false,f.Denominator - f.Numerator, f.Denominator,true);
            }
            return new Fraction(f.Numerator - f.Denominator, f.Denominator,false);
        }


        //Casting

        public static implicit operator decimal(Fraction f)
        {
            return f.GetDecimal(); ;
        }

        public static explicit operator double(Fraction f)
        {
            return (double)f.GetDecimal();
        }

        public static explicit operator float(Fraction f)
        {
            return (float)f.GetDecimal();
        }

        public static explicit operator long(Fraction f)
        {
            return f.GetWholeNumber();
        }

        public static explicit operator int(Fraction f)
        {
            return (int)f.GetWholeNumber();
        }

        public static explicit operator short(Fraction f)
        {
            return (short)f.GetWholeNumber();
        }

        public static explicit operator byte(Fraction f)
        {
            return (byte)f.GetWholeNumber();
        }
    }
}
