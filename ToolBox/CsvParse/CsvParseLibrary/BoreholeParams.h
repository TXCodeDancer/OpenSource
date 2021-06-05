#pragma once
#include <vector>
#include <string>
#include <set>
#include "IParams.h"

class BoreholeParams : public IParams
{
public:
    BoreholeParams() { }
    ~BoreholeParams() { }

    std::vector<double> GetData(std::string csvIn) override;

private:
    void Read(std::string csvIn) override;

    void Write(std::string csvOut) override;

    void UpdateModels(std::vector<double>& data, std::set<std::string> columnSet) override;
};
