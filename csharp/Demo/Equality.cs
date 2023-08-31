using UnitConverter;

namespace Demo
{
    [DemoClass]
    public class Equality
    {
        [DemoMethod]
        public static void EqualityExample()
        {
            var m_squared = Area.Create(Metre.Create(Unitary.Create()));
            var km_squared = Area.Create(Metre.Create(Kilo.Create()));

            var area = NumericValueWithUnit<Area>.Create(1e6, m_squared);
            var area2 = NumericValueWithUnit<Area>.Create(1, km_squared);
            compare(area,area2,1e-6);

            var square_ft = Area.Create(Foot.Create());
            area2.Convert(square_ft);
            //expect area == area2
            compare(area,area2,1e-6);

            var different = NumericValueWithUnit<Area>.Create(10, square_ft);
            //expect area != different
            compare(area,different,1e-6);
            //expect area2 != different
            compare(area2,different,1e-6);
        }

        static void compare<T>(NumericValueWithUnit<T> obj1, NumericValueWithUnit<T> obj2, double eps) 
            where T : IConvertFromBase, IConvertToBase, IUnitDescription
        {
            var equality = obj1.Equals(obj2, DoubleExtension.AreEqual, eps) ? "is equal to" : "is NOT equal to";
            Console.WriteLine($"{obj1.Value} {obj1.Unit.Symbol} {equality} {obj2.Value} {obj2.Unit.Symbol}");
        }
    }
}