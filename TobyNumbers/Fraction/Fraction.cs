using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;

namespace TobyNumbers
{
    public partial class Fraction
    {
        private bool positive;
        private ulong numerator; //Numerator is always less than denominator
        private ulong denominator; //Of Fraction

        public bool Positive { get => positive; }
        public ulong Numerator { get => numerator; set { numerator = value; positive = numerator >= 0; simplify(); } }
        public ulong Denominator { get => denominator; set { denominator = value; simplify(); } }

        public Fraction(long numerator, long denominator)
        {
            this.positive = numerator >= 0;
            this.numerator = numerator >= 0 ? (ulong)numerator : (ulong)Math.Abs(numerator);
            this.denominator = denominator >= 0 ? (ulong)denominator : (ulong)Math.Abs(denominator);
            simplify();
        }

        public Fraction(ulong numerator, ulong denominator)
        {
            this.positive = true;
            this.numerator = numerator;
            this.denominator = denominator;
            simplify();
        }

        private Fraction(ulong numerator, ulong denominator, bool simp)
        {
            this.positive = true;
            this.numerator = numerator;
            this.denominator = denominator;
            if(simp)
            {
                simplify();
            }
        }

        private Fraction(bool pos,ulong num, ulong denom, bool simp)
        {
            this.positive = pos;
            this.numerator = num;
            this.denominator = denom;
            if (simp)
            {
                simplify();
            }
        }


        public Fraction()
        {
            this.positive = true;
            this.numerator = 0;
            this.denominator = 1;
        }

        //Begin integer types
        public Fraction(int a)
        {
            this.positive = a >= 0;
            this.numerator = (ulong)Math.Abs(a);
            this.denominator = 1;
            simplify();
        }

        public Fraction(short a)
        {
            this.positive = a >= 0;
            this.numerator = (ulong)Math.Abs(a);
            this.denominator = 1;
            simplify();
        }

        public Fraction(long a)
        {
            this.positive = a >= 0;
            this.numerator = (ulong)Math.Abs(a);
            this.denominator = 1;
            simplify();
        }

        public Fraction(byte a)
        {
            this.positive = a >= 0;
            this.numerator = (ulong)Math.Abs(a);
            this.denominator = 1;
            simplify();
        }
        //End Integer types

        //Begin decimal types
        public Fraction(decimal a)
        {
            this.positive = a >= 0;
            long decimalPlaces = a.ToString().IndexOf('.') > -1 ? a.ToString().Length - a.ToString().IndexOf('.') : 0; 
            this.numerator = (ulong)(Math.Abs(a) * (long)Math.Pow(10,decimalPlaces));
            this.denominator = (ulong)Math.Pow(10, decimalPlaces);
            simplify();
        }

        public Fraction(double a)
        {
            this.positive = a >= 0;
            long decimalPlaces = a.ToString().IndexOf('.') > -1 ? a.ToString().Length - a.ToString().IndexOf('.') : 0;
            this.numerator = (ulong)(Math.Abs(a) * Math.Pow(10, decimalPlaces));
            this.denominator = (ulong)Math.Pow(10, decimalPlaces);
            simplify();
        }

        public Fraction(float a)
        {
            this.positive = a >= 0;
            long decimalPlaces = a.ToString().IndexOf('.') > -1 ? a.ToString().Length - a.ToString().IndexOf('.') : 0;
            this.numerator = (ulong)(Math.Abs(a) * Math.Pow(10, decimalPlaces));
            this.denominator = (ulong)Math.Pow(10, decimalPlaces);
            simplify();
        }
        //End decimal types

        private ulong GCD(ulong a, ulong b)
        {
            while(a != 0 && b != 0)
            {
                if(a > b)
                {
                    a %= b;
                } else
                {
                    b %= a;
                }
            }

            return a | b;
        }

        private ulong LCM(ulong a, ulong b)
        {
            return a * b / GCD(a, b);
        }

