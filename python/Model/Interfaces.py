from abc import ABC, abstractmethod

"""
Responsible for providing:
1. Name of Unit in string
2. Symbol of Unit in string
"""
class UnitDescription(ABC):
    @property
    @abstractmethod
    def Name(self) -> str:
        pass

    @property
    @abstractmethod
    def Symbol(self) -> str:
        pass

"""
Responsible for:
- Converting a value to "base" value => e.g. f(value)
"""
class ConvertToBase(ABC):
    @abstractmethod
    def ToBase(self, value: float) -> float:
        pass

"""
Responsible for:
- Converting a value from "base" value => e.g. f-1(value)
"""
class ConvertFromBase(ABC):
    @abstractmethod
    def FromBase(self, value: float) -> float:
        pass

"""
For explicit implementation of unit modifiers (scalars) (to differentiate itself from NumericUnitType)
"""
class NumericUnitModifier(UnitDescription,ConvertToBase,ConvertFromBase):
    pass