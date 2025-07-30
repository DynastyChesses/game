using System.Collections;
using System;
using System.Runtime.CompilerServices;

public abstract class Array
  {
    internal int _monoHandle;
    private static readonly string HOST_TYPE = "System.Array";

    public abstract Array Resize(int newSize);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance0_Impl(Type arg0, long[] arg1);

    private static Array F_CreateInstance0_Impl_Wrapper(Type arg0, long[] arg1) => Array.F_CreateInstance0_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_CopyTo1_Impl(int self, Array arg0, int arg1);

    private static void M_CopyTo1_Impl_Wrapper(Array self, Array arg0, int arg1) => Array.M_CopyTo1_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_Clone2_Impl(int self);

    private static object M_Clone2_Impl_Wrapper(Array self) => Array.M_Clone2_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_BinarySearch3_Impl(Array arg0, object arg1);

    private static int F_BinarySearch3_Impl_Wrapper(Array arg0, object arg1) => Array.F_BinarySearch3_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Copy4_Impl(Array arg0, Array arg1, long arg2);

    private static void F_Copy4_Impl_Wrapper(Array arg0, Array arg1, long arg2) => Array.F_Copy4_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Copy5_Impl(
      Array arg0,
      long arg1,
      Array arg2,
      long arg3,
      long arg4);

    private static void F_Copy5_Impl_Wrapper(
      Array arg0,
      long arg1,
      Array arg2,
      long arg3,
      long arg4)
    {
      Array.F_Copy5_Impl(arg0, arg1, arg2, arg3, arg4);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_CopyTo6_Impl(int self, Array arg0, long arg1);

    private static void M_CopyTo6_Impl_Wrapper(Array self, Array arg0, long arg1) => Array.M_CopyTo6_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern long M_GetLongLength7_Impl(int self, int arg0);

    private static long M_GetLongLength7_Impl_Wrapper(Array self, int arg0) => Array.M_GetLongLength7_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue8_Impl(int self, long arg0);

    private static object M_GetValue8_Impl_Wrapper(Array self, long arg0) => Array.M_GetValue8_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue9_Impl(int self, long arg0, long arg1);

    private static object M_GetValue9_Impl_Wrapper(Array self, long arg0, long arg1) => Array.M_GetValue9_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue10_Impl(int self, long arg0, long arg1, long arg2);

    private static object M_GetValue10_Impl_Wrapper(Array self, long arg0, long arg1, long arg2) => Array.M_GetValue10_Impl(self._monoHandle, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue11_Impl(int self, long[] arg0);

    private static object M_GetValue11_Impl_Wrapper(Array self, long[] arg0) => Array.M_GetValue11_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_BinarySearch12_Impl(Array arg0, int arg1, int arg2, object arg3);

    private static int F_BinarySearch12_Impl_Wrapper(Array arg0, int arg1, int arg2, object arg3) => Array.F_BinarySearch12_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_BinarySearch13_Impl(Array arg0, object arg1, IComparer arg2);

    private static int F_BinarySearch13_Impl_Wrapper(Array arg0, object arg1, IComparer arg2) => Array.F_BinarySearch13_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_BinarySearch14_Impl(
      Array arg0,
      int arg1,
      int arg2,
      object arg3,
      IComparer arg4);

    private static int F_BinarySearch14_Impl_Wrapper(
      Array arg0,
      int arg1,
      int arg2,
      object arg3,
      IComparer arg4)
    {
      return Array.F_BinarySearch14_Impl(arg0, arg1, arg2, arg3, arg4);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_IndexOf15_Impl(Array arg0, object arg1);

    private static int F_IndexOf15_Impl_Wrapper(Array arg0, object arg1) => Array.F_IndexOf15_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_IndexOf16_Impl(Array arg0, object arg1, int arg2);

    private static int F_IndexOf16_Impl_Wrapper(Array arg0, object arg1, int arg2) => Array.F_IndexOf16_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_IndexOf17_Impl(Array arg0, object arg1, int arg2, int arg3);

    private static int F_IndexOf17_Impl_Wrapper(Array arg0, object arg1, int arg2, int arg3) => Array.F_IndexOf17_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_LastIndexOf18_Impl(Array arg0, object arg1);

    private static int F_LastIndexOf18_Impl_Wrapper(Array arg0, object arg1) => Array.F_LastIndexOf18_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_LastIndexOf19_Impl(Array arg0, object arg1, int arg2);

    private static int F_LastIndexOf19_Impl_Wrapper(Array arg0, object arg1, int arg2) => Array.F_LastIndexOf19_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int F_LastIndexOf20_Impl(Array arg0, object arg1, int arg2, int arg3);

    private static int F_LastIndexOf20_Impl_Wrapper(Array arg0, object arg1, int arg2, int arg3) => Array.F_LastIndexOf20_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Reverse21_Impl(Array arg0);

    private static void F_Reverse21_Impl_Wrapper(Array arg0) => Array.F_Reverse21_Impl(arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Reverse22_Impl(Array arg0, int arg1, int arg2);

    private static void F_Reverse22_Impl_Wrapper(Array arg0, int arg1, int arg2) => Array.F_Reverse22_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue23_Impl(int self, object arg0, long arg1);

    private static void M_SetValue23_Impl_Wrapper(Array self, object arg0, long arg1) => Array.M_SetValue23_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue24_Impl(int self, object arg0, long arg1, long arg2);

    private static void M_SetValue24_Impl_Wrapper(Array self, object arg0, long arg1, long arg2) => Array.M_SetValue24_Impl(self._monoHandle, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue25_Impl(
      int self,
      object arg0,
      long arg1,
      long arg2,
      long arg3);

    private static void M_SetValue25_Impl_Wrapper(
      Array self,
      object arg0,
      long arg1,
      long arg2,
      long arg3)
    {
      Array.M_SetValue25_Impl(self._monoHandle, arg0, arg1, arg2, arg3);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue26_Impl(int self, object arg0, long[] arg1);

    private static void M_SetValue26_Impl_Wrapper(Array self, object arg0, long[] arg1) => Array.M_SetValue26_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort27_Impl(Array arg0);

    private static void F_Sort27_Impl_Wrapper(Array arg0) => Array.F_Sort27_Impl(arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort28_Impl(Array arg0, int arg1, int arg2);

    private static void F_Sort28_Impl_Wrapper(Array arg0, int arg1, int arg2) => Array.F_Sort28_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort29_Impl(Array arg0, IComparer arg1);

    private static void F_Sort29_Impl_Wrapper(Array arg0, IComparer arg1) => Array.F_Sort29_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort30_Impl(Array arg0, int arg1, int arg2, IComparer arg3);

    private static void F_Sort30_Impl_Wrapper(Array arg0, int arg1, int arg2, IComparer arg3) => Array.F_Sort30_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort31_Impl(Array arg0, Array arg1);

    private static void F_Sort31_Impl_Wrapper(Array arg0, Array arg1) => Array.F_Sort31_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort32_Impl(Array arg0, Array arg1, IComparer arg2);

    private static void F_Sort32_Impl_Wrapper(Array arg0, Array arg1, IComparer arg2) => Array.F_Sort32_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort33_Impl(Array arg0, Array arg1, int arg2, int arg3);

    private static void F_Sort33_Impl_Wrapper(Array arg0, Array arg1, int arg2, int arg3) => Array.F_Sort33_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Sort34_Impl(
      Array arg0,
      Array arg1,
      int arg2,
      int arg3,
      IComparer arg4);

    private static void F_Sort34_Impl_Wrapper(
      Array arg0,
      Array arg1,
      int arg2,
      int arg3,
      IComparer arg4)
    {
      Array.F_Sort34_Impl(arg0, arg1, arg2, arg3, arg4);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern IEnumerator M_GetEnumerator35_Impl(int self);

    private static IEnumerator M_GetEnumerator35_Impl_Wrapper(Array self) => Array.M_GetEnumerator35_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int M_GetLength36_Impl(int self, int arg0);

    private static int M_GetLength36_Impl_Wrapper(Array self, int arg0) => Array.M_GetLength36_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int M_GetLowerBound37_Impl(int self, int arg0);

    private static int M_GetLowerBound37_Impl_Wrapper(Array self, int arg0) => Array.M_GetLowerBound37_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue38_Impl(int self, int[] arg0);

    private static object M_GetValue38_Impl_Wrapper(Array self, int[] arg0) => Array.M_GetValue38_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue39_Impl(int self, object arg0, int[] arg1);

    private static void M_SetValue39_Impl_Wrapper(Array self, object arg0, int[] arg1) => Array.M_SetValue39_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int M_GetUpperBound40_Impl(int self, int arg0);

    private static int M_GetUpperBound40_Impl_Wrapper(Array self, int arg0) => Array.M_GetUpperBound40_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue41_Impl(int self, int arg0);

    private static object M_GetValue41_Impl_Wrapper(Array self, int arg0) => Array.M_GetValue41_Impl(self._monoHandle, arg0);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue42_Impl(int self, int arg0, int arg1);

    private static object M_GetValue42_Impl_Wrapper(Array self, int arg0, int arg1) => Array.M_GetValue42_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object M_GetValue43_Impl(int self, int arg0, int arg1, int arg2);

    private static object M_GetValue43_Impl_Wrapper(Array self, int arg0, int arg1, int arg2) => Array.M_GetValue43_Impl(self._monoHandle, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue44_Impl(int self, object arg0, int arg1);

    private static void M_SetValue44_Impl_Wrapper(Array self, object arg0, int arg1) => Array.M_SetValue44_Impl(self._monoHandle, arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue45_Impl(int self, object arg0, int arg1, int arg2);

    private static void M_SetValue45_Impl_Wrapper(Array self, object arg0, int arg1, int arg2) => Array.M_SetValue45_Impl(self._monoHandle, arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_SetValue46_Impl(
      int self,
      object arg0,
      int arg1,
      int arg2,
      int arg3);

    private static void M_SetValue46_Impl_Wrapper(
      Array self,
      object arg0,
      int arg1,
      int arg2,
      int arg3)
    {
      Array.M_SetValue46_Impl(self._monoHandle, arg0, arg1, arg2, arg3);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance47_Impl(Type arg0, int arg1);

    private static Array F_CreateInstance47_Impl_Wrapper(Type arg0, int arg1) => Array.F_CreateInstance47_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance48_Impl(Type arg0, int arg1, int arg2);

    private static Array F_CreateInstance48_Impl_Wrapper(Type arg0, int arg1, int arg2) => Array.F_CreateInstance48_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance49_Impl(Type arg0, int arg1, int arg2, int arg3);

    private static Array F_CreateInstance49_Impl_Wrapper(Type arg0, int arg1, int arg2, int arg3) => Array.F_CreateInstance49_Impl(arg0, arg1, arg2, arg3);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance50_Impl(Type arg0, int[] arg1);

    private static Array F_CreateInstance50_Impl_Wrapper(Type arg0, int[] arg1) => Array.F_CreateInstance50_Impl(arg0, arg1);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern Array F_CreateInstance51_Impl(Type arg0, Array arg1, Array arg2);

    private static Array F_CreateInstance51_Impl_Wrapper(Type arg0, Array arg1, Array arg2) => Array.F_CreateInstance51_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Clear52_Impl(Array arg0, int arg1, int arg2);

    private static void F_Clear52_Impl_Wrapper(Array arg0, int arg1, int arg2) => Array.F_Clear52_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Copy53_Impl(Array arg0, Array arg1, int arg2);

    private static void F_Copy53_Impl_Wrapper(Array arg0, Array arg1, int arg2) => Array.F_Copy53_Impl(arg0, arg1, arg2);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_Copy54_Impl(
      Array arg0,
      int arg1,
      Array arg2,
      int arg3,
      int arg4);

    private static void F_Copy54_Impl_Wrapper(
      Array arg0,
      int arg1,
      Array arg2,
      int arg3,
      int arg4)
    {
      Array.F_Copy54_Impl(arg0, arg1, arg2, arg3, arg4);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void F_ConstrainedCopy55_Impl(
      Array arg0,
      int arg1,
      Array arg2,
      int arg3,
      int arg4);

    private static void F_ConstrainedCopy55_Impl_Wrapper(
      Array arg0,
      int arg1,
      Array arg2,
      int arg3,
      int arg4)
    {
      Array.F_ConstrainedCopy55_Impl(arg0, arg1, arg2, arg3, arg4);
    }

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern void M_Initialize56_Impl(int self);

    private static void M_Initialize56_Impl_Wrapper(Array self) => Array.M_Initialize56_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern long G_LongLength_Impl(int self);

    private static long G_LongLength_Impl_Wrapper(Array self) => Array.G_LongLength_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool G_IsFixedSize_Impl(int self);

    private static bool G_IsFixedSize_Impl_Wrapper(Array self) => Array.G_IsFixedSize_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool G_IsReadOnly_Impl(int self);

    private static bool G_IsReadOnly_Impl_Wrapper(Array self) => Array.G_IsReadOnly_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern bool G_IsSynchronized_Impl(int self);

    private static bool G_IsSynchronized_Impl_Wrapper(Array self) => Array.G_IsSynchronized_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object G_SyncRoot_Impl(int self);

    private static object G_SyncRoot_Impl_Wrapper(Array self) => Array.G_SyncRoot_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int G_Length_Impl(int self);

    private static int G_Length_Impl_Wrapper(Array self) => Array.G_Length_Impl(self._monoHandle);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern int G_Rank_Impl(int self);

    private static int G_Rank_Impl_Wrapper(Array self) => Array.G_Rank_Impl(self._monoHandle);

    static Array()
    {
      int num = (int) NativeUtility.RegisterScriptClass(Array.HOST_TYPE, typeof (Array));
    }

    internal Array(IPlaceHolder val) => this._monoHandle = 0;

    public static Array CreateInstance(Type elementType, params long[] lengths) => Array.F_CreateInstance0_Impl_Wrapper(elementType, lengths);

    public virtual void CopyTo(Array array, int index) => Array.M_CopyTo1_Impl_Wrapper(this, array, index);

    public virtual object Clone() => Array.M_Clone2_Impl_Wrapper(this);

    public static int BinarySearch(Array array, object value) => Array.F_BinarySearch3_Impl_Wrapper(array, value);

    public static void Copy(Array sourceArray, Array destinationArray, long length) => Array.F_Copy4_Impl_Wrapper(sourceArray, destinationArray, length);

    public static void Copy(
      Array sourceArray,
      long sourceIndex,
      Array destinationArray,
      long destinationIndex,
      long length)
    {
      Array.F_Copy5_Impl_Wrapper(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    public void CopyTo(Array array, long index) => Array.M_CopyTo6_Impl_Wrapper(this, array, index);

    public long GetLongLength(int dimension) => Array.M_GetLongLength7_Impl_Wrapper(this, dimension);

    public object GetValue(long index) => Array.M_GetValue8_Impl_Wrapper(this, index);

    public object GetValue(long index1, long index2) => Array.M_GetValue9_Impl_Wrapper(this, index1, index2);

    public object GetValue(long index1, long index2, long index3) => Array.M_GetValue10_Impl_Wrapper(this, index1, index2, index3);

    public object GetValue(params long[] indices) => Array.M_GetValue11_Impl_Wrapper(this, indices);

    public static int BinarySearch(Array array, int index, int length, object value) => Array.F_BinarySearch12_Impl_Wrapper(array, index, length, value);

    public static int BinarySearch(Array array, object value, IComparer comparer) => Array.F_BinarySearch13_Impl_Wrapper(array, value, comparer);

    public static int BinarySearch(
      Array array,
      int index,
      int length,
      object value,
      IComparer comparer)
    {
      return Array.F_BinarySearch14_Impl_Wrapper(array, index, length, value, comparer);
    }

    public static int IndexOf(Array array, object value) => Array.F_IndexOf15_Impl_Wrapper(array, value);

    public static int IndexOf(Array array, object value, int startIndex) => Array.F_IndexOf16_Impl_Wrapper(array, value, startIndex);

    public static int IndexOf(Array array, object value, int startIndex, int count) => Array.F_IndexOf17_Impl_Wrapper(array, value, startIndex, count);

    public static int LastIndexOf(Array array, object value) => Array.F_LastIndexOf18_Impl_Wrapper(array, value);

    public static int LastIndexOf(Array array, object value, int startIndex) => Array.F_LastIndexOf19_Impl_Wrapper(array, value, startIndex);

    public static int LastIndexOf(Array array, object value, int startIndex, int count) => Array.F_LastIndexOf20_Impl_Wrapper(array, value, startIndex, count);

    public static void Reverse(Array array) => Array.F_Reverse21_Impl_Wrapper(array);

    public static void Reverse(Array array, int index, int length) => Array.F_Reverse22_Impl_Wrapper(array, index, length);

    public void SetValue(object value, long index) => Array.M_SetValue23_Impl_Wrapper(this, value, index);

    public void SetValue(object value, long index1, long index2) => Array.M_SetValue24_Impl_Wrapper(this, value, index1, index2);

    public void SetValue(object value, long index1, long index2, long index3) => Array.M_SetValue25_Impl_Wrapper(this, value, index1, index2, index3);

    public void SetValue(object value, params long[] indices) => Array.M_SetValue26_Impl_Wrapper(this, value, indices);

    public static void Sort(Array array) => Array.F_Sort27_Impl_Wrapper(array);

    public static void Sort(Array array, int index, int length) => Array.F_Sort28_Impl_Wrapper(array, index, length);

    public static void Sort(Array array, IComparer comparer) => Array.F_Sort29_Impl_Wrapper(array, comparer);

    public static void Sort(Array array, int index, int length, IComparer comparer) => Array.F_Sort30_Impl_Wrapper(array, index, length, comparer);

    public static void Sort(Array keys, Array items) => Array.F_Sort31_Impl_Wrapper(keys, items);

    public static void Sort(Array keys, Array items, IComparer comparer) => Array.F_Sort32_Impl_Wrapper(keys, items, comparer);

    public static void Sort(Array keys, Array items, int index, int length) => Array.F_Sort33_Impl_Wrapper(keys, items, index, length);

    public static void Sort(Array keys, Array items, int index, int length, IComparer comparer) => Array.F_Sort34_Impl_Wrapper(keys, items, index, length, comparer);

    public virtual IEnumerator GetEnumerator() => Array.M_GetEnumerator35_Impl_Wrapper(this);

    public int GetLength(int dimension) => Array.M_GetLength36_Impl_Wrapper(this, dimension);

    public int GetLowerBound(int dimension) => Array.M_GetLowerBound37_Impl_Wrapper(this, dimension);

    public object GetValue(params int[] indices) => Array.M_GetValue38_Impl_Wrapper(this, indices);

    public void SetValue(object value, params int[] indices) => Array.M_SetValue39_Impl_Wrapper(this, value, indices);

    public int GetUpperBound(int dimension) => Array.M_GetUpperBound40_Impl_Wrapper(this, dimension);

    public object GetValue(int index) => Array.M_GetValue41_Impl_Wrapper(this, index);

    public object GetValue(int index1, int index2) => Array.M_GetValue42_Impl_Wrapper(this, index1, index2);

    public object GetValue(int index1, int index2, int index3) => Array.M_GetValue43_Impl_Wrapper(this, index1, index2, index3);

    public void SetValue(object value, int index) => Array.M_SetValue44_Impl_Wrapper(this, value, index);

    public void SetValue(object value, int index1, int index2) => Array.M_SetValue45_Impl_Wrapper(this, value, index1, index2);

    public void SetValue(object value, int index1, int index2, int index3) => Array.M_SetValue46_Impl_Wrapper(this, value, index1, index2, index3);

    public static Array CreateInstance(Type elementType, int length) => Array.F_CreateInstance47_Impl_Wrapper(elementType, length);

    public static Array CreateInstance(Type elementType, int length1, int length2) => Array.F_CreateInstance48_Impl_Wrapper(elementType, length1, length2);

    public static Array CreateInstance(Type elementType, int length1, int length2, int length3) => Array.F_CreateInstance49_Impl_Wrapper(elementType, length1, length2, length3);

    public static Array CreateInstance(Type elementType, params int[] lengths) => Array.F_CreateInstance50_Impl_Wrapper(elementType, lengths);

    public static Array CreateInstance(Type elementType, Array lengths, Array lowerBounds) => Array.F_CreateInstance51_Impl_Wrapper(elementType, lengths, lowerBounds);

    public static void Clear(Array array, int index, int length) => Array.F_Clear52_Impl_Wrapper(array, index, length);

    public static void Copy(Array sourceArray, Array destinationArray, int length) => Array.F_Copy53_Impl_Wrapper(sourceArray, destinationArray, length);

    public static void Copy(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length)
    {
      Array.F_Copy54_Impl_Wrapper(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    public static void ConstrainedCopy(
      Array sourceArray,
      int sourceIndex,
      Array destinationArray,
      int destinationIndex,
      int length)
    {
      Array.F_ConstrainedCopy55_Impl_Wrapper(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

    public void Initialize() => Array.M_Initialize56_Impl_Wrapper(this);

    public long LongLength => Array.G_LongLength_Impl_Wrapper(this);

    public virtual bool IsFixedSize => Array.G_IsFixedSize_Impl_Wrapper(this);

    public virtual bool IsReadOnly => Array.G_IsReadOnly_Impl_Wrapper(this);

    public virtual bool IsSynchronized => Array.G_IsSynchronized_Impl_Wrapper(this);

    public virtual object SyncRoot => Array.G_SyncRoot_Impl_Wrapper(this);

    public int Length => Array.G_Length_Impl_Wrapper(this);

    public int Rank => Array.G_Rank_Impl_Wrapper(this);
  }
