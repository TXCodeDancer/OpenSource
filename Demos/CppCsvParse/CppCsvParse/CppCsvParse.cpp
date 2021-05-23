// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"

int main()
{
    vector<string> columns{ "Angle", "Radians", "X", "Y" };

    auto rapidCsvEngine = RapidCsvEngine();
    rapidCsvEngine.Run("CSVUnitCircle.csv", "CSVUnitCircleOut_RapidCsv.csv", columns);
}
