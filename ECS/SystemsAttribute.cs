using System;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Interface,
    AllowMultiple = true,
    Inherited = true
)]
public class SystemsAttribute : Attribute
{
    public SystemOrder SystemOrder { get; private set; }

    public SystemsAttribute(SystemOrder order = SystemOrder.On) => SystemOrder = order;
}

public enum SystemOrder
{
    Pre,
    On,
    Post
}
