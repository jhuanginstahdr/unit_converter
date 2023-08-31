#ifndef TIME_UNITS
#define TIME_UNITS

#include "../Model/interfaces.h"
#include "../Unitless/unit_modifier.h"

namespace unit_converter
{
    /// <summary>
    /// interface/base class type that says the class implementing it is a time unit
    /// </summary>
    class time_unit :
        public unit_description,
        public convert_from_base,
        public convert_to_base
    { };

    /// <summary>
    /// example: second as a concrete implementation of time unit
    /// </summary>
    class second final : public time_unit
    {
    public:
        static std::shared_ptr<second> create(std::shared_ptr<unit_modifier> mod_ptr)
        {
            if (!mod_ptr) throw std::invalid_argument("mod_ptr cannot be nullptr");
            return std::shared_ptr<second>(new second(mod_ptr));
        }
        string get_name() override { return mod->get_name() + "second"; }
        string get_symb() override { return mod->get_symb() + "s"; }
        double from_base(double base) override { return base * mod->from_base(1.0); }
        double to_base(double value) override { return value * mod->to_base(1.0); }
    private:
        /// <summary>
        /// private constructor to limit ways to instance the object
        /// </summary>
        explicit second(std::shared_ptr<unit_modifier> mod_ptr) : mod(mod_ptr) {}
        /// <summary>
        /// additional modifier is added and specified via constructor
        /// </summary>
        shared_ptr<unit_modifier> mod;
    };

    /// <summary>
    /// example: day as a concrete implementation of time unit
    /// </summary>
    class day final : public time_unit
    {
    public:
        static std::shared_ptr<day> create() { return std::shared_ptr<day>(new day()); }
        string get_name() override { return "day"; }
        string get_symb() override { return "d"; }
        double from_base(double base) override { return base / scalar; }
        double to_base(double value) override { return value * scalar; }
    private:
        /// <summary>
        /// private constructor to limit ways to instance the object
        /// </summary>
        explicit day() {}
        const double scalar = 60.0 * 60.0 * 24.0;
    };
}

#endif