﻿// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators
{
    using System.Runtime.CompilerServices;
    using Core;

    public struct Select<T, U, TDelegate, TEnumerator>
        : IRefEnumerable<U>
        where TDelegate : IValueDelegate<T, U>
        where TEnumerator : IRefEnumerable<T>
    {
        internal Select(TEnumerator prev, TDelegate map)
        {
            this.prev = prev;
            this.map = map;
            Current = default!;
        }

        private TEnumerator prev;
        private readonly TDelegate map;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            var res = prev.MoveNext();
            if (res)
                Current = map.Invoke(prev.Current);
            return res;
        }

        public U Current { get; private set; }

        public Select<T, U, TDelegate, TEnumerator> GetEnumerator() => this;
    }
}