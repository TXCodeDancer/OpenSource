#include "pch.h"
#include "CppUnitTest.h"
#include "..\CsvParseLibrary\UnitCircleModel.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

const string InputCvs = "../../TestCases/CSVUnitCircle.csv";
const double tolerance = 0.00000001;

namespace MSDataValidationTests
{
    TEST_CLASS(UnitCircleTests)
    {
    public:

        TEST_METHOD(Test0)
        {
            auto model = UnitCircleModel();
            model.WriteInputs(InputCvs, "CSVUnitCircleOut_Inputs_0.csv");
            model.Run(InputCvs, "CSVUnitCircleOut_0.csv");
            auto data1 = model.GetAllData("CSVUnitCircleOut_Inputs_0.csv");
            auto data2 = model.GetAllData("CSVUnitCircleOut_0.csv");

            auto rows = data1[0].size();
            auto cols = data1.size();
            for (size_t i = 0; i < rows; i++)
            {
                for (size_t j = 0; j < cols; j++)
                {
                    auto expected = data1[j][i];
                    auto actual = data2[j][i];
                    Assert::AreEqual(expected, actual, tolerance);
                }
            }
        }
    };
}
