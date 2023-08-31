using UnitConverter;

namespace Demo
{
    //Alias
    using DistanceOverTime = RateOfChange<ILengthUnit>;
    using AreaOverTime = RateOfChange<Area>;
    
    [DemoClass]
    public class Conversions
    {
        [DemoMethod]
        public static void LengthExample()
        {
            var foot = Foot.Create();
            var kilometre = Metre.Create(Kilo.Create());

            var length = NumericValueWithUnit<ILengthUnit>.Create(10,foot);
            convert_and_print(length, kilometre);
        }

        [DemoMethod]
        public static void RateOfChangeExample()
        {
            var metre = Metre.Create(Unitary.Create());
            var foot = Foot.Create();
            var millisecond = Second.Create(Milli.Create());
            var minute = Minute.Create();

            var metre_per_millisecond = DistanceOverTime.Create(metre, millisecond);
            var feet_per_minute = DistanceOverTime.Create(foot, minute);

            var distance_over_time = NumericValueWithUnit<DistanceOverTime>.Create(10, metre_per_millisecond);

            convert_and_print(distance_over_time, feet_per_minute);

            var area = Area.Create(metre);
            var area_over_time = AreaOverTime.Create(area, minute);

            //code below does not compile if you try to convert between incompatible units
            #if false
            convert_and_print(distance_over_time, area_over_time);
            #endif
        }

        static void convert_and_print<UnitType>(NumericValueWithUnit<UnitType> obj, UnitType other) 
            where UnitType : IConvertFromBase, IConvertToBase, IUnitDescription
        {
            Console.WriteLine($"{obj.Value} {obj.Unit.Name} to {obj.Convert(other)} {obj.Unit.Name}");
        }
    }
}