#pragma once

#include <vector>
#include "rapidcsv.h"
#include <set>

using namespace std;

class RapidCsvEngine
{
public:
    RapidCsvEngine() { }
    ~RapidCsvEngine() { }

    vector<vector<double>> Run(string csvIn, set<string> columns);
};
