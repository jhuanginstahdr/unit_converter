# unit_converter
This project aims to demonstrate various coding design concepts via the problem of "unit conversion".

The same unit conversion code design is implemented with the following languages (more to be added) 
- C++
- C#
- Python

The conversion between compatible units is based on the concept of conversion to an 'implied' base type.
For example: for all length units, any compatible length type such as metre and feet would have 'metre'
as their base type. This allows for n-to-1 to-base conversions and 1-to-n from-base conversions where new
unit types can be added without being aware of all other compatible units.
