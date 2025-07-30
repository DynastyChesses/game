using System;

namespace HotUpdate.osP1.ValueObject.Interface
{
    public interface IFetch<T>
    {
        public T Item { get; set; }
    }
}