// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"

int main()
{
    auto rapidCsvEngine = RapidCsvEngine();
    list<string> columns;
    rapidCsvEngine.Run("CSVUnitCircle.csv", "CSVUnitCircleOut.csv", columns);
}
