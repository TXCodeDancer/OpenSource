#include "codecvt"
#define HAS_CODECVT
#include "RapidCsvEngine.h"
#include <boost/format.hpp>
#include <iomanip>

void RapidCsvEngine::Run(string csvInput, string csvOutput)
{
    rapidcsv::Document doc(csvInput);

    std::vector<double> angle = doc.GetColumn<double>("Angle");
    std::vector<double> radians = doc.GetColumn<double>("Radians");

    auto count = angle.size();
    std::stringstream  ss;
    ss << "Angle" << ',' << "Radians" << '\n';
    for (size_t i = 0; i < count; i++)
    {
        string csv = str(boost::format("%1$.1f,%2$.9f\n") % angle[i] % radians[i]);
        ss << angle[i] << ',' << setprecision(10) << radians[i] << '\n';
        string csv3 = ss.str();
    }

    std::ofstream outFile(csvOutput);
    outFile << ss.rdbuf();
    outFile.close();
}
