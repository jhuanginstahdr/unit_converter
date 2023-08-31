namespace UnitConverter
{
    /// <summary>
    /// Example of any quantity over time
    /// </summary>
    /// <remarks>
    /// Higher order change such as Acceleration can also be defined based on RateOfChange
    /// </remarks>
    public sealed class RateOfChange<QuantityUnit> : IConvertFromBase, IConvertToBase, IUnitDescription
        where QuantityUnit : IConvertFromBase, IConvertToBase, IUnitDescription
    {
        public static RateOfChange<QuantityUnit> Create(QuantityUnit quantity_unit, ITimeUnit time_unit)
        {
            if (quantity_unit is null || time_unit is null)
            {
                throw new ArgumentNullException($"{nameof(quantity_unit)} or {nameof(time_unit)} cannot be null");
            }
            return new RateOfChange<QuantityUnit>(quantity_unit, time_unit);
        }

        private RateOfChange(QuantityUnit quantity_unit, ITimeUnit time_unit)
        {
            _quantity_unit = quantity_unit;
            _time_unit = time_unit;
        }

        public string Name => $"{_quantity_unit.Name} Per {_time_unit.Name}";

        public string Symbol => $"{_quantity_unit.Symbol}/{_time_unit.Symbol}";

        /// <summary>
        /// Dependency on a specific unit for the measure of quantity
        /// </summary>
        private readonly QuantityUnit _quantity_unit;

        /// <summary>
        /// Dependency on some measure of time
        /// </summary>
        private readonly ITimeUnit _time_unit;

        /// <summary>
        /// Convert to quantity per second
        /// </summary>
        public double ToBase(double value) => _quantity_unit.ToBase(value)/_time_unit.ToBase(1);

        /// <summary>
        /// Convert from quantity per second
        /// </summary>
        public double FromBase(double value) => _quantity_unit.FromBase(value)/_time_unit.FromBase(1);
    }
}