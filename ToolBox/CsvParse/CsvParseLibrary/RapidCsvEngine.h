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
    std::vector<float> GetCells(std::string csvIn, std::set<std::string> rows, std::string column,
        int colIdx = 0, int rowIdx = -1, char delimiter = ',', bool ignoreConsecutiveDelimiters = false);
};
