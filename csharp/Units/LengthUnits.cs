namespace UnitConverter
{
    /// <summary>
    /// Example of a metric length unit type in metres which accepts a scalar modifier such as kilo
    /// </summary>
    public sealed class Metre : ILengthUnit
    {
        public static ILengthUnit Create(INumericUnitModifier modifier)
        {
            if (modifier is null) throw new ArgumentNullException($"{nameof(modifier)} cannot be null");
            return new Metre(modifier);
        }

        private Metre(INumericUnitModifier modifier)
        {
            _modifier = modifier;
        }

        /// <summary>
        /// Scalar modifier allowed for Metre
        /// </summary>
        private readonly INumericUnitModifier _modifier;

        public string Name => $"{_modifier.Name}{nameof(Metre)}";

        public string Symbol => $"{_modifier.Symbol}m";

        /// <summary>
        /// Conversion to metre accounting for the modifier
        /// </summary>
        public double ToBase(double value) => value*_modifier.ToBase(1);

        /// <summary>
        /// Conversion from metre accounting for the modifier
        /// </summary>
        public double FromBase(double value) => value*_modifier.FromBase(1);
    }

    /// <summary>
    /// Example of an imperical length unit type in feet
    /// </summary>
    public sealed class Foot : ILengthUnit
    {
        public static ILengthUnit Create()
        {
            return new Foot();
        }

        private Foot() {}

        public string Name => $"{nameof(Foot)}";

        public string Symbol => $"ft";

        /// <summary>
        /// Conversion to metre
        /// </summary>
        public double ToBase(double value) => 0.3048*value;

        /// <summary>
        /// Conversion from metre
        /// </summary>
        public double FromBase(double value) => value/0.3048;
    }
}