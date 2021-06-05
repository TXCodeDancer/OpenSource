#include "pch.h"
#include "CppUnitTest.h"
#include "CsvParseLibrary\BoreholeParams.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

const std::string OriginalCvs = "../../TestCases/AllValueSpaces.las";
const std::string ResultsCvs = "ParametersOnlyResults.las";
const double tolerance = 0.00000001;

namespace MSDataValidationTests
{
    TEST_CLASS(BoreholeParamsTests)
    {
    public:

        TEST_METHOD(LoadParametersTest)
        {
            auto model = BoreholeParams();
            model.Run(OriginalCvs, ResultsCvs);

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

            //        Assert::AreEqual(expected, actual, tolerance);
            Assert::IsTrue(false);
        }
    };
}
