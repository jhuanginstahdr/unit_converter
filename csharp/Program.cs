using System.Reflection;
using Demo;

namespace UnitConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // get all assemblies in the current application domain
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // get methods from the assemblies that satisfy the requirements:
            // 1. public and static
            // 2. requires 0 input arguments
            // 3. return type of void
            // 4. attaches attribute "DemoMethod" under a class attached with attribute "DemoClass"
            var demo_methods = assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetCustomAttributes(true).OfType<DemoClass>().Any())
                .SelectMany(type => type.GetMethods(BindingFlags.Static | BindingFlags.Public))
                .Where(method => method.GetParameters().Length == 0)
                .Where(method => method.ReturnType == typeof(void))
                .Where(method => method.GetCustomAttributes(false).OfType<DemoMethod>().Any());

            // the demo methods are expected to be parameterless
            foreach (var method in demo_methods)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{method.Name}");
                Console.ResetColor();
                method.Invoke(null,null);
                Console.WriteLine();
            }

            Console.ResetColor();
        }
    }
}

