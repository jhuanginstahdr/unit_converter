#ifndef LENGTH_UNITS
#define LENGTH_UNITS

#include "../Model/interfaces.h"
#include "../Unitless/unit_modifier.h"

namespace unit_converter
{
    /// <summary>
    /// interface/base class type that says the class implementing it is a length unit
    /// </summary>
    class length_unit : 
        public unit_description, 
        public convert_from_base, 
        public convert_to_base
    { };

    /// <summary>
    /// example: metre as a concrete implementation of length unit
    /// </summary>
    class metre final : public length_unit
    {
    public:
        static std::shared_ptr<metre> create(std::shared_ptr<unit_modifier> mod_ptr)
        {
            if (!mod_ptr) throw std::invalid_argument("mod_ptr cannot be nullptr");
            return std::shared_ptr<metre>(new metre(mod_ptr));
        }
        std::string get_name() override { return mod->get_name() + "metre"; }
        std::string get_symb() override { return mod->get_symb() + "m"; }
        double from_base(double base) override { return base * mod->from_base(1.0); }
        double to_base(double value) override { return value * mod->to_base(1.0); }
    private:
        /// <summary>
        /// private constructor to limit ways to instance the object
        /// </summary>
        explicit metre(std::shared_ptr<unit_modifier> mod_ptr) : mod(mod_ptr) {}
        /// <summary>
        /// additional modifier is added and specified via constructor
        /// </summary>
        std::shared_ptr<unit_modifier> mod;
    };

    /// <summary>
    /// example: foot as a concrete implementation of length unit
    /// </summary>
    class foot final : public length_unit
    {
    public:
        static std::shared_ptr<foot> create() { return std::shared_ptr<foot>(new foot()); }
        std::string get_name() override { return "foot"; }
        std::string get_symb() override { return "ft"; }
        double from_base(double base) override { return base / 0.3048; }
        double to_base(double value) override { return value * 0.3048; }
    private:
        /// <summary>
        /// private constructor to limit ways to instance the object
        /// </summary>
        explicit foot() {}
    };
}

#endif