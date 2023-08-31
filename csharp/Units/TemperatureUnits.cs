namespace UnitConverter
{
    /// <summary>
    /// Example of temperature unit type in Kelvin
    /// </summary>
    public sealed class Kelvin : ITemperatureUnit
    {
        public static ITemperatureUnit Create() => new Kelvin();

        private Kelvin() { }

        public string Name => nameof(Kelvin);

        public string Symbol => "K";

        /// <summary>
        /// No conversion as it is converting to Kelvin
        /// </summary>
        public double ToBase(double value) => value;

        /// <summary>
        /// No conversion as it is converting from Kelvin
        /// </summary>
        public double FromBase(double value) => value;
    }

    /// <summary>
    /// Example of temperature unit type in Celcius
    /// </summary>
    public sealed class Celcius : ITemperatureUnit
    {
        public static ITemperatureUnit Create() => new Celcius();

        private Celcius() { }

        public string Name => nameof(Celcius);

        public string Symbol => "C";

        /// <summary>
        /// Convert to Kelvin
        /// </summary>
        public double ToBase(double v) => v+273.15;

        /// <summary>
        /// Convert from Kelvin
        /// </summary>
        public double FromBase(double v) => v-273.15;        
    }

    /// <summary>
    /// Example of temperature unit type in Fahrenheit
    /// </summary>
    public sealed class Fahrenheit : ITemperatureUnit
    {
        public static ITemperatureUnit Create() => new Fahrenheit();

        private Fahrenheit() { }

        public string Name => nameof(Fahrenheit);

        public string Symbol => "F";

        /// <summary>
        /// Convert to Kelvin
        /// </summary>
        public double ToBase(double v) => (v-32.0)*5.0/9.0+273.15;

        /// <summary>
        /// Convert from Kelvin
        /// </summary>
        public double FromBase(double v) => (v-273.15)*9.0/5.0+32.0;
    }
}