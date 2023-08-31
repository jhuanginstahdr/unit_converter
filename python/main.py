import os
import sys

cur_dir = os.path.dirname(os.path.abspath(__file__))
type_dir = os.path.join(cur_dir, 'Model')
units_dir = os.path.join(cur_dir, 'Units')
unitless_dir = os.path.join(cur_dir, 'Unitless')

# Add the path of the directory containing the file you want to import
sys.path.append(units_dir)
sys.path.append(unitless_dir)

from LengthUnits import Metre, Foot
from Scalars import Kilo
from NumericUnitTypes import LengthUnit, TimeUnit
from NumericValueWithUnit import NumericValueWithUnit

if __name__ == "__main__":
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




    

