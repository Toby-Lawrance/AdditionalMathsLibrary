using System;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace TobyNumbers
{
    public partial class Fraction
    {
        private bool positive;
        private ulong numerator; //Numerator is always less than denominator
        private ulong denominator; //Of Fraction

        public bool Positive { get => positive; set => positive = value; }
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

        private Fraction(bool pos,ulong num, ulong denom, bool simp = true)
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

        private void simplify() //Run after all operations
        {
            bool changeMade = false;

            ulong gcd = Util.GCD(numerator, denominator);
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
            var checkable = GetSameDenominator(this, o);
            Fraction f1 = checkable.Item1;
            Fraction f2 = checkable.Item2;
            if (f1.Positive && !f2.Positive)
            {
                f1.Positive = true; f2.Positive = true;
                return f1.Subtract(f2);
            } else if (!f1.Positive && f2.Positive)
            {
                f1.Positive = true; f2.Positive = true;
                return f2.Subtract(f1);
            } else if (!(f1.Positive || f2.Positive))
            {
                return new Fraction(false, f1.Numerator + f2.Numerator, f1.Denominator);
            } else
            {
                return new Fraction(true, f1.Numerator + f2.Numerator, f1.Denominator);
            }
                
        }

        public Fraction Subtract(Fraction o)
        {
            var checkable = GetSameDenominator(this, o);
            Fraction f1 = checkable.Item1;
            Fraction f2 = checkable.Item2;
            if (f1.Positive && f2.Positive)
            {
                if(f2.Numerator > f1.Numerator)
                {
                    return new Fraction(false, f2.Numerator - f1.Numerator, f1.Denominator);
                } else
                {
                    return new Fraction(true, f1.Numerator - f2.Numerator, f1.Denominator);
                }
            }
            else if (!f1.Positive && f2.Positive)
            {
                f2.Positive = false;
                return f1.Add(f2);
            }
            else if (f1.Positive && !f2.Positive)
            {
                f2.Positive = true;
                return f1.Add(f2);
            }
            else
            {
                f1.Positive = true; f2.Positive = true;
                return f2.Subtract(f1);
            }
        }

        public Fraction Multiply(Fraction o)
        {
            return new Fraction(!(this.Positive ^ o.Positive),this.numerator * o.numerator,this.denominator * o.denominator);
        }

        public Fraction Divide(Fraction o)
        {
            return new Fraction(!(this.Positive ^ o.Positive),this.numerator * o.denominator, this.denominator * o.numerator);
        }

        public bool GreaterThan(Fraction o)
        {
            if (!this.Positive && o.Positive) { return false; }
            else if (this.Positive && !o.Positive) { return true; }
            else if (!this.Positive && !o.Positive)
            {
                //-2 > -3, so for -3 and -2; check if 3 > 2
                var checkable = GetSameDenominator(this, o);
                return checkable.Item1.Numerator < checkable.Item2.Numerator;
            }
            else
            {
                var checkable = GetSameDenominator(this, o);
                return checkable.Item1.Numerator > checkable.Item2.Numerator;
            }
            
        }

        private static (Fraction,Fraction) GetSameDenominator(Fraction f1, Fraction f2)
        {
            if (f1.denominator == f2.denominator)
            {
                return (f1, f2);
            }

            ulong lcm = Util.LCM(f1.denominator, f2.denominator);
            ulong thismult = lcm / f1.denominator;
            ulong thatmult = lcm / f2.denominator;
            return GetSameDenominator(new Fraction(f1.positive,f1.numerator * thismult, f1.denominator * thismult, false),new Fraction(f2.positive,f2.numerator * thatmult, f2.denominator * thatmult, false));
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
