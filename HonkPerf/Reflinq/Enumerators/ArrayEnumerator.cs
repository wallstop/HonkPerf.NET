﻿// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators
{
    using System.Runtime.CompilerServices;

    public struct ArrayEnumerator<T> : IRefEnumerable<T>
    {
        private readonly T[] array;
        private int curr;

        public ArrayEnumerator(T[] array)
        {
            this.array = array;
            this.curr = -1;
            Current = default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool MoveNext()
        {
            curr++;
            if (curr < array.Length)
            {
                Current = array[curr];
                return true;
            }

            return false;
        }

        public T Current { get; private set; }
    }
}