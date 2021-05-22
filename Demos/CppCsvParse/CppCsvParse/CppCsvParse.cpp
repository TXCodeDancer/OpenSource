// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"

int main()
{
    auto rapidCsvEngine = RapidCsvEngine();
    rapidCsvEngine.Run("d:/HackerSpace/GitHub/Public/Demos/CppCsvParse/CppCsvParse/CSVUnitCircle.csv", "CSVUnitCircleOut.csv");
}
