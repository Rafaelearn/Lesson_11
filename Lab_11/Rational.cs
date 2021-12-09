using System;

namespace Lab_11
{
    public class Rational
    {
        public int  Top { get; set; }
        private int bottom;
        public int Bottom
        {
            get { return bottom; }
            set {
                if (value == 0)
                {
                    throw new DivideByZeroException("Zero cannot be in the denominator!");
                }
                else
                {
                    bottom = value;
                }
            }
        }
        public Rational(int top, int bottom)
        {
            Top = top;
            Bottom = bottom;
        }
        public Rational()
        {

        }
        public static bool operator ==(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom == (double)r2.Top / r2.Bottom)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom == (double)r2.Top / r2.Bottom)
            {
                return false;
            }
            return true;
        }
        public static bool operator >(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom > (double)r2.Top / r2.Bottom)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom < (double)r2.Top / r2.Bottom)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom >= (double)r2.Top / r2.Bottom)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Rational r1, Rational r2)
        {
            if ((double)r1.Top / r1.Bottom <= (double)r2.Top / r2.Bottom)
            {
                return true;
            }
            return false;
        }
        public static Rational operator +(Rational r1, Rational r2)
        {
            Rational r3 = new Rational();
            r3.Top = r1.Top * r2.Bottom + r2.Top * r1.Bottom;
            r3.Bottom = r1.Bottom * r2.Bottom;
            return r3;
        }
        public static Rational operator -(Rational r1, Rational r2)
        {
            Rational r3 = new Rational();
            r3.Top = r1.Top * r2.Bottom - r2.Top * r1.Bottom;
            r3.Bottom = r1.Bottom * r2.Bottom;
            return r3;
        }
        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.Top * r2.Top, r1.Bottom * r2.Bottom);
        }
        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.Top * r2.Bottom, r1.Bottom * r2.Top);
        }
        public static Rational operator %(Rational r1, Rational r2)
        {
            Rational r3 = new Rational();
            r3.Top = r1.Top * r2.Bottom + r2.Top * r1.Bottom;
            r3.Bottom = r1.Bottom * r2.Bottom;
            return r3;
        }
        public static Rational operator ++(Rational r1)
        {
            return new Rational(r1.Top + r1.Bottom, r1.Bottom);
        }
        public static Rational operator --(Rational r1)
        {
            return new Rational(r1.Top - r1.Bottom, r1.Bottom);
        }
        public static implicit operator Rational(int x)
        {
            return new Rational(x, 1);
        }
        public static explicit operator int(Rational r)
        {
            return r.Top / r.Bottom;
        }
        public static explicit operator double(Rational r)
        {
            return (double)r.Top / r.Bottom;
        }
        public override string ToString()
        {
            return $"{Top}/{Bottom}";
        }
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Rational r1)
            {
                return r1 == this;
            }
            return base.Equals(obj);
        }
    }
}
