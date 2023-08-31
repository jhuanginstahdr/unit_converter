namespace Demo
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DemoClass : Attribute {}

    [AttributeUsage(AttributeTargets.Method)]
    public class DemoMethod : Attribute {}
}