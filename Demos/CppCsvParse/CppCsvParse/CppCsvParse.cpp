// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"
#include "UnitCircleModel.h"

int main()
{
    //     vector<string> columns{ "Angle", "Radians", "X", "Y" };
    //
    //     auto rapidCsvEngine = RapidCsvEngine();
    //     rapidCsvEngine.Run("CSVUnitCircle.csv", "CSVUnitCircleOut_RapidCsv.csv", columns);

    auto model = UnitCircleModel();
    model.ReadAll("CSVUnitCircle.csv");
    model.WriteAll("CSVUnitCircleOut_UnitCircle.csv");
}
