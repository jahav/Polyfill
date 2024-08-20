// <auto-generated />
#pragma warning disable

#if FeatureMemory

namespace Polyfills;

using System;
using System.Text;
using System.Buffers;
using System.IO;
using System.Runtime.InteropServices;
using Link = System.ComponentModel.DescriptionAttribute;
using System.Threading;
using System.Threading.Tasks;

static partial class Polyfill
{
#if !NETCOREAPP3_0_OR_GREATER
    /// <summary>
    /// Equivalent to Write(stringBuilder.ToString()) however it uses the
    /// StringBuilder.GetChunks() method to avoid creating the intermediate string
    /// </summary>
    /// <param name="value">The string (as a StringBuilder) to write to the stream</param>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.write#system-io-textwriter-write(system-text-stringbuilder)")]
    public static void Write(this TextWriter target, StringBuilder? value)
    {
        if (value != null)
        {
            foreach (ReadOnlyMemory<char> chunk in value.GetChunks())
            {
                target.Write(chunk.Span);
            }
        }
    }

    /// <summary>
    /// Equivalent to WriteAsync(stringBuilder.ToString()) however it uses the
    /// StringBuilder.GetChunks() method to avoid creating the intermediate string
    /// </summary>
    /// <param name="value">The string (as a StringBuilder) to write to the stream</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writeasync#system-io-textwriter-writeasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)")]
    public static Task WriteAsync(this TextWriter target, StringBuilder? value, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancellationToken);
        }

        if (value == null)
        {
            return Task.CompletedTask;
        }

        return WriteAsyncCore(value, cancellationToken);

        async Task WriteAsyncCore(StringBuilder builder, CancellationToken cancel)
        {
            foreach (ReadOnlyMemory<char> chunk in builder.GetChunks())
            {
                await target.WriteAsync(chunk, cancel).ConfigureAwait(false);
            }
        }
    }
#endif

#if NETFRAMEWORK || NETSTANDARD2_0 || NETCOREAPP2_0
#if FeatureValueTask

    /// <summary>
    /// Asynchronously writes a character memory region to the stream.
    /// </summary>
    /// <param name="buffer">The character memory region to write to the stream.</param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writeasync#system-io-textwriter-writeasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)")]
    public static ValueTask WriteAsync(
        this TextWriter target,
        ReadOnlyMemory<char> buffer,
        CancellationToken cancellationToken = default)
    {
        // StreamReader doesn't accept cancellation token (pre-netstd2.1)
        cancellationToken.ThrowIfCancellationRequested();

        if (!MemoryMarshal.TryGetArray(buffer, out var segment))
        {
            segment = new(buffer.ToArray());
        }

        return new(target.WriteAsync(segment.Array!, segment.Offset, segment.Count));
    }

    /// <summary>
    /// Asynchronously writes the text representation of a character memory region to the stream, followed by a line terminator.
    /// </summary>
    /// <param name="buffer">The character memory region to write to the stream.</param>
    /// <param name="cancellationToken">
    /// The token to monitor for cancellation requests.
    /// The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writelineasync#system-io-textwriter-writelineasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)")]
    public static ValueTask WriteLineAsync(
        this TextWriter target,
        ReadOnlyMemory<char> buffer,
        CancellationToken cancellationToken = default)
    {
        // StreamReader doesn't accept cancellation token (pre-netstd2.1)
        cancellationToken.ThrowIfCancellationRequested();

        if (!MemoryMarshal.TryGetArray(buffer, out var segment))
        {
            segment = new(buffer.ToArray());
        }

        return new(target.WriteLineAsync(segment.Array!, segment.Offset, segment.Count));
    }

#endif

    /// <summary>
    /// Writes a character span to the text stream.
    /// </summary>
    /// <param name="buffer">The character span to write.</param>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.write#system-io-textwriter-write(system-readonlyspan((system-char)))")]
    public static void Write(
        this TextWriter target,
        ReadOnlySpan<char> buffer)
    {
        var pool = ArrayPool<char>.Shared;
        var array = pool.Rent(buffer.Length);

        try
        {
            buffer.CopyTo(new(array));
            target.Write(array, 0, buffer.Length);
        }
        finally
        {
            pool.Return(array);
        }
    }

    /// <summary>
    /// Writes the text representation of a character span to the text stream, followed by a line terminator.
    /// </summary>
    /// <param name="buffer">The char span value to write to the text stream.</param>
    [Link("https://learn.microsoft.com/en-us/dotnet/api/system.io.textwriter.writeline#system-io-textwriter-writeline(system-readonlyspan((system-char)))")]
    public static void WriteLine(
        this TextWriter target,
        ReadOnlySpan<char> buffer)
    {
        var pool = ArrayPool<char>.Shared;
        var array = pool.Rent(buffer.Length);

        try
        {
            buffer.CopyTo(new(array));
            target.WriteLine(array, 0, buffer.Length);
        }
        finally
        {
            pool.Return(array);
        }
    }
#endif
}
#endif