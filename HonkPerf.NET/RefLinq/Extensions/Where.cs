﻿namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, Where<T, PureValueDelegate<T, bool>, TPrevious>> RefWhere<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, bool> pred)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred)));

    public static RefLinqEnumerable<T, Where<T, CapturingValueDelegate<T, TCapture, bool>, TPrevious>> RefWhere<T, TCapture, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, Func<T, TCapture, bool> pred, TCapture capture)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, new(pred, capture)));

    public static RefLinqEnumerable<T, Where<T, TDelegate, TPrevious>> RefWhere<T, TCapture, TDelegate, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, TDelegate pred)
        where TPrevious : IRefEnumerable<T>
        where TDelegate : IValueDelegate<T, bool>
        => new(new(prev.enumerator, pred));
}