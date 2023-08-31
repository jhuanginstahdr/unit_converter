namespace UnitConverter
{
    /// <summary>
    /// Interface for providing additional information for unit's name and symbol
    /// </summary>
    public interface IUnitDescription
    {
        //name of the unit
        string Name { get; }

        //abbreviation or symbol for this measurement
        string Symbol { get; }
    }

    /// <summary>
    /// Responsible for conversion to the implied base type
    /// </summary>
    public interface IConvertToBase
    {
        //function that maps the current unit type to its base type (inverse of FromBase)
        internal double ToBase(double value);
    }

    /// <summary>
    /// Responsible for conversion from the implied base type
    /// </summary>
    public interface IConvertFromBase
    {
        //function that maps the base unit type to the current type (inverse of ToBase)
        internal double FromBase(double value);
    }
}