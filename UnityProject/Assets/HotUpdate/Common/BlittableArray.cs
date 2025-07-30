using System;
using System.Runtime.CompilerServices;
using HotUpdate;

internal class BlittableArray<T> : HostArray<T> where T : unmanaged
  {
    internal unsafe T* _addr;
    private ulong _gcHandle;
    private int lockRefCount;

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe void M_SetValue_Fast(
      int handleId,
      int index,
      void* valAddr,
      int size);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe void M_GetValue_Fast(
      int handleId,
      int index,
      void* valAddr,
      int size);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern unsafe void* M_PinAndGetArrayAddr(int handleId, out ulong gcHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_FreePinnedArray(ulong gcHandle);

    public override unsafe void Lock()
    {
      ++this.lockRefCount;
      if (this.lockRefCount != 1)
        return;
      this._addr = (T*) BlittableArray<T>.M_PinAndGetArrayAddr(this._monoHandle, out this._gcHandle);
    }

    public override unsafe void Unlock()
    {
      if (this.lockRefCount == 1)
      {
        --this.lockRefCount;
        this._addr = (T*) null;
        BlittableArray<T>.M_FreePinnedArray(this._gcHandle);
        this._gcHandle = 0UL;
      }
      else
        --this.lockRefCount;
    }

    public override unsafe T this[int index]
    {
      get
      {
        if ((IntPtr) this._addr != IntPtr.Zero)
          return this._addr[index];
        T obj;
        void* valAddr = (void*) &obj;
        BlittableArray<T>.M_GetValue_Fast(this._monoHandle, index, valAddr, sizeof (T));
        return obj;
      }
      set
      {
        if ((IntPtr) this._addr != IntPtr.Zero)
        {
          this._addr[index] = value;
        }
        else
        {
          void* valAddr = (void*) &value;
          BlittableArray<T>.M_SetValue_Fast(this._monoHandle, index, valAddr, sizeof (T));
        }
      }
    }

    public override Array Resize(int newSize)
    {
      BlittableArray<T> dstArr = HostArray<T>.Create(newSize) as BlittableArray<T>;
      BlittableArray<T>.Copy(this, 0, dstArr, 0, this.Length);
      return (Array) dstArr;
    }

    public static unsafe bool Copy(
      BlittableArray<T> srcArr,
      int srcIdx,
      BlittableArray<T> dstArr,
      int dstIdx,
      int length)
    {
      if (srcArr == null || dstArr == null || srcIdx > srcArr.Length - length || dstIdx > dstArr.Length - length)
        return false;
      srcArr.Lock();
      dstArr.Lock();
      long num = (long) (length * sizeof (T));
      Buffer.MemoryCopy((void*) (srcArr._addr + srcIdx), (void*) (dstArr._addr + dstIdx), num, num);
      srcArr.Unlock();
      dstArr.Unlock();
      return true;
    }

    public static unsafe bool Copy(
      BlittableArray<T> srcArr,
      int srcIdx,
      T[] dstArr,
      int dstIdx,
      int length)
    {
      if (srcArr == null || dstArr == null || srcIdx > srcArr.Length - length || dstIdx > dstArr.Length - length)
        return false;
      srcArr.Lock();
      fixed (T* objPtr = dstArr)
      {
        long num = (long) (length * sizeof (T));
        Buffer.MemoryCopy((void*) (srcArr._addr + srcIdx), (void*) (objPtr + dstIdx), num, num);
      }
      srcArr.Unlock();
      return true;
    }

    public static unsafe bool Copy(
      T[] srcArr,
      int srcIdx,
      BlittableArray<T> dstArr,
      int dstIdx,
      int length)
    {
      if (srcArr == null || dstArr == null || srcIdx > srcArr.Length - length || dstIdx > dstArr.Length - length)
        return false;
      dstArr.Lock();
      fixed (T* objPtr = srcArr)
      {
        long num = (long) (length * sizeof (T));
        Buffer.MemoryCopy((void*) (objPtr + srcIdx), (void*) (dstArr._addr + dstIdx), num, num);
      }
      dstArr.Unlock();
      return true;
    }

    public override T[] ToMonoArray()
    {
      int length = this.Length;
      T[] dstArr = new T[length];
      BlittableArray<T>.Copy(this, 0, dstArr, 0, length);
      return dstArr;
    }

    public override void FromMonoArray(T[] monoArray, int srcIndex, int dstIndex, int length) => BlittableArray<T>.Copy(monoArray, srcIndex, this, dstIndex, length);
  }