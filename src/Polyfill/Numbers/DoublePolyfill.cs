#pragma warning disable

// ReSharper disable RedundantUsingDirective
// ReSharper disable PartialTypeWithSinglePart

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Link = System.ComponentModel.DescriptionAttribute;

[ExcludeFromCodeCoverage]
[DebuggerNonUserCode]
#if PolyPublic
public
#endif
static partial class DoublePolyfill
{
    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-string-system-iformatprovider-system-double@)")]
    public static bool TryParse(string? target, IFormatProvider? provider, out double result) =>
#if !NET7_0_OR_GREATER
        double.TryParse(target, NumberStyles.Float, provider, out result);
#else
        double.TryParse(target, provider, out result);
#endif

#if FeatureMemory
    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-byte))-system-iformatprovider-system-double@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, IFormatProvider? provider, out double result) =>
#if !NET8_0_OR_GREATER
        double.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Float, provider, out result);
#else
        double.TryParse(target, provider, out result);
#endif

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-char))-system-double@)")]
    public static bool TryParse(ReadOnlySpan<char> target, out double result) =>
#if NETCOREAPP2_0 || NETFRAMEWORK || NETSTANDARD2_0
        double.TryParse(target.ToString(), out result);
#else
        double.TryParse(target, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-double@)")]
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, out double result) =>
#if !NET7_0_OR_GREATER
        double.TryParse(target.ToString(), NumberStyles.Float, provider, out result);
#else
        double.TryParse(target, provider, out result);
#endif

    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-byte))-system-globalization-numberstyles-system-iformatprovider-system-double@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, NumberStyles style, IFormatProvider? provider, out double result) =>
#if !NET8_0_OR_GREATER
        double.TryParse(Encoding.UTF8.GetString(target.ToArray()), style, provider, out result);
#else
        double.TryParse(target, style, provider, out result);
#endif

    /// <summary>
    /// Tries to convert a UTF-8 character span containing the string representation of a number to its double-precision floating-point number equivalent..
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-byte))-system-double@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, out double result) =>
#if !NET8_0_OR_GREATER
        double.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Float, null, out result);
#else
        double.TryParse(target, out result);
#endif

    /// <summary>
    /// Converts the string representation of a number in a specified style and culture-specific format to its double-precision floating-point number equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.double.tryparse#system-double-tryparse(system-readonlyspan((system-char))-system-globalization-numberstyles-system-iformatprovider-system-double@)")]
    public static bool TryParse(ReadOnlySpan<char> target, NumberStyles style, IFormatProvider? provider, out double result) =>
#if NETCOREAPP2_0 || NETSTANDARD2_0 || NETFRAMEWORK
        double.TryParse(target.ToString(), style, provider, out result);
#else
        double.TryParse(target, style, provider, out result);
#endif
#endif
}