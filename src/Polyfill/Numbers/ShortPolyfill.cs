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
static partial class ShortPolyfill
{
    /// <summary>
    /// Tries to parse a string into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-string-system-iformatprovider-system-int16@)")]
    public static bool TryParse(string? target, IFormatProvider? provider, out short result) =>
#if !NET7_0_OR_GREATER
        short.TryParse(target, NumberStyles.Integer, provider, out result);
#else
        short.TryParse(target, provider, out result);
#endif

#if FeatureMemory
    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-byte))-system-iformatprovider-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, IFormatProvider? provider, out short result) =>
#if !NET8_0_OR_GREATER
        short.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Integer, provider, out result);
#else
        short.TryParse(target, provider, out result);
#endif

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its short equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-char))-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<char> target, out short result) =>
#if NETCOREAPP2_0 || NETFRAMEWORK || NETSTANDARD2_0
        short.TryParse(target.ToString(), out result);
#else
        short.TryParse(target, out result);
#endif

    /// <summary>
    /// Tries to parse a span of characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-char))-system-iformatprovider-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<char> target, IFormatProvider? provider, out short result) =>
#if !NET7_0_OR_GREATER
        short.TryParse(target.ToString(), NumberStyles.Integer, provider, out result);
#else
        short.TryParse(target, provider, out result);
#endif

    /// <summary>
    /// Tries to parse a span of UTF-8 characters into a value.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-byte))-system-globalization-numberstyles-system-iformatprovider-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, NumberStyles style, IFormatProvider? provider, out short result) =>
#if !NET8_0_OR_GREATER
        short.TryParse(Encoding.UTF8.GetString(target.ToArray()), style, provider, out result);
#else
        short.TryParse(target, style, provider, out result);
#endif

    /// <summary>
    /// Tries to convert a UTF-8 character span containing the string representation of a number to its short equivalent.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-char))-system-globalization-numberstyles-system-iformatprovider-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<byte> target, out short result) =>
#if !NET8_0_OR_GREATER
        short.TryParse(Encoding.UTF8.GetString(target.ToArray()), NumberStyles.Integer, null, out result);
#else
        short.TryParse(target, out result);
#endif

    /// <summary>
    /// Converts the span representation of a number in a specified style and culture-specific format to its short equivalent. A return value indicates whether the conversion succeeded.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.int16.tryparse#system-int16-tryparse(system-readonlyspan((system-char))-system-globalization-numberstyles-system-iformatprovider-system-int16@)")]
    public static bool TryParse(ReadOnlySpan<char> target, NumberStyles style, IFormatProvider? provider, out short result) =>
#if NETCOREAPP2_0 || NETSTANDARD2_0 || NETFRAMEWORK
        short.TryParse(target.ToString(), style, provider, out result);
#else
        short.TryParse(target, style, provider, out result);
#endif
#endif
}