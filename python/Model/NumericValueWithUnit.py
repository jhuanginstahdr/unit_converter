from .Interfaces import ConvertToBase, ConvertFromBase
from typing import TypeVar, Union

# A hint for T to be the type or subtype of ConvertToBase or ConvertFromBase
T = TypeVar('T', bound=Union[ConvertToBase, ConvertFromBase])

"""
Object that carries both the information of value (quantity) and the specific unit
Extra logic on the unit type is required to ensure valid conversions between units of the same type
"""
class NumericValueWithUnit:
    def __init__(self, value: float, unit: T, unit_type):
        # allow numeric types like int float and complex
        if not isinstance(value, (int, float, complex)):
            raise TypeError(f'{type(value)} is not any of the types: {int} {float} {complex}')
        # make sure the unit object agrees with the unit_type specified
        if not issubclass(type(unit), unit_type):
            raise TypeError(f"{type(unit)} is not a subclass of {unit_type}")
        self._value = value
        self._unit = unit
        self._unit_type = unit_type

    @property
    def Value(self) -> float:
        return self._value

    @property
    def Unit(self) -> T:
        return self._unit

    def Convert(self, to: T) -> float:
        # make sure the units for conversion are of the same type
        if not issubclass(type(to), self._unit_type):
            raise TypeError(f"Cannot convert from {type(to)} to {self._unit_type}")
        if isinstance(self._unit, type(to)):
            # No conversion required
            return self._value

        self._value = to.FromBase(self._unit.ToBase(self._value))
        self._unit = to
        return self._value