#include "Square.h"

Square::Square(int seed)
{
    m_Seed = seed;
}

int Square::GetSquare()
{
    return m_Seed * m_Seed;
}

int Square::GetArea(int side)
{
    return side * side;
}
