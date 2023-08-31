namespace UnitConverter
{
    //Defines an explicit interface for unitless modifiers such as kilo etc
    public interface INumericUnitModifier : IConvertFromBase, IConvertToBase, IUnitDescription { }

    //Defines an interface that differentiates length unit types from others
    public interface ILengthUnit : IConvertFromBase, IConvertToBase, IUnitDescription { }

    //Defines an interface that differentiates time unit types from others
    public interface ITimeUnit : IConvertFromBase, IConvertToBase, IUnitDescription { }

    //Defines an interface that differentiates temperature unit types from others
    public interface ITemperatureUnit : IConvertFromBase, IConvertToBase, IUnitDescription { }

    //Defines an interface that differentiates mass unit types from others
    public interface IMassUnit : IConvertFromBase, IConvertToBase, IUnitDescription { }
}