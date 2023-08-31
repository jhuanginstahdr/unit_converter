namespace UnitConverter
{
    /// <summary>
    /// Example of a composite unit type based on a specific length unit
    /// </summary>
    public sealed class Area : IConvertFromBase, IConvertToBase, IUnitDescription
    {
        public static Area Create(ILengthUnit length_unit)
        {
            if (length_unit is null)
            {
                throw new ArgumentNullException($"{nameof(length_unit)} cannot be null");
            }
            return new Area(length_unit);
        }

        private Area(ILengthUnit length_unit)
        {
            _length_unit = length_unit;
        }

        /// <summary>
        /// Required specification of the type of length unit
        /// </summary>
        private readonly ILengthUnit _length_unit;

        public string Name => $"{_length_unit.Name} Squared";

        public string Symbol => $"{_length_unit.Symbol}^2";

        /// <summary>
        /// Conversion to metre squared
        /// </summary>
        public double ToBase(double value) => _length_unit.ToBase(value)*_length_unit.ToBase(1);

        /// <summary>
        /// Conversion from metre squared
        /// </summary>
        public double FromBase(double value) => _length_unit.FromBase(value)*_length_unit.FromBase(1);
    }
}