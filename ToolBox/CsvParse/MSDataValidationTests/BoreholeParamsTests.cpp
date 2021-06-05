#include "pch.h"
#include "CppUnitTest.h"
#include "CsvParseLibrary\BoreholeParams.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

const std::string OriginalCvs = "../../TestCases/ParametersOnly.las";
const std::string ResultsCvs = "ParametersOnlyResults.las";
const double tolerance = 0.00000001;

namespace MSDataValidationTests
{
    TEST_CLASS(UnitCircleTests)
    {
    public:

        TEST_METHOD(OriginalVsResultsTest)
        {
            auto model = BoreholeParams();
            //auto originalData = model.GetIOData(OriginalCvs);
            model.Run(OriginalCvs, ResultsCvs);
            //auto resultsData = model.GetIOData(ResultsCvs);

            //auto rows = originalData[0].size();
            //auto cols = originalData.size();
            //for (size_t i = 0; i < rows; i++)
            //{
            //    for (size_t j = 0; j < cols; j++)
            //    {
            //        auto expected = originalData[j][i];
            //        auto actual = resultsData[j][i];
            //        Assert::AreEqual(expected, actual, tolerance);
            //    }
            //}

            Assert::IsTrue(false);
        }
    };
}
