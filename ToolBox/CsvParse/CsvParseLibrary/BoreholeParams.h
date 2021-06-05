#pragma once
#include <vector>
#include <string>
#include <set>
#include "IParams.h"

enum class BoreholeParam { Bhk, Brta, Bs, Dfd, GRMultiplier };

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

    std::vector<float> GetData(std::string csvIn) override;

private:
    float _BHK;
    float _BRTA;
    float _BS;
    float _DFD;
    float _GR_MULTIPLIER;
    std::set<std::string> _inputs{ "BHK", "BRTA", "BS[1]", "DFD", "GR_MULTIPLIER" };

    void Read(std::string csvIn) override;
    //void Write(std::string csvOut) override;
    void UpdateModels(std::vector<float>& inputs, std::set<std::string> rowSet) override;
};
