from Units.LengthUnits import Metre, Foot
from Unitless.Scalars import Kilo
from Model.NumericUnitTypes import LengthUnit, TimeUnit
from Model.NumericValueWithUnit import NumericValueWithUnit    
from logging import info, error, basicConfig

def Examples() -> None:
    import logging
    basicConfig(level=logging.INFO)

    def verbose_conversion(value, unit):
        info(f'Convert from {value.Value} {value.Unit.Symbol} to {value.Convert(unit)} {unit.Symbol}')

    #scalar modifiers
    kilo = Kilo()

    #units
    metre = Metre()
    kilometre = Metre(kilo)
    foot = Foot()

    value = NumericValueWithUnit(10,metre,LengthUnit)
    verbose_conversion(value, kilometre)
    verbose_conversion(value, foot)
    verbose_conversion(value, metre)

    # error should be raised because metre is not a TimeUnit
    try:
        _ = NumericValueWithUnit(10,metre,TimeUnit)
    except TypeError as type_error:
        error(f"{type_error}")

    # error should be raised because '10' is not a numeric value
    try:
        _ = NumericValueWithUnit('10',metre,TimeUnit)
    except TypeError as type_error:
        error(f"{type_error}")

    # error should be raised because LengthUnit cannot convert to a different unit type or a unitless quantity
    try:
        value.Convert(kilo)
    except TypeError as type_error:
        error(f"{type_error}")

    # error should be raised because metre is not a valid unitless modifier
    try:
        invalid = Metre(metre)
    except TypeError as type_error:
        error(f"{type_error}")