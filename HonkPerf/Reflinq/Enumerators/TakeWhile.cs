﻿// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq.Enumerators
{
    using Core;

    public struct TakeWhile<T, TEnumerator, TDelegate>
        : IRefEnumerable<T>
        where TEnumerator : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
    {
        private TEnumerator en;
        private TDelegate pred;

        public TakeWhile(TEnumerator en, TDelegate pred)
        {
            this.en = en;
            this.pred = pred;
            Current = default!;
        }

        public bool MoveNext()
        {
            return en.MoveNext()
                   && pred.Invoke(Current = en.Current);
        }

        public T Current { get; private set; }
    }

}