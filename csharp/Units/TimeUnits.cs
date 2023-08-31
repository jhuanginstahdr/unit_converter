namespace UnitConverter
{
    /// <summary>
    /// Example of a time unit type in seconds 
    /// </summary>
    public sealed class Second : ITimeUnit
    {
        public static ITimeUnit Create(INumericUnitModifier modifier)
        {
            if (modifier is null)
            {
                throw new ArgumentNullException($"{nameof(modifier)} cannot be null");
            }
            return new Second(modifier);
        }

        private Second(INumericUnitModifier modifier)
        {
            _modifier = modifier;
        }

        private readonly INumericUnitModifier _modifier;

        public string Name => $"{_modifier.Name}{nameof(Second)}";

        public string Symbol => $"{_modifier.Symbol}s";

        /// <summary>
        /// Convert to second accounting for modifier
        /// </summary>
        public double ToBase(double value) => value*_modifier.ToBase(1);

        /// <summary>
        /// Convert from second accounting for modifier
        /// </summary>
        public double FromBase(double value) => value*_modifier.FromBase(1);
    }

    /// <summary>
    /// Example of a time unit type in minutes
    /// </summary>
    public sealed class Minute : ITimeUnit
    {
        public static ITimeUnit Create() => new Minute();

        private Minute() { }

        public string Name => nameof(Minute);

        public string Symbol => "min";

        /// <summary>
        /// Convert to second
        /// </summary>
        public double ToBase(double value) => value*60.0;

        /// <summary>
        /// Convert from second
        /// </summary>
        public double FromBase(double value) => value/60.0;        
    }

    /// <summary>
    /// Example of a time unit type in days
    /// </summary>
    public sealed class Day : ITimeUnit
    {
        public static ITimeUnit Create() => new Day();

        private Day() { }

        public string Name => nameof(Day);

        public string Symbol => "d";

        /// <summary>
        /// Convert to second
        /// </summary>
        public double ToBase(double value) => value*86400.0;

        /// <summary>
        /// Convert from second
        /// </summary>
        public double FromBase(double value) => value/86400.0;           
    }
}