using UnityEngine;

public static class ScreenUtil
{
   private static Rect _customeSafeArea;
   private static bool _customeFlag = false;
   public static Rect GetSafeArea()
   {
       if (_customeFlag)
       {
           return _customeSafeArea;
       }
       return Screen.safeArea;
   }
   
   public static void SetSafeArea(Rect rect)
   {
       _customeFlag = true;
       _customeSafeArea = rect;
   }
}