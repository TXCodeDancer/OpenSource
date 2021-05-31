#include "pch.h"
#include "CppUnitTest.h"
#include "..\CsvParseLibrary\UnitCircleModel.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

const string OriginalCvs = "../../TestCases/CSVUnitCircle.csv";
const string ResultsCvs = "CSVUnitCircleResults.csv";
const double tolerance = 0.00000001;

namespace MSDataValidationTests
{
    TEST_CLASS(UnitCircleTests)
    {
    public:

        TEST_METHOD(OriginalVsResultsTest)
        {
            auto model = UnitCircleModel();
            auto originalData = model.GetIOData(OriginalCvs);
            model.Run(OriginalCvs, ResultsCvs);
            auto resultsData = model.GetIOData(ResultsCvs);

            auto rows = originalData[0].size();
            auto cols = originalData.size();
            for (size_t i = 0; i < rows; i++)
            {
                for (size_t j = 0; j < cols; j++)
                {
                    auto expected = originalData[j][i];
                    auto actual = resultsData[j][i];
                    Assert::AreEqual(expected, actual, tolerance);
                }
            }
        }
    };
}
