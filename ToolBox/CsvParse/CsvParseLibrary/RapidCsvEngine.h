#pragma once
#include <vector>
#include <set>
#include "ThirdPartyLibraries/rapidcsv.h"

class RapidCsvEngine
{
public:
    RapidCsvEngine() { }
    ~RapidCsvEngine() { }

    std::vector<std::vector<double>> Run(const std::string csvIn, const std::set<std::string> columns);
    std::vector<float> GetCells(const std::string csvIn, const std::set<std::string> rows, const std::string column,
        int colRow = 0, int rowCol = -1, char delimiter = ',', bool ignoreConsecutiveDelimiters = false);
    ssize_t GetRowIdx(const std::string csvIn, const std::string& pRowName, const char delimiter = ',') const;
};
