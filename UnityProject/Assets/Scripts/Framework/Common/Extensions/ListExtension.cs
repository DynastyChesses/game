using System.Collections.Generic;

public static class ListExtension
{
    public static void RemoveAtBySwap<T>(this List<T> list, int index)
    {
        int lastIndex = list.Count - 1;
        list[index] = list[lastIndex];
        list.RemoveAt(lastIndex);
    }

    public static bool RemoveBySwap<T>(this List<T> list, T item)
    {
        var index = list.IndexOf(item);
        if (index < 0)
        {
            return false;
        }
        
        list.RemoveAtBySwap(index);
        return true;
    }
}
