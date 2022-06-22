namespace Core.Provider;

public static class InterfaceDumperExtension
{
    public static Type[] DumpInterface(this Type type)
    {
        if (type.IsClass == false) throw new NotSupportedException($"{type} must be a class but it is not!");

        var allInterfaces = new HashSet<Type>(type.GetInterfaces());

        var toRemove = new HashSet<Type>();
        foreach (var implementedByOtherInterfaces in allInterfaces.SelectMany(implementedByMostDerivedClass =>
                     implementedByMostDerivedClass.GetInterfaces())) toRemove.Add(implementedByOtherInterfaces);

        allInterfaces.ExceptWith(toRemove);

        return allInterfaces.ToArray();
    }
}