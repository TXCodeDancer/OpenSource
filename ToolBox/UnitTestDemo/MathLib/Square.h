#pragma once

#ifdef MathLib
#define DECLSPEC __declspec(dllexport)
#else
#define DECLSPEC __declspec(dllimport)
#endif

class DECLSPEC Square
{
public:
    Square(int seed);
    ~Square() {};
    int GetSquare();
    int GetArea(int side);

private:
    int m_Seed;
};
