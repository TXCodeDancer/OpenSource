// UnitTestDemo.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "Square.h"

int main()
{
    int seed = 3;
    auto sq = Square(seed);
    auto seedSquared = sq.GetSquare();
    std::cout << "The square of " << seed << " is " << seedSquared << "\n";

    int side = 5;
    auto area = sq.GetArea(side);
    std::cout << "The area of a square with sides of " << side << " is " << area << "\n";
}
