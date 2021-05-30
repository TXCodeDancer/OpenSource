#pragma once
#include <vector>
#include <set>
#include "ThirdPartyLibraries/rapidcsv.h"

using namespace std;

class RapidCsvEngine
{
public:
    RapidCsvEngine() { }
    ~RapidCsvEngine() { }

    vector<vector<double>> Run(string csvIn, set<string> columns);
};
