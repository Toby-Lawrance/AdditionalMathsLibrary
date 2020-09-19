using System;

namespace TobyNumbers
{
    public static class Util
    {

        public static ulong GCD(ulong a, ulong b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a | b;
        }

        public static ulong LCM(ulong a, ulong b)
        {
            return a * b / GCD(a, b);
        }
        public static bool IsNumericType(Type t)
        {
            if (t is null)
            {
                return false;
            }

            //Special Exceptions
            if(t == typeof(Fraction))
            {
                return true;
            }


            switch (Type.GetTypeCode(t))
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                case TypeCode.Object:
                    if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        return IsNumericType(Nullable.GetUnderlyingType(t));
                    }
                    return false;
            }
            return false;
        }

        public static Type getTypeOfObject(object o)
        {
            Type t = o.GetType();
            if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return Nullable.GetUnderlyingType(t);
            }
            return t;
        }
    }
    
}
