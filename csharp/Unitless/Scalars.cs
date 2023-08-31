namespace UnitConverter
{
    /// <summary>
    /// A modifier that does not alter value
    /// </summary>
    public sealed class Unitary : INumericUnitModifier
    {
        public static INumericUnitModifier Create() => new Unitary();

        private Unitary() { }

        public string Name => "";

        public string Symbol => Name;

        public double ToBase(double value) => value;

        public double FromBase(double value) => value;
    }

    /// <summary>
    /// Scales the value by 1e3
    /// </summary>
    public sealed class Kilo : INumericUnitModifier
    {
        public static INumericUnitModifier Create() => new Kilo();

        private Kilo() { }

        public string Name => nameof(Kilo);

        public string Symbol => "k";

        /// <summary>
        /// Scales the value by 1e3
        /// </summary>
        public double ToBase(double value) => 1e3*value;

        /// <summary>
        /// Scales the value 1e-3
        /// </summary>
        public double FromBase(double value) => value/1e3;
    }

    /// <summary>
    /// Scales the value by 1e6
    /// </summary>
    public sealed class Mega : INumericUnitModifier
    {
        public static INumericUnitModifier Create() => new Mega();

        private Mega() { }

        public string Name => nameof(Mega);

        public string Symbol => "M";

        /// <summary>
        /// Scales the value by 1e6
        /// </summary>
        public double ToBase(double value) => 1e6*value;

        /// <summary>
        /// Scales the value by 1e-6
        /// </summary>
        public double FromBase(double value) => value/1e6;
    }

    /// <summary>
    /// Scales the value by 1e-3
    /// </summary>
    public sealed class Milli : INumericUnitModifier
    {
        public static INumericUnitModifier Create() => new Milli();
        
        private Milli() { }

        public string Name => nameof(Milli);

        public string Symbol => "m";

        /// <summary>
        /// Scales the value by 1e-3
        /// </summary>
        public double ToBase(double value) => 1e-3*value;

        /// <summary>
        /// Scales the value by 1e3
        /// </summary>
        public double FromBase(double value) => value/1e-3;
    }

    /// <summary>
    /// Scales the value by 1e-6
    /// </summary>
    public sealed class Micro : INumericUnitModifier
    {
        public static INumericUnitModifier Create() => new Micro();

        private Micro() { }

        public string Name => nameof(Micro);

        public string Symbol => "u";

        /// <summary>
        /// Scales the value by 1e-6
        /// </summary>
        public double ToBase(double value) => 1e-6*value;

        /// <summary>
        /// Scales the value by 1e6
        /// </summary>
        public double FromBase(double value) => value/1e-6;
    }
}