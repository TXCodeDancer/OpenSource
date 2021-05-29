#include "pch.h"
#include "..\CppCsvParse\UnitCircleModel.h"

TEST(UnitCircle, UnitCircleTest0) {
    auto model = UnitCircleModel();
    model.WriteInputs("CSVUnitCircle.csv", "CSVUnitCircleOut_Inputs_0.csv");
    model.Run("CSVUnitCircle.csv", "CSVUnitCircleOut_0.csv");
}
