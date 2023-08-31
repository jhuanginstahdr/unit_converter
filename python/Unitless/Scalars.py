import os
import sys

cur_dir = os.path.dirname(os.path.abspath(__file__))
rel_dir = os.path.join(cur_dir, '..\\Model')

# Add the path of the directory containing the file you want to import
sys.path.append(rel_dir)

from Interfaces import NumericUnitModifier

class Unitary(NumericUnitModifier):
    @property
    def Name(self) -> str:
        return f""

    @property
    def Symbol(self) -> str:
        return f""

    def ToBase(self, v) -> float:
        return 1

    def FromBase(self, v) -> float:
        return 1
    
class Kilo(NumericUnitModifier):
    @property
    def Name(self) -> str:
        return f"Kilo"

    @property
    def Symbol(self) -> str:
        return f"k"

    def ToBase(self, v) -> float:
        return v*1e3

    def FromBase(self, v) -> float:
        return v/1e3