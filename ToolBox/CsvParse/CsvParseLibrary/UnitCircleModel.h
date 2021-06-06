#pragma once
#include <corecrt_math.h>
#include "IModel.h"
#include <vector>
#include <list>
#include <set>
#include <xutility>

const double PI = 3.141592653589793238462643;

enum class Columns { angle, radians, x, y };

class UnitCircleModel : public IModel
{
public:

    UnitCircleModel()
    {
        _angle = NAN;
        _radians = NAN;
        _x = NAN;
        _y = NAN;
    }

    ~UnitCircleModel() { }

    std::vector<std::vector<double>> GetIOData(std::string csvIn) override;

private:
    double _angle;
    double _radians;
    double _x;
    double _y;
    std::set<std::string> _inputs{ "Angle" };
    std::set<std::string> _outputs{ "Angle","Radians", "X", "Y" };
    std::list<UnitCircleModel> _models;

    void Load(std::string csvIn) override;
    void Write(std::string csvOut) override;
    void Compute() override;
    void UpdateModels(std::vector<std::vector<double>>& inputs, std::set<std::string> columnSet) override;

    double Angle() const { return _angle; }
    void Angle(double val) { _angle = val; }
    double Radians() const { return _radians; }
    void Radians(double val) { _radians = val; }
    double X() const { return _x; }
    void X(double val) { _x = val; }
    double Y() const { return _y; }
    void Y(double val) { _y = val; }
};
