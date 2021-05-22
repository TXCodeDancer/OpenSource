#include "RapidCsvEngine.h"
#include <iomanip>

void RapidCsvEngine::Run(string csvIn, string csvOut, list<string> columns)
{
    rapidcsv::Document doc(csvIn);

    std::vector<double> angle = doc.GetColumn<double>("Angle");
    std::vector<double> radians = doc.GetColumn<double>("Radians");

    auto count = angle.size();
    std::stringstream  ss;
    ss << "Angle" << ',' << "Radians" << '\n';
    for (size_t i = 0; i < count; i++)
    {
        ss << angle[i] << ',' << setprecision(10) << radians[i] << '\n';
    }

    std::ofstream outFile(csvOut);
    outFile << ss.rdbuf();
    outFile.close();
}
