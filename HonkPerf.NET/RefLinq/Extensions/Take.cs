﻿namespace HonkPerf.NET.RefLinq;

static partial class LazyLinqExtensions
{
    public static RefLinqEnumerable<T, Take<T, TPrevious>> Take<T, TPrevious>(this RefLinqEnumerable<T, TPrevious> prev, int toTake)
        where TPrevious : IRefEnumerable<T>
        => new(new(prev.enumerator, toTake));

}