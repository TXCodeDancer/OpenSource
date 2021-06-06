#include "pch.h"
#include "CppUnitTest.h"
#include "CsvParseLibrary\BoreholeParams.h"
#include <stdexcept>

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

            try
            {
                model.Run(OriginalCvs, ResultsCvs);
                Assert::IsTrue(true);
            }
            catch (std::invalid_argument& e)
            {
                Assert::AreEqual("", e.what());
            }
            catch (std::exception& e)
            {
                Assert::AreEqual("", e.what());
            }
        }
    };
}
