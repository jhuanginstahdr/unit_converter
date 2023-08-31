#ifndef UNIT_MODIFIER
#define UNIT_MODIFIER

#include "../Model/interfaces.h"

namespace unit_converter
{
    /// <summary>
    /// interface/base class for unitless modifier that can be used in junction with other unit types
    /// </summary>
    class unit_modifier :
        public unit_description, 
        public convert_from_base, 
        public convert_to_base
    { };

    /// <summary>
    /// example: a concrete implementation of unitary scalar
    /// </summary>
    class unitary final : public unit_modifier
    {
    public:
        static std::shared_ptr<unitary> create() { return std::shared_ptr<unitary>(new unitary()); }
        string get_name() override { return ""; }
        string get_symb() override { return ""; }
        double from_base(double base) override { return base; }
        double to_base(double value) override { return value; }
    private:
        explicit unitary() {}
    };

    /// <summary>
    /// example a concrete implementation of scalar modifier kilo
    /// </summary>
    class kilo final : public unit_modifier
    {
    public:
        static std::shared_ptr<kilo> create() { return std::shared_ptr<kilo>(new kilo()); }
        string get_name() override { return "kilo"; }
        string get_symb() override { return "k"; }
        double from_base(double base) override { return base / 1000.0; }
        double to_base(double value) override { return value * 1000.0; }
    private:
        explicit kilo() {}
    };
}

#endif