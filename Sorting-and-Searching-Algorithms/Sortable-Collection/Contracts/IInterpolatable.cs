namespace Sortable_Collection.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IInterpolatable <T>
    {
        int Interpolate(IList<T> list, int low, int high, T needle);
    }
}