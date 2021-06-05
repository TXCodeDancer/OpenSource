#pragma once
#include <vector>
#include <string>
#include <set>
#include "IParams.h"

class BoreholeParams : public IParams
{
public:
    BoreholeParams()
    {
        _BHK = NAN;
        _BRTA = NAN;
        _BS = NAN;
        _DFD = NAN;
        _GR_MULTIPLIER = NAN;
    }
    ~BoreholeParams() { }

    //std::vector<double> GetData(std::string csvIn) override;

private:
    float _BHK;
    float _BRTA;
    float _BS;
    float _DFD;
    float _GR_MULTIPLIER;
    std::set<std::string> _inputs{ "BHK", "BRTA", "BS", "DFD", "GR_MULTIPLIER" };

    void Read(std::string csvIn) override;
    //void Write(std::string csvOut) override;
    //void UpdateModels(std::vector<double>& inputs, std::set<std::string> columnSet) override;
};
