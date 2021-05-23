#pragma once
#include <corecrt_math.h>

class UnitCircleModel
{
public:

    UnitCircleModel()
    {
        Angle = NAN;
        Radians = NAN;
        X = NAN;
        Y = NAN;
    }

    ~UnitCircleModel()
    {
    }

    double GetAngle() const { return Angle; }
    void SetAngle(double val) { Angle = val; }
    double GetRadians() const { return Radians; }
    void SetRadians(double val) { Radians = val; }
    double GetX() const { return X; }
    void SetX(double val) { X = val; }
    double GetY() const { return Y; }
    void SetY(double val) { Y = val; }
private:
    double Angle;
    double Radians;
    double X;
    double Y;
};
