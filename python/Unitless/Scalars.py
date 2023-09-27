from Model.Interfaces import NumericUnitModifier

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