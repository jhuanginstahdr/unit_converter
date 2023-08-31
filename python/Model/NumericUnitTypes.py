from Interfaces import ConvertToBase,ConvertFromBase

"""
Defines base class for length units
"""
class LengthUnit(ConvertToBase,ConvertFromBase):
    pass

"""
Defines base class for time units
"""
class TimeUnit(ConvertToBase,ConvertFromBase):
    pass

"""
Defines base class for temperatur units
"""
class TemperatureUnit(ConvertToBase,ConvertFromBase):
    pass

"""
Defines base class for Mass units
"""
class MassUnit(ConvertToBase,ConvertFromBase):
    pass
