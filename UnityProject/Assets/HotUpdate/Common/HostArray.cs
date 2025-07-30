using System;
public interface IPlaceHolder
{
}

namespace HotUpdate
{
    public class HostArray<T> : Array
    {
        internal HostArray()
            : base((IPlaceHolder) null)
        {
        }

        public override Array Resize(int newSize)
        {
            HostArray<T> hostArray = HostArray<T>.Create(newSize);
            this.CopyTo((Array) hostArray, 0);
            return (Array) hostArray;
        }

        public virtual T this[int index]
        {
            get => (T) this.GetValue(index);
            set => this.SetValue((object) value, index);
        }

        public static HostArray<T> Create(int length) => System.Array.CreateInstance(typeof (T), length) as HostArray<T>;

        public static HostArray<T> Create(HostArray<int> lengths, HostArray<int> lowerBounds) => Array.CreateInstance(typeof (T), (Array) lengths, (Array) lowerBounds) as HostArray<T>;

        public virtual T[] ToMonoArray()
        {
            int length = this.Length;
            T[] monoArray = new T[length];
            for (int index = 0; index < length; ++index)
                monoArray[index] = this[index];
            return monoArray;
        }

        public virtual void FromMonoArray(T[] monoArray, int srcIndex, int dstIndex, int length)
        {
            if (srcIndex + length > monoArray.Length || dstIndex + length > this.Length)
                throw new ArgumentOutOfRangeException("srcIndex + length or dstIndex + length overflow");
            for (int index = 0; index < length; ++index)
                this[index + dstIndex] = monoArray[index + srcIndex];
        }

        public virtual void Lock()
        {
        }

        public virtual void Unlock()
        {
        }
    }   
}
