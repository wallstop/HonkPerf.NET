﻿namespace HonkPerf.NET.RefLinq;

public static partial class ActiveLinqExtensions
{
    public static T LastOrDefault<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        where TEnumerator : IRefEnumerable<T>
    {
        if (!seq.enumerator.MoveNext())
            return default!;
        var curr = seq.enumerator.Current;
        while (seq.enumerator.MoveNext())
            curr = seq.enumerator.Current;
        return curr;
    }
}