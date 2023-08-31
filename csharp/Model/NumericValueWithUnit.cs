namespace UnitConverter
{
    /// <summary>
    /// A container of both the value and its unit
    /// </summary>
    public sealed class NumericValueWithUnit<UnitType> where UnitType : IConvertFromBase, IConvertToBase
    {
        public static NumericValueWithUnit<UnitType> Create(double value, UnitType unit)
        {
            if (unit is null)
            {
                throw new ArgumentNullException($"{nameof(unit)} cannot be null");
            }
            return new NumericValueWithUnit<UnitType>(value, unit);
        }

        private NumericValueWithUnit(double value, UnitType unit)
        {
            Value = value;
            Unit = unit;
        }

        public double Value { get; private set; }

        public UnitType Unit { get; private set; }

        /// <summary>
        /// Converting and updating Value and Unit from current Unit to target unit
        /// </summary>
        public double Convert(UnitType target_unit)
        {
            Value = target_unit.FromBase(Unit.ToBase(Value));
            Unit = target_unit;
            return Value;
        }
    }

    public static class NumericValueWithUnitExtension
    {
        //Quantities of different units should be comparable
        //e.g. 1 metre == 1000 millimetre
        //     1 metre == 1 metre
        public static bool Equals<UnitType>
        (
            this NumericValueWithUnit<UnitType> a, 
            NumericValueWithUnit<UnitType> b, 
            DoubleExtension.EqualityDelegate comparer, 
            double eps
        )
            where UnitType : IConvertFromBase, IConvertToBase
        {
            return comparer(a.Unit.ToBase(a.Value), b.Unit.ToBase(b.Value), eps);
        }
    }

    /// <summary>
    /// Utility of comparing two double values with error tolerance defined by eps
    /// </summary>
    public static class DoubleExtension
    {
        public delegate bool EqualityDelegate(double a, double b, double epsilon);

        /// <summary>
        /// Checks whether |a-b| <= epsilon
        /// </summary>
        /// <remarks>
        /// A negative epsilon is considered 0.0
        /// </remarks>
        public static bool AreEqual(double a, double b, double epsilon)
        {
            if (epsilon <= 0.0)
            {
                return a == b;
            }
            return Math.Abs(a - b) <= epsilon;
        }
    }
}