
using System;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Struct)]
public sealed class NativeNameAttribute : Attribute
{
    public string name;

    public NativeNameAttribute(string name) => this.name = name;
}