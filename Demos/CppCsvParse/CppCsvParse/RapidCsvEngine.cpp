#include "RapidCsvEngine.h"

void RapidCsvEngine::Run(string csvInput, string csvOutput)
{
    rapidcsv::Document doc("csvInput");

    std::vector<float> angle = doc.GetColumn<float>("Angle");
}
