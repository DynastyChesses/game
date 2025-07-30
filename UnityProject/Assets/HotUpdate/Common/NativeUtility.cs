using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using HotUpdate;

public static class NativeUtility
  {
    private static Type _arrayGenericType = typeof (HostArray<>);
    private static Type _arrayBlittableGenericType = typeof (BlittableArray<>);
    private static Type _nativeNameAttrType = typeof (NativeNameAttribute);
    private static Dictionary<Type, Type> _arrayTypeMap = new Dictionary<Type, Type>(10);
    private static Dictionary<Type, string> _rTypeFullNameCache = new Dictionary<Type, string>();
    private static Dictionary<MemberInfo, NativeUtility.MethodHandle> _methodIdCache = new Dictionary<MemberInfo, NativeUtility.MethodHandle>();
    private static Dictionary<MemberInfo, NativeUtility.FieldHandle> _fieldIdCache = new Dictionary<MemberInfo, NativeUtility.FieldHandle>();

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern RegisterState RegisterScriptClass(
      string hostTypeFullName,
      Type scriptTypeObj);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object InvokeImplNoCache(
      object target,
      Type declaredType,
      string methodName,
      object[] args,
      Type[] argTypes,
      NativeUtility.ArgModifier[] argModifiers,
      out int methodId);

    [MethodImpl(MethodImplOptions.InternalCall)]
    private static extern object InvokeImpl(
      object target,
      object[] args,
      int methodId,
      byte writeback);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern int CreateInstance(
      object nativeSelf,
      Type declaredType,
      params object[] args);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern object FieldOpImplNoCache(
      object target,
      Type declaredType,
      string fieldName,
      object value,
      byte isSetFlag,
      out int fieldId);

    [MethodImpl(MethodImplOptions.InternalCall)]
    public static extern object FieldOpImpl(
      object target,
      object value,
      int fieldId,
      byte isSetFlag);

    public static void AddArrayType(Type elementType, Type arrayType) => NativeUtility._arrayTypeMap.Add(elementType, arrayType);

    public static Array InstanceArray(Type elementType, int handleId, bool blittable)
    {
      Type type1;
      if (!NativeUtility._arrayTypeMap.TryGetValue(elementType, out type1))
      {
        Type type2;
        if (!blittable)
          type2 = NativeUtility._arrayGenericType.MakeGenericType(elementType);
        else
          type2 = NativeUtility._arrayBlittableGenericType.MakeGenericType(elementType);
        type1 = type2;
        NativeUtility._arrayTypeMap.Add(elementType, type1);
      }
      Array instance = Activator.CreateInstance(type1, true) as Array;
      instance._monoHandle = handleId;
      return instance;
    }

    public static string GetReflectionTypeHostFullName(Type type)
    {
      string typeHostFullName;
      if (!NativeUtility._rTypeFullNameCache.TryGetValue(type, out typeHostFullName))
      {
        typeHostFullName = NativeUtility.DoGetReflectionTypeHostFullName(type);
        NativeUtility._rTypeFullNameCache.Add(type, typeHostFullName);
      }
      return typeHostFullName;
    }

    private static string GetArrayTypeName(string fullName)
    {
      if (fullName.EndsWith("]") || !fullName.Contains(", "))
        return fullName + "[]";
      int startIndex1 = fullName.LastIndexOf(']') + 1;
      int startIndex2 = fullName.IndexOf(", ", startIndex1);
      return fullName.Insert(startIndex2, "[]");
    }

    public static string DoGetReflectionTypeHostFullName(Type type)
    {
      if (type.IsDefined(NativeUtility._nativeNameAttrType))
        return type.GetCustomAttribute<NativeNameAttribute>().name;
      if (type.IsArray)
        return NativeUtility.GetArrayTypeName(NativeUtility.GetReflectionTypeHostFullName(type.GetElementType()));
      if (!type.IsGenericType)
        return type.FullName;
      Type[] genericArguments = type.GetGenericArguments();
      Type genericTypeDefinition = type.GetGenericTypeDefinition();
      if (genericTypeDefinition == NativeUtility._arrayGenericType || genericTypeDefinition == NativeUtility._arrayBlittableGenericType)
        return NativeUtility.GetArrayTypeName(NativeUtility.GetReflectionTypeHostFullName(genericArguments[0]));
      string str = type.Namespace;
      StringBuilder stringBuilder = new StringBuilder();
      if (string.IsNullOrEmpty(str))
      {
        stringBuilder.Append(type.Name);
      }
      else
      {
        stringBuilder.Append(str);
        stringBuilder.Append('.');
        stringBuilder.Append(type.Name);
      }
      stringBuilder.Append('[');
      int index = 0;
      for (int length = genericArguments.Length; index < length; ++index)
      {
        if (index > 0)
          stringBuilder.Append(",[");
        else
          stringBuilder.Append('[');
        stringBuilder.Append(NativeUtility.GetReflectionTypeHostFullName(genericArguments[index]));
        stringBuilder.Append(']');
      }
      stringBuilder.Append(']');
      return stringBuilder.ToString();
    }

    public static void Dispose(IDisposable disposable) => disposable?.Dispose();

    private static Type RemoveRefAndToConstraintType(Type type) => type.IsByRef ? NativeUtility.RemoveRefAndToConstraintType(type.GetElementType()) : type;

    public static T Invoke<T>(object target, MethodBase scriptMethod, object[] args)
    {
      NativeUtility.MethodHandle methodHandle = (NativeUtility.MethodHandle) null;
      lock (NativeUtility._methodIdCache)
        NativeUtility._methodIdCache.TryGetValue((MemberInfo) scriptMethod, out methodHandle);
      object obj;
      if (methodHandle != null)
      {
        if (methodHandle.id < 0)
          return default (T);
        obj = NativeUtility.InvokeImpl(target, args, methodHandle.id, methodHandle.writeback ? (byte) 1 : (byte) 0);
      }
      else
      {
        bool flag = false;
        int methodId;
        if (args == null || args.Length == 0)
        {
          obj = NativeUtility.InvokeImplNoCache(target, scriptMethod.DeclaringType, scriptMethod.Name, (object[]) null, (Type[]) null, (NativeUtility.ArgModifier[]) null, out methodId);
        }
        else
        {
          ParameterInfo[] parameters = scriptMethod.GetParameters();
          Type[] argTypes = new Type[parameters.Length];
          NativeUtility.ArgModifier[] argModifiers = new NativeUtility.ArgModifier[parameters.Length];
          int index = 0;
          for (int length = parameters.Length; index < length; ++index)
          {
            Type parameterType = parameters[index].ParameterType;
            argTypes[index] = NativeUtility.RemoveRefAndToConstraintType(parameterType);
            argModifiers[index] = NativeUtility.ArgModifier.Normal;
            if (parameterType.IsByRef)
            {
              argModifiers[index] |= NativeUtility.ArgModifier.Ref;
              flag = true;
            }
            if (parameterType.IsArray)
              argModifiers[index] |= NativeUtility.ArgModifier.Array;
            else if (parameterType.IsGenericType)
            {
              Type genericTypeDefinition = parameterType.GetGenericTypeDefinition();
              if (genericTypeDefinition == NativeUtility._arrayGenericType || genericTypeDefinition == NativeUtility._arrayBlittableGenericType)
              {
                argTypes[index] = parameterType.GetGenericArguments()[0];
                argModifiers[index] |= NativeUtility.ArgModifier.Array;
              }
            }
          }
          obj = NativeUtility.InvokeImplNoCache(target, scriptMethod.DeclaringType, scriptMethod.Name, args, argTypes, argModifiers, out methodId);
        }
        methodHandle = new NativeUtility.MethodHandle()
        {
          id = methodId,
          writeback = flag,
          valueTypeRet = typeof (T).IsValueType
        };
        lock (NativeUtility._methodIdCache)
          NativeUtility._methodIdCache.Add((MemberInfo) scriptMethod, methodHandle);
      }
      return !methodHandle.valueTypeRet || obj != null ? (T) obj : default (T);
    }

    public static T GetField<T>(object target, MethodBase fieldOpMethod, string fieldName) => NativeUtility.FieldOp<T>(target, fieldOpMethod, fieldName, (object) null, false);

    public static void SetField(
      object target,
      MethodBase fieldOpMethod,
      string fieldName,
      object value)
    {
      NativeUtility.FieldOp<object>(target, fieldOpMethod, fieldName, value, true);
    }

    private static T FieldOp<T>(
      object target,
      MethodBase fieldOpMethod,
      string fieldName,
      object value,
      bool isSet)
    {
      NativeUtility.FieldHandle fieldHandle;
      lock (NativeUtility._fieldIdCache)
        NativeUtility._fieldIdCache.TryGetValue((MemberInfo) fieldOpMethod, out fieldHandle);
      object obj;
      if (fieldHandle != null)
      {
        if (fieldHandle.id < 0)
          return default (T);
        obj = NativeUtility.FieldOpImpl(target, value, fieldHandle.id, isSet ? (byte) 1 : (byte) 0);
      }
      else
      {
        int fieldId;
        obj = NativeUtility.FieldOpImplNoCache(target, fieldOpMethod.DeclaringType, fieldName, value, isSet ? (byte) 1 : (byte) 0, out fieldId);
        fieldHandle = new NativeUtility.FieldHandle()
        {
          id = fieldId,
          valueTypeRet = typeof (T).IsValueType
        };
        lock (NativeUtility._fieldIdCache)
          NativeUtility._fieldIdCache.Add((MemberInfo) fieldOpMethod, fieldHandle);
      }
      return !fieldHandle.valueTypeRet || obj != null ? (T) obj : default (T);
    }

    [Flags]
    private enum ArgModifier
    {
      Normal = 0,
      Ref = 1,
      Array = 2,
    }

    private class MethodHandle
    {
      public int id;
      public bool writeback;
      public bool valueTypeRet;
    }

    private class FieldHandle
    {
      public int id;
      public bool valueTypeRet;
    }
  }