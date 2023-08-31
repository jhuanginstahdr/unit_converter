// ConsoleApplication1.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <memory>
#include "interfaces.h"
#include "length_units.h"
#include "value_with_unit.h"
#include "time_units.h"
#include "rate_of_change.h"

using namespace unit_converter;

int main()
{
    auto unitary_mod = unitary::create();
    auto kilo_mod = kilo::create();

    auto m_ptr = metre::create(unitary_mod);
    auto km_ptr = metre::create(kilo_mod);
    auto ft_ptr = foot::create();

    auto length = value_with_unit<length_unit>::create(10.0, km_ptr);
    //starts at 10 km
    std::cout << length->value << std::endl;
    //convert to foot
    std::cout << length->convert(ft_ptr) << std::endl;
    //convert to metre
    std::cout << length->convert(m_ptr) << std::endl;
    //convert to metre
    std::cout << length->convert(ft_ptr) << std::endl;

    auto sec_ptr = second::create(unitary_mod);
    auto day_ptr = day::create();
    
    auto m_per_day = rate_of_change<length_unit>::create(m_ptr, day_ptr);
    auto ft_per_sec = rate_of_change<length_unit>::create(ft_ptr, sec_ptr);

    auto speed = value_with_unit<rate_of_change<length_unit>>::create(10.0, m_per_day);
    //starts at 10 m/s
    std::cout << speed->value << std::endl;
    //convert to ft per day
    std::cout << speed->convert(ft_per_sec) << std::endl;

#if false
    //an example how a conversion between incompatible units is not possible
    //where the code would not even compile in the first place
    std::cout << speed->convert(m_ptr) << std::endl;
#endif
}
