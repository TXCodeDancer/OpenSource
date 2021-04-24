#include "pch.h"
#include "CppUnitTest.h"
#include "Square.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace MathTests
{
    TEST_CLASS(SquareTests)
    {
    public:

        TEST_METHOD(TestGetSqare)
        {
            int seed = 3;
            int expected = 9;
            auto sq = Square(seed);
            auto seedSquared = sq.GetSquare();
            Assert::AreEqual(expected, seedSquared);

            int side = 5;
            auto area = sq.GetArea(side);
        }

        TEST_METHOD(TestGetArea)
        {
            int seed = 3;
            int expected = 25;
            auto sq = Square(seed);

            int side = 5;
            auto area = sq.GetArea(side);
            Assert::AreEqual(expected, area);
        }
    };
}
