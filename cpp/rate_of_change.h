#ifndef RATE_OF_CHANGE
#define RATE_OF_CHANGE

#include "interfaces.h"
#include "time_units.h"

namespace unit_converter
{
    /// <summary>
    /// concrete implementation of rate of change that depends on a quantity unit type and time unit
    /// </summary>
    template <convertible_to_and_from_base_with_descriptor T>
    class rate_of_change final :
        public unit_description,
        public convert_from_base,
        public convert_to_base
    { 
    public:
        static std::shared_ptr<rate_of_change<T>> create(std::shared_ptr<T> quantity_type, std::shared_ptr<time_unit> time_type)
        {
            if (!quantity_type || !time_type) throw std::invalid_argument("quantity and time types cannot be nullptr");
            return std::shared_ptr<rate_of_change<T>>(new rate_of_change<T>(quantity_type, time_type));
        }
        string get_name() override { return quantity->get_name() + " per " + time->get_name(); }
        string get_symb() override { return quantity->get_symb() + "/" + time->get_symb(); }
        double from_base(double base) override { return quantity->from_base(base) / time->from_base(1.0); }
        double to_base(double value) override { return quantity->to_base(value) / time->to_base(1.0); }

    private:
        /// <summary>
        /// private constructor to limit ways to instance the object
        /// </summary>
        explicit rate_of_change(std::shared_ptr<T> quantity_type, std::shared_ptr<time_unit> time_type)
            : quantity(quantity_type), time(time_type) 
        {}
        std::shared_ptr<T> quantity;
        std::shared_ptr<time_unit> time;
    };
}

#endif