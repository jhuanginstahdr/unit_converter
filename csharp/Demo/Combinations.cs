using UnitConverter;

namespace Demo
{
    [DemoClass]
    public class Combinations
    {
        //some length and some time units could depend on scalars
        //all area units could depend on length units
        //all rate of change units could depend on length, area and time units

        static IList<INumericUnitModifier> _scalars = new INumericUnitModifier[]
        {
            Unitary.Create(),
            Kilo.Create(),
            Mega.Create(),
            Milli.Create(),
            Micro.Create()
        };

        static IList<ILengthUnit> _length_units = _scalars.SelectMany(scalar => new ILengthUnit[] { Metre.Create(scalar) })
                                                          .Concat(Enumerable.Repeat(Foot.Create(),1))
                                                          .ToArray();

        static IList<ITimeUnit> _time_units = _scalars.SelectMany(scalar => new ITimeUnit[] { Second.Create(scalar) })
                                                      .Concat(new ITimeUnit[] {Minute.Create(),Day.Create()})
                                                      .ToArray();

        [DemoMethod]
        public static void CreateLengthUnits()
        {
            foreach (var unit in _length_units)
            {
                Console.WriteLine($"{unit.Name}");
            }
        }

        [DemoMethod]
        public static void CreateTimeUnits()
        {
            foreach (var unit in _time_units)
            {
                Console.WriteLine($"{unit.Name}");
            }
        }

        [DemoMethod]
        public static void CreateSpeedUnits()
        {
            var speed_units = _length_units.SelectMany(length_unit => _time_units.Select(time => RateOfChange<ILengthUnit>.Create(length_unit, time)));
            foreach (var unit in speed_units)
            {
                Console.WriteLine($"{unit.Name}");
            }          
        }

        [DemoMethod]
        public static void CreateAreaUnits()
        {
            var area_units = _length_units.Select(Area.Create);
            foreach (var unit in area_units)
            {
                Console.WriteLine($"{unit.Name}");
            }                 
        }
    }
}