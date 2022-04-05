// Copyright (c) wallstop 2022.
// This file from HonkPerf.NET-fork project is MIT-licensed.

namespace HonkPerf.NET.RefLinq
{
    using System;
    using Enumerators;

    public static partial class ActiveLinqExtensions
    {
        public static void ForEach<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq, Action<T> applier)
            where TEnumerator : IRefEnumerable<T>
        {
            
            T current = seq.enumerator.Current;
            applier(current);
            while (seq.enumerator.MoveNext())
            {
                current = seq.enumerator.Current;
                applier(current);
            }
        }
    }
}