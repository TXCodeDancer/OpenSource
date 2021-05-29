// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"
#include "UnitCircleModel.h"

int main()
{
    auto model = UnitCircleModel();
    model.Run("CSVUnitCircle.csv", "CSVUnitCircleOut_UnitCircleRun.csv");
    model.ReadAll("CSVUnitCircle.csv");
    model.Write("CSVUnitCircleOut_UnitCircle.csv");
}
