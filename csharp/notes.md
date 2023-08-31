
//gathering information on how units are used and the associated features

//unit conversion primary functions
//cross unit conversion, for example, imperial to metric
//scalar modifier, for example, metre to kilometre
//each unit also has a "symbol" associated which is made up of the "base" unit name + "scalar" modifier name

//system layer
//how are elements that depend on units get notified of changes?
//conversion in unit could
//1. only change the unit type but not value
//2. change the value + unit type with the intended function that converts from one to another
//3. change the value with preferred defaults => instead of convert a value using the supposed formula, use a predetermined constant instead

//example: how does a new feature like block model integrate with units?

//stress type: force over area
//time
//rate: measure over time

//force (in newton), length (gives area, volume) and time (in seconds and scalar*seconds)

//units can be created out of combination of more elementary measurements
//combination is defined as some mathmatical relationship between the measurements

//product of (scalar_i)(measurement_i) => perhaps this can be hardcoded? but this can be an formula dependency itself
//user input is a scalar => a unit-less measurement

//covnert to a reference measurement then convert back


//possible extension is to have this designed in a text file like json and construct any type from that instead of coding them manually
//this requires better abstraction in code setup which require further functionalities to support the consumption of text-parsing to formula + symbolic based expressions for evaluation

{
    Fahrenheit
    {
        Name : Metre
        Symbol : m
        ToBase : (x - 32) * 5 / 9
        FromBase : x * 9 / 5 + 32
    }
}