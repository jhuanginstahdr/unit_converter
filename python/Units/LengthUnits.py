import os
import sys

cur_dir = os.path.dirname(os.path.abspath(__file__))
mod_dir = os.path.join(cur_dir, '..\\Model')
uni_dir = os.path.join(cur_dir, '..\\Unitless')

# Add the path of the directory containing the file you want to import
sys.path.append(mod_dir)
sys.path.append(uni_dir)

from Interfaces import NumericUnitModifier
from NumericUnitTypes import LengthUnit
from Scalars import Unitary

"""
Definition of unit 'Metre'
"""
class Metre(LengthUnit):
    def __init__(self, m=None):
        if m is None:
            m = Unitary()
        if not isinstance(m, NumericUnitModifier):
            raise TypeError(f"Cannot specify {type(m)} as the scalar modifier of {Metre}")
        self._mod = m

    @property
    def Name(self) -> str:
        return f"{self._mod.Name}Metre"

    @property
    def Symbol(self) -> str:
        return f"{self._mod.Symbol}m"

    def ToBase(self, v) -> float:
        return v * self._mod.ToBase(1)

    def FromBase(self, v) -> float:
        return v * self._mod.FromBase(1)

"""
Definition of unit 'Foot'
"""    
class Foot(LengthUnit):
    def __init__(self, m=None):
        if m is None:
            m = Unitary()
        if not isinstance(m, NumericUnitModifier):
            raise TypeError(f"Cannot specify {type(m)} as the scalar modifier of {Foot}")
        self._mod = m

    @property
    def Name(self) -> str:
        return f"{self._mod.Name}Foot"

    @property
    def Symbol(self) -> str:
        return f"{self._mod.Symbol}ft"

    def ToBase(self, v) -> float:
        return v * 0.3048 * self._mod.ToBase(1)

    def FromBase(self, v) -> float:
        return v / 0.3048 * self._mod.FromBase(1)
