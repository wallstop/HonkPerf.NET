﻿// Copyright (c) Angouri 2021.
// This file from HonkPerf.NET project is MIT-licensed.
// Read more: https://github.com/asc-community/HonkPerf.NET

namespace HonkPerf.NET.RefLinq
{
    public static partial class ActiveLinqExtensions
    {
        // private struct SumDelegate<T> : IValueDelegate<T, T, T> where T : unmanaged
        // {
        //     public T Invoke(T a, T b) => Scalar.Add(a, b);
        // }
        //
        // public static T Sum<T, TEnumerator>(this RefLinqEnumerable<T, TEnumerator> seq)
        //     where TEnumerator : IRefEnumerable<T>
        //     where T : unmanaged
        //     => seq.Aggregate(Scalar<T>.Zero, new SumDelegate<T>());
    }
}
