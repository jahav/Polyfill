
// ReSharper disable RedundantUsingDirective
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable UnusedMember.Global

using System;
using Link = System.ComponentModel.DescriptionAttribute;
// ReSharper disable RedundantAttributeSuffix

static partial class PolyfillExtensions
{

#if NET7_0_OR_GREATER
    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="TimeSpan"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.nanoseconds")]
    public static int Nanoseconds(this TimeSpan target) =>
        target.Nanoseconds;

    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="DateTime"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.nanosecond")]
    public static int Nanosecond(this DateTime target) =>
        target.Nanosecond;

    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="DateTimeOffset"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.nanosecond")]
    public static int Nanosecond(this DateTimeOffset target) =>
        target.Nanosecond;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="TimeSpan"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.microsecond")]
    public static int Microseconds(this TimeSpan target) =>
        target.Microseconds;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="DateTime"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.microsecond")]
    public static int Microsecond(this DateTime target) =>
        target.Microsecond;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="DateTimeOffset"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.microsecond")]
    public static int Microsecond(this DateTimeOffset target) =>
        target.Microsecond;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> object that adds a specified number of microseconds to the value of this instance..
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.addmicroseconds")]
    public static DateTime AddMicroseconds(this DateTime target, double microseconds) =>
        target.AddMicroseconds(microseconds);

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> object that adds a specified number of microseconds to the value of this instance..
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.addmicroseconds")]
    public static DateTimeOffset AddMicroseconds(this DateTimeOffset target, double microseconds) =>
        target.AddMicroseconds(microseconds);

#else

    const long TicksPerMicrosecond = TimeSpan.TicksPerMillisecond * 1000;

    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="TimeSpan"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.nanoseconds")]
    public static int Nanoseconds(this TimeSpan target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 100;

    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="DateTime"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.nanosecond")]
    public static int Nanosecond(this DateTime target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 100;

    /// <summary>
    /// Gets the nanosecond component of the time represented by the current <see cref="DateTimeOffset"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.nanosecond")]
    public static int Nanosecond(this DateTimeOffset target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 100;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="TimeSpan"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.timespan.microseconds")]
    public static int Microseconds(this TimeSpan target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 1000;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="DateTime"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.microsecond")]
    public static int Microsecond(this DateTime target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 1000;

    /// <summary>
    /// Gets the microsecond component of the time represented by the current <see cref="DateTimeOffset"/> object.
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.microsecond")]
    public static int Microsecond(this DateTimeOffset target) =>
        (int) (target.TicksComponent() % TicksPerMicrosecond) * 1000;

    /// <summary>
    /// Returns a new <see cref="DateTime"/> object that adds a specified number of microseconds to the value of this instance..
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetime.addmicroseconds")]
    public static DateTime AddMicroseconds(this DateTime target, double microseconds) =>
       target.AddMilliseconds(microseconds / 1000);

    /// <summary>
    /// Returns a new <see cref="DateTimeOffset"/> object that adds a specified number of microseconds to the value of this instance..
    /// </summary>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.addmicroseconds")]
    public static DateTimeOffset AddMicroseconds(this DateTimeOffset target, double microseconds) =>
       target.AddMilliseconds(microseconds / 1000);

    static long TicksComponent(this TimeSpan target)
    {
        var noSeconds = new TimeSpan(target.Days, target.Hours, target.Minutes, 0);
        var secondsPart = target - noSeconds;
        return secondsPart.Ticks;
    }

    static long TicksComponent(this DateTime target)
    {
        var noSeconds = new DateTime(target.Year, target.Month, target.Day, target.Hour, target.Minute, 0, target.Kind);
        var secondsPart = target - noSeconds;
        return secondsPart.Ticks;
    }

    static long TicksComponent(this DateTimeOffset target)
    {
        var noSeconds = new DateTimeOffset(target.Year, target.Month, target.Day, target.Hour, target.Minute, 0, target.Offset);
        var secondsPart = target - noSeconds;
        return secondsPart.Ticks;
    }
#endif
}