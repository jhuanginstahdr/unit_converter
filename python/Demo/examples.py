from Units.LengthUnits import Metre, Foot
from Unitless.Scalars import Kilo
from Model.NumericUnitTypes import LengthUnit, TimeUnit
from Model.NumericValueWithUnit import NumericValueWithUnit    

def Examples() -> None:
    #scalar modifiers
    kilo = Kilo()

    #units
    metre = Metre()
    kilometre = Metre(kilo)
    foot = Foot()

    value = NumericValueWithUnit(10,metre,LengthUnit)
    print(value.Convert(kilometre))
    print(value.Convert(foot))
    print(value.Convert(metre))

    # error should be raised because metre is not a TimeUnit
    try:
        invalid = NumericValueWithUnit(10,metre,TimeUnit)
    except TypeError as type_error:
        print(f"{type_error}")

    # error should be raised because '10' is not a numeric value
    try:
        invalid = NumericValueWithUnit('10',metre,TimeUnit)
    except TypeError as type_error:
        print(f"{type_error}")

    # error should be raised because LengthUnit cannot convert to a different unit type or a unitless quantity
    try:
        value.Convert(kilo)
    except TypeError as type_error:
        print(f"{type_error}")

    # error should be raised because metre is not a valid unitless modifier
    try:
        invalid = Metre(metre)
    except TypeError as type_error:
        print(f"{type_error}")