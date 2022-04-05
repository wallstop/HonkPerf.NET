// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators
{
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public struct IReadOnlyListEnumerator<T> : IRefEnumerable<T>
    {
        private readonly IReadOnlyList<T> list;
        private int curr;

        public IReadOnlyListEnumerator(IReadOnlyList<T> list)
        {
            this.list = list;
            this.curr = -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            curr++;
            return curr < list.Count;
        }

        public T Current => list[curr];
    }
}