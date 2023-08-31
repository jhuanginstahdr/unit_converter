#ifndef INTERFACE_H
#define INTERFACE_H

#include <iostream>
#include <vector>
#include <string>

using namespace std;

namespace unit_converter
{
    /// <summary>
    /// A concept definition that is required to constrain the type by requiring
    /// - to_base method
    /// - from_base method
    /// </summary>
    template <typename T>
    concept convertible_to_and_from_base = requires(T unit, double value)
    {
        { unit.to_base(value) } -> std::same_as<double>;
        { unit.from_base(value) } -> std::same_as<double>;
    };

    /// <summary>
    /// A concept definition that is required to constrain the type by requiring
    /// - get_name
    /// - get_symb
    /// </summary>
    template <typename T>
    concept unit_descriptor = requires(T unit, double value)
    {
        { unit.get_name() } -> std::same_as<std::string>;
        { unit.get_symb() } -> std::same_as<std::string>;
    };

    /// <summary>
    /// A concept that has constraints from both
    /// - convertible_to_and_from_base
    /// - unit_descriptor
    /// </summary>
    template <typename T>
    concept convertible_to_and_from_base_with_descriptor 
        = convertible_to_and_from_base<T> && unit_descriptor<T>;

    /// <summary>
    /// interface that gets name of unit, and symbol of unit
    /// </summary>
    class unit_description
    {
    public:
        //returns the name of the unit
        virtual std::string get_name() = 0;
        //returns the symbol of the unit
        virtual std::string get_symb() = 0;
    };

    /// <summary>
    /// interface that requires the function from_base
    /// </summary>
    class convert_from_base
    {
    public:
        //return the value converting from base
        virtual double from_base(double base) = 0;
    };

    /// <summary>
    /// interface that requires the function to_base
    /// </summary>
    class convert_to_base
    {
    public:
        //return the base value converted from value
        virtual double to_base(double value) = 0;
    };
}

#endif
