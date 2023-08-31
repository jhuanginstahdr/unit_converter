#ifndef VALUE_WTH_UNIT
#define VALUE_WTH_UNIT

#include <concepts>
#include <memory>
#include "interfaces.h"

namespace unit_converter
{
    /// <summary>
    /// A container of value + unit where 
    /// - value is currently in double (could change to a generic type)
    /// - the type of unit must satisfy the concept 'convertible_to_and_from_base'
    /// </summary>
    template <convertible_to_and_from_base T>
    class value_with_unit final
    {
    public:
        /// <summary>
        /// Static method that returns the instanced object with nullptr checks
        /// </summary>
        static std::shared_ptr<value_with_unit<T>> create(double input_value, std::shared_ptr<T> unit_ptr)
        {
            if (!unit_ptr) throw std::invalid_argument("unit_ptr cannot be nullptr");
            return std::shared_ptr<value_with_unit<T>>(new value_with_unit<T>(input_value, unit_ptr));
        }
        /// <summary>
        /// return and store the converted 'value' based on the specified unit type. The unit type is also updated
        /// </summary>
        double convert(std::shared_ptr<T> to)
        {
            value = to->from_base(unit->to_base(value));
            unit = to;
            return value;
        }
        /// <summary>
        /// unitless quantity that can be accessed and modified externally
        /// </summary>
        double value;

    private:
        /// <summary>
        /// private constructor that limits the ways users can instance this object (design choice)
        /// </summary>
        explicit value_with_unit(double input_value, std::shared_ptr<T> unit_ptr)
            : value(input_value), unit(unit_ptr)
        {}
        /// <summary>
        /// unit of type T (convertible_to_and_from_base)
        /// </summary>
        std::shared_ptr<T> unit;
    };
}

#endif