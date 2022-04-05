﻿// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators
{
    public struct FixedReadOnlySpanEnumerator<T> : IRefEnumerable<T>
        where T : unmanaged
    {
        private readonly FixedReadOnlySpan<T> span;
        private int curr;

        public FixedReadOnlySpanEnumerator(FixedReadOnlySpan<T> span)
        {
            this.span = span;
            curr = -1;
            Current = default!;
        }

        public bool MoveNext()
        {
            curr++;
            if (curr >= span.Length)
                return false;
            Current = span[curr];
            return true;
        }

        public T Current { get; private set; }
    }
}