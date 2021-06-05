#pragma once
#include <vector>
#include <set>
#include "ThirdPartyLibraries/rapidcsv.h"

class RapidCsvEngine
{
public:
    RapidCsvEngine() { }
    ~RapidCsvEngine() { }

    std::vector<std::vector<double>> Run(std::string csvIn, std::set<std::string> columns);
    std::vector<float> ParamsRun(std::string csvIn, std::set<std::string> _inputs);
};
