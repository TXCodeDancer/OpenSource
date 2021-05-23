// CppCsvParse.cpp : This file contains the 'main' function.
//

#include <iostream>
#include "RapidCsvEngine.h"
#include "UnitCircleModel.h"

int main()
{
    auto model = UnitCircleModel();
    model.ReadAll("CSVUnitCircle.csv");
    model.WriteAll("CSVUnitCircleOut_UnitCircle.csv");
}