        private void simplify() //Run after all operations
        {
            bool changeMade = false;

            ulong gcd = GCD(numerator, denominator);
            if(gcd != 1)
            {
                numerator /= gcd;
                denominator /= gcd;
                changeMade = true;
            }

            if(changeMade)
            {
                this.simplify();
            }
        }

        public bool Equals(Fraction f)
        {
            if(f is null) { return false; }
            this.simplify(); f.simplify(); //Help ensure they're as correct as possible
            return this.numerator == f.numerator && this.denominator == f.denominator;
        }

        public override bool Equals(object obj)
        {
            if(obj is Fraction)
            {
                return this.Equals(obj as Fraction);
            }
            if(Util.IsNumericType(obj.GetType()))
            {
                Fraction f2 = null;
                switch(Type.GetTypeCode(Util.getTypeOfObject(obj)))
                {
                    case TypeCode.Byte: f2 = new Fraction((byte)obj); break;
                    case TypeCode.Decimal: f2 = new Fraction((decimal)obj); break;
                    case TypeCode.Double: f2 = new Fraction((double)obj); break;
                    case TypeCode.Int16: f2 = new Fraction((short)obj); break;
                    case TypeCode.Int32: f2 = new Fraction((int)obj); break;
                    case TypeCode.Int64: f2 = new Fraction((long)obj); break;
                    case TypeCode.SByte: f2 = new Fraction((sbyte)obj); break;
                    case TypeCode.Single: f2 = new Fraction((Single)obj); break;
                    case TypeCode.UInt16: f2 = new Fraction((ushort)obj); break;
                    case TypeCode.UInt32: f2 = new Fraction((uint)obj); break;
                    case TypeCode.UInt64: f2 = new Fraction((long)obj); break;
                }
                return this.Equals(f2);
            }
            return base.Equals(obj);
        }

        public Fraction Add(Fraction o)
        {
            if(this.denominator == o.denominator)
            {
                return new Fraction(this.numerator + o.numerator, this.denominator);
            }

            ulong lcm = LCM(this.denominator, o.denominator);
            ulong thismult = lcm / this.denominator;
            ulong thatmult = lcm / o.denominator;
            return new Fraction(this.numerator * thismult,this.denominator * thismult,false) + new Fraction(o.numerator * thatmult, o.denominator * thatmult, false);
        }

        public Fraction Subtract(Fraction o)
        {
            if (this.denominator == o.denominator)
            {
                if(o.numerator > this.numerator)
                {
                    return new Fraction(false,o.numerator - this.numerator, this.denominator,true);
                }
                return new Fraction(this.numerator - o.numerator, this.denominator);
            }

            ulong lcm = LCM(this.denominator, o.denominator);
            ulong thismult = lcm / this.denominator;
            ulong thatmult = lcm / o.denominator;
            return new Fraction(this.numerator * thismult, this.denominator * thismult, false) - new Fraction(o.numerator * thatmult, o.denominator * thatmult, false);
        }

        public Fraction Multiply(Fraction o)
        {
            return new Fraction(this.numerator * o.numerator,this.denominator * o.denominator);
        }

        public Fraction Divide(Fraction o)
        {
            return new Fraction(this.numerator * o.denominator, this.denominator * o.numerator);
        }

        public bool GreaterThan(Fraction o)
        {
            if (this.denominator == o.denominator)
            {
                return this.numerator > o.numerator;
            }

            ulong lcm = LCM(this.denominator, o.denominator);
            ulong thismult = lcm / this.denominator;
            ulong thatmult = lcm / o.denominator;
            return new Fraction(this.numerator * thismult, this.denominator * thismult, false) > new Fraction(o.numerator * thatmult, o.denominator * thatmult, false);
        }

        private long GetWholeNumber()
        {
            return (long)(numerator / denominator) * (positive ? 1 : -1);
        }

        private Decimal GetDecimal()
        {
            return ((Decimal)this.numerator / (Decimal)this.denominator);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine<ulong,ulong>(this.numerator,this.denominator);
        }

        public override string ToString()
        {
            if(!positive)
            {
                return $"-{numerator}/{denominator}";
            } else
            {
                return $"{numerator}/{denominator}";
            }
            
        }
    }
}
