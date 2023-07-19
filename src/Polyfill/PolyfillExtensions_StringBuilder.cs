#if MEMORYREFERENCED && (NETFRAMEWORK || NETSTANDARD2_0 || NETCOREAPP2_0)

// ReSharper disable RedundantUsingDirective
// ReSharper disable UnusedMember.Global

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using Link = System.ComponentModel.DescriptionAttribute;
using System.Threading;
using System.Threading.Tasks;
// ReSharper disable RedundantAttributeSuffix

static partial class PolyfillExtensions
{
    /// <summary>
    /// Copies the characters from a specified segment of this instance to a destination Char span.
    /// </summary>
    /// <param name="sourceIndex">The starting position in this instance where characters will be copied from. The index is zero-based.</param>
    /// <param name="destination">The writable span where characters will be copied.</param>
    /// <param name="count">The number of characters to be copied.</param>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.copyto#system-text-stringbuilder-copyto(system-int32-system-span((system-char))-system-int32)")]
    public static void CopyTo(
        this StringBuilder target,
        int sourceIndex,
        Span<char> destination,
        int count)
    {
        var destinationIndex = 0;
        while (true)
        {
            if (sourceIndex == target.Length)
            {
                break;
            }

            if (destinationIndex == count)
            {
                break;
            }

            destination[destinationIndex] = target[sourceIndex];
            destinationIndex++;
            sourceIndex++;
        }
    }

    /// <summary>
    /// Appends the string representation of a specified read-only character span to this instance.
    /// </summary>
    /// <param name="value">The read-only character span to append.</param>
    /// <returns>A reference to this instance after the append operation is completed.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append#system-text-stringbuilder-append(system-readonlyspan((system-char)))")]
    public static StringBuilder Append(this StringBuilder target, ReadOnlySpan<char> value)
    {
        if (value.Length <= 0)
        {
            return target;
        }

#if AllowUnsafeBlocks
        unsafe
        {
            fixed (char* valueChars = &MemoryMarshal.GetReference(value))
            {
                target.Append(valueChars, value.Length);
            }
        }
#else
        target.Append(value.ToArray());
#endif
        return target;
    }

    /// <summary>
    /// Returns a value indicating whether the characters in this instance are equal to the characters in a specified
    /// read-only character span.
    /// </summary>
    /// <param name="span">The character span to compare with the current instance.</param>
    /// <remarks>
    /// The Equals method performs an ordinal comparison to determine whether the characters in the current instance
    /// and span are equal.
    /// </remarks>
    /// <returns>true if the characters in this instance and span are the same; otherwise, false.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.equals#system-text-stringbuilder-equals(system-readonlyspan((system-char)))")]
    public static bool Equals(this StringBuilder target, ReadOnlySpan<char> span)
    {
        if (target.Length != span.Length)
        {
            return false;
        }

        for (var index = 0; index < target.Length; index++)
        {
            var ch1 = target[index];
            var ch2 = span[index];
            if (ch1 != ch2)
            {
                return false;
            }
        }

        return true;
    }
}
#endif