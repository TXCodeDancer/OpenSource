#include "RapidCsvEngine.h"
#include "CSVWriter.h"

void RapidCsvEngine::Run(string csvInput, string csvOutput)
{
    rapidcsv::Document doc("csvInput");

    std::vector<float> angle = doc.GetColumn<float>("Angle");
    std::vector<float> radians = doc.GetColumn<float>("Radians");

    auto count = angle.size();

    CSVWriter csvOut;
    csvOut.newRow() << "Angle", "Radians";
    for (auto i = 0; i < count; i++)
    {
        csvOut.newRow() << angle[i] << radians[i];
    }
}
