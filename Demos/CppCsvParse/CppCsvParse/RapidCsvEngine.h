#pragma once

#include <vector>
#include <list>
#include "rapidcsv.h"
#include <set>

using namespace std;

class RapidCsvEngine
{
public:

    RapidCsvEngine()
    {
    }

    ~RapidCsvEngine()
    {
    }
    void Run(string csvIn, string csvOut, vector<string> columns);

    vector<vector<double>> Run(string csvIn, set<string> columns);
private:
};
