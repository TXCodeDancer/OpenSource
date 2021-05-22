#pragma once

#include <vector>
#include <list>
#include "rapidcsv.h"

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
    void Run(string csvIn, string csvOut, list<string> columns);

private:
};
