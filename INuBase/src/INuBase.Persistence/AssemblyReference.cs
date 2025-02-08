using System.Reflection;

namespace INuBase.Persistence;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
