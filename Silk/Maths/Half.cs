// Decompiled with JetBrains decompiler
// Type: System.Half
// Assembly: Ultz.Bcl.Half, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 128F6465-E243-4ECC-BE2B-6D58314DD9D7
// Assembly location: C:\Users\dbfsi\.nuget\packages\ultz.bcl.half.fallback\1.0.0\lib\netstandard2.0\Ultz.Bcl.Half.dll

#nullable enable
namespace System
{
    using Globalization;
    using Runtime.CompilerServices;
    using Runtime.InteropServices;

    public readonly struct Half : IComparable, IFormattable, IComparable<Half>, IEquatable<Half>
    {
        private const NumberStyles DefaultParseStyle = NumberStyles.Float | NumberStyles.AllowThousands;
        private const ushort SignMask = 32768;
        private const ushort SignShift = 15;
        private const ushort ExponentMask = 31744;
        private const ushort ExponentShift = 10;
        private const ushort SignificandMask = 1023;
        private const ushort SignificandShift = 0;
        private const ushort MinSign = 0;
        private const ushort MaxSign = 1;
        private const ushort MinExponent = 0;
        private const ushort MaxExponent = 31;
        private const ushort MinSignificand = 0;
        private const ushort MaxSignificand = 1023;
        private const ushort PositiveZeroBits = 0;
        private const ushort NegativeZeroBits = 32768;
        private const ushort EpsilonBits = 1;
        private const ushort PositiveInfinityBits = 31744;
        private const ushort NegativeInfinityBits = 64512;
        private const ushort PositiveQNaNBits = 32256;
        private const ushort NegativeQNaNBits = 65024;
        private const ushort MinValueBits = 64511;
        private const ushort MaxValueBits = 31743;
        private const long IllegalValueToInt64 = -9223372036854775808;
        private const ulong IllegalValueToUInt64 = 0;
        private const int IllegalValueToInt32 = -2147483648;
        private const uint IllegalValueToUInt32 = 0;
        public static readonly Half Epsilon = new Half((ushort)1);
        public static readonly Half PositiveInfinity = new Half((ushort)31744);
        public static readonly Half NegativeInfinity = new Half((ushort)64512);
        public static readonly Half NaN = new Half((ushort)65024);
        public static readonly Half MinValue = new Half((ushort)64511);
        public static readonly Half MaxValue = new Half((ushort)31743);
        private static readonly Half PositiveZero = new Half((ushort)0);
        private static readonly Half NegativeZero = new Half((ushort)32768);
        private readonly ushort m_value;

        private Half(ushort value) => this.m_value = value;

        private Half(bool sign, ushort exp, ushort sig) => this.m_value = (ushort)((uint)(((sign ? 1 : 0) << 15) + ((int)exp << 10)) + (uint)sig);

        private sbyte Exponent => (sbyte)(((int)this.m_value & 31744) >> 10);

        private ushort Significand => (ushort)((uint)this.m_value & 1023U);

        public static bool operator <(Half left, Half right)
        {
            if (Half.IsNaN(left) || Half.IsNaN(right))
                return false;
            bool flag = Half.IsNegative(left);
            if (flag == Half.IsNegative(right))
                return (int)left.m_value < (int)right.m_value ^ flag;
            return flag && !Half.AreZero(left, right);
        }

        public static bool operator >(Half left, Half right) => right < left;

        public static bool operator <=(Half left, Half right)
        {
            if (Half.IsNaN(left) || Half.IsNaN(right))
                return false;
            bool flag = Half.IsNegative(left);
            if (flag == Half.IsNegative(right))
                return (int)left.m_value <= (int)right.m_value ^ flag;
            return flag || Half.AreZero(left, right);
        }

        public static bool operator >=(Half left, Half right) => right <= left;

        public static bool operator ==(Half left, Half right)
        {
            if (Half.IsNaN(left) || Half.IsNaN(right))
                return false;
            return (int)left.m_value == (int)right.m_value || Half.AreZero(left, right);
        }

        public static bool operator !=(Half left, Half right) => !(left == right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite(Half value) => Half.StripSign(value) < (ushort)31744;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity(Half value) => Half.StripSign(value) == (ushort)31744;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN(Half value) => Half.StripSign(value) > (ushort)31744;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative(Half value) => (short)value.m_value < (short)0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity(Half value) => value.m_value == (ushort)64512;

        public static bool IsNormal(Half value)
        {
            int num = (int)Half.StripSign(value);
            return num < 31744 && num != 0 && (uint)(num & 31744) > 0U;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity(Half value) => value.m_value == (ushort)31744;

        public static bool IsSubnormal(Half value)
        {
            int num = (int)Half.StripSign(value);
            return num < 31744 && num != 0 && (num & 31744) == 0;
        }

        public static Half Parse(
#nullable disable
    string s, NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
#nullable enable
    IFormatProvider? formatProvider = null)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            return Half.Parse(s.AsSpan(), style, formatProvider);
        }

        public static Half Parse(
          ReadOnlySpan<char> s,
          NumberStyles style = NumberStyles.Float | NumberStyles.AllowThousands,
          IFormatProvider? formatProvider = null)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(
#nullable disable
    string s, out Half result) => Half.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, (IFormatProvider)null, out result);

        public static bool TryParse(ReadOnlySpan<char> s, out Half result) => Half.TryParse(s, NumberStyles.Float | NumberStyles.AllowThousands, (IFormatProvider)null, out result);

        public static bool TryParse(
          string s,
          NumberStyles style,

#nullable enable
      IFormatProvider? formatProvider,
          out Half result)
        {
            return Half.TryParse(s.AsSpan(), style, formatProvider, out result);
        }

        public static bool TryParse(
          ReadOnlySpan<char> s,
          NumberStyles style,
          IFormatProvider? formatProvider,
          out Half result)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool AreZero(Half left, Half right) => (ushort)(((int)left.m_value | (int)right.m_value) & -32769) == (ushort)0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNaNOrZero(Half value) => ((int)value.m_value - 1 & -32769) >= 31744;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ushort StripSign(Half value) => (ushort)((uint)value.m_value & 4294934527U);

        public int CompareTo(object? obj)
        {
            if (obj is Half other)
                return this.CompareTo(other);
            if (obj != null)
                throw new ArgumentException("The given argument is not a half.", nameof(obj));
            return 1;
        }

        public int CompareTo(Half other)
        {
            if ((int)(short)this.m_value < (int)(short)other.m_value)
                return -1;
            if ((int)(short)this.m_value > (int)(short)other.m_value)
                return 1;
            if ((int)this.m_value == (int)other.m_value)
                return 0;
            if (!Half.IsNaN(this))
                return 1;
            return !Half.IsNaN(other) ? -1 : 0;
        }

        public override bool Equals(object? obj) => obj is Half other && this.Equals(other);

        public bool Equals(Half other)
        {
            if (this == other)
                return true;
            return Half.IsNaN(this) && Half.IsNaN(other);
        }

        public override int GetHashCode() => Half.IsNaNOrZero(this) ? (int)this.m_value & 31744 : (int)this.m_value;

        public override
#nullable disable
    string ToString() => string.Format("0x{0:X4}", (object)this.m_value);

        public string ToString(
#nullable enable
    string? format = null, IFormatProvider? formatProvider = null) => string.Format("0x{0:X4}", (object)this.m_value);

        public bool TryFormat(
          Span<char> destination,
          out int charsWritten,
          ReadOnlySpan<char> format,
          IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public static explicit operator Half(float value)
        {
            int uint32 = (int)Half.Helpers.ToUInt32(value);
            bool sign = (uint)(uint32 & int.MinValue) >> 31 > 0U;
            int num1 = (uint32 & 2139095040) >> 23;
            uint num2 = (uint)(uint32 & 8388607);
            if (num1 == (int)byte.MaxValue)
            {
                if (num2 != 0U)
                    return Half.Helpers.CreateHalfNaN(sign, (ulong)num2 << 41);
                return !sign ? Half.PositiveInfinity : Half.NegativeInfinity;
            }
            uint num3 = num2 >> 9 | (((int)num2 & 511) != 0 ? 1U : 0U);
            return (num1 | (int)num3) == 0 ? new Half(sign, (ushort)0, (ushort)0) : new Half(Half.RoundPackToHalf(sign, (short)(num1 - 113), (ushort)(num3 | 16384U)));
        }

        public static explicit operator Half(double value)
        {
            long uint64 = (long)Half.Helpers.ToUInt64(value);
            bool sign = (ulong)(uint64 & long.MinValue) >> 63 > 0UL;
            int num1 = (int)((ulong)(uint64 & 9218868437227405312L) >> 52);
            ulong l = (ulong)(uint64 & 4503599627370495L);
            if (num1 == 2047)
            {
                if (l != 0UL)
                    return Half.Helpers.CreateHalfNaN(sign, l << 12);
                return !sign ? Half.PositiveInfinity : Half.NegativeInfinity;
            }
            uint num2 = (uint)Half.Helpers.ShiftRightJam(l, 38);
            return (num1 | (int)num2) == 0 ? new Half(sign, (ushort)0, (ushort)0) : new Half(Half.RoundPackToHalf(sign, (short)(num1 - 1009), (ushort)(num2 | 16384U)));
        }

        public static implicit operator float(Half value)
        {
            bool sign = Half.IsNegative(value);
            int num = (int)value.Exponent;
            uint significand = (uint)value.Significand;
            switch (num)
            {
                case 0:
                    if (significand == 0U)
                        return Half.Helpers.CreateSingle(sign ? 2147483648U : 0U);
                    int Exp;
                    (Exp, significand) = Half.NormSubnormalF16Sig(significand);
                    num = Exp - 1;
                    break;
                case 31:
                    if (significand != 0U)
                        return Half.Helpers.CreateSingleNaN(sign, (ulong)significand << 54);
                    return !sign ? float.PositiveInfinity : float.NegativeInfinity;
            }
            return Half.Helpers.CreateSingle(sign, (byte)(num + 112), significand << 13);
        }

        public static implicit operator double(Half value)
        {
            bool sign = Half.IsNegative(value);
            int num = (int)value.Exponent;
            uint significand = (uint)value.Significand;
            switch (num)
            {
                case 0:
                    if (significand == 0U)
                        return Half.Helpers.CreateDouble(sign ? 9223372036854775808UL : 0UL);
                    int Exp;
                    (Exp, significand) = Half.NormSubnormalF16Sig(significand);
                    num = Exp - 1;
                    break;
                case 31:
                    if (significand != 0U)
                        return Half.Helpers.CreateDoubleNaN(sign, (ulong)significand << 54);
                    return !sign ? double.PositiveInfinity : double.NegativeInfinity;
            }
            return Half.Helpers.CreateDouble(sign, (ushort)(num + 1008), (ulong)significand << 42);
        }

        public static Half operator -(Half value) => !Half.IsNaN(value) ? new Half((ushort)((uint)value.m_value ^ 32768U)) : value;

        public static Half operator +(Half value) => value;

        private static ushort RoundPackToHalf(bool sign, short exp, ushort sig)
        {
            int num = (int)sig & 15;
            if ((uint)exp >= 29U)
            {
                if (exp < (short)0)
                {
                    sig = (ushort)Half.Helpers.ShiftRightJam((uint)sig, (int)-exp);
                    exp = (short)0;
                }
                else if (exp > (short)29 || (int)sig + 8 >= 32768)
                    return !sign ? (ushort)31744 : (ushort)64512;
            }
            sig = (ushort)((int)sig + 8 >> 4);
            sig &= (ushort)~(((num ^ 8) != 0 ? 0 : 1) & 1);
            if (sig == (ushort)0)
                exp = (short)0;
            return new Half(sign, (ushort)exp, sig).m_value;
        }

        private static (int Exp, uint Sig) NormSubnormalF16Sig(uint sig)
        {
            int num = Half.Helpers.LeadingZeroCount(sig) - 16 - 5;
            return (1 - num, sig << num);
        }

        private class Helpers
        {
            public const ulong DoubleSignMask = 9223372036854775808;
            public const int DoubleSignShift = 63;
            public const long DoubleExponentMask = 9218868437227405312;
            public const int DoubleExponentShift = 52;
            public const ulong DoubleSignificandMask = 4503599627370495;
            public const int DoubleSignificandShift = 0;
            public const uint SingleSignMask = 2147483648;
            public const int SingleSignShift = 31;
            public const int SingleExponentMask = 2139095040;
            public const int SingleExponentShift = 23;
            public const uint SingleSignificandMask = 8388607;
            public const int SingleSignificandShift = 0;
            public const ushort HalfSignMask = 32768;
            public const int HalfSignShift = 15;
            public const ushort HalfExponentMask = 31744;
            public const int HalfExponentShift = 10;
            public const ushort HalfSignificandMask = 1023;
            public const int HalfSignificandShift = 0;

            public static double CreateDouble(ulong value) => BitConverter.Int64BitsToDouble((long)value);

            public static float CreateSingle(uint value) => Half.Helpers.Int32BitsToSingle((int)value);

            public static unsafe Half CreateHalf(ushort value) => *(Half*)&value;

            public static Half CreateHalf(bool sign, ushort exp, ushort sig) => Half.Helpers.CreateHalf((ushort)((uint)((sign ? 1 : 0) << 15 | (int)exp << 23) | (uint)sig));

            public static float CreateSingle(bool sign, byte exp, uint sig) => Half.Helpers.Int32BitsToSingle((sign ? 1 : 0) << 31 | (int)exp << 23 | (int)sig);

            public static double CreateDouble(bool sign, ushort exp, ulong sig) => BitConverter.Int64BitsToDouble((sign ? 1L : 0L) << 63 | (long)exp << 52 | (long)sig);

            public static unsafe ushort ToUInt16(Half value) => *(ushort*)&value;

            public static uint ToUInt32(float value) => (uint)Half.Helpers.SingleToInt32Bits(value);

            public static ulong ToUInt64(double value) => (ulong)BitConverter.DoubleToInt64Bits(value);

            public static unsafe float Int32BitsToSingle(int value) => *(float*)&value;

            public static unsafe int SingleToInt32Bits(float value) => *(int*)&value;

            public static Half CreateHalfNaN(bool sign, ulong significand) => Half.Helpers.CreateHalf((ushort)((uint)((sign ? 1 : 0) << 15 | 32256) | (uint)(significand >> 54)));

            public static float CreateSingleNaN(bool sign, ulong significand) => Half.Helpers.CreateSingle((uint)((sign ? 1 : 0) << 31 | 2143289344) | (uint)(significand >> 41));

            public static double CreateDoubleNaN(bool sign, ulong significand) => Half.Helpers.CreateDouble((ulong)((sign ? 1L : 0L) << 63 | 9221120237041090560L) | significand >> 12);

            public static uint ShiftRightJam(uint i, int dist)
            {
                if (dist < 31)
                    return i >> dist | ((int)i << -dist != 0 ? 1U : 0U);
                return i == 0U ? 0U : 1U;
            }

            public static ulong ShiftRightJam(ulong l, int dist)
            {
                if (dist < 63)
                    return l >> dist | ((long)l << -dist != 0L ? 1UL : 0UL);
                return l == 0UL ? 0UL : 1UL;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static int LeadingZeroCount(ulong value)
            {
                uint num = (uint)(value >> 32);
                return num == 0U ? 32 + Half.Helpers.LeadingZeroCount((uint)value) : Half.Helpers.LeadingZeroCount(num);
            }
        }
    }
}
