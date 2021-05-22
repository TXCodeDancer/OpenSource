#include "codecvt"
#define HAS_CODECVT
#include "RapidCsvEngine.h"
#include "CSVWriter.h"
#include <boost/format.hpp>
#include <iomanip>

//using namespace boost;

void RapidCsvEngine::Run(string csvInput, string csvOutput)
{
    rapidcsv::Document doc(csvInput);

    std::vector<double> angle = doc.GetColumn<double>("Angle");
    std::vector<double> radians = doc.GetColumn<double>("Radians");

    auto count = angle.size();
    CSVWriter csvWriter;
    csvWriter.newRow() << "Angle" << "Radians";
    std::stringstream  ss;
    for (size_t i = 0; i < count; i++)
    {
        string csv = str(boost::format("%1$.1f,%2$.9f\n") % angle[i] % radians[i]);
        //oss << setprecision(1) << angle[i] << ',' << setprecision(10) << radians[i];
        //string csv2 = oss.str();
        ss << angle[i] << ',' << setprecision(10) << radians[i] << '\n';
        string csv3 = ss.str();
        csvWriter.newRow() << angle[i] << radians[i];
    }
    csvWriter.writeToFile(csvOutput);

    std::ofstream outFile("myFile.csv");
    outFile << ss.rdbuf();
    outFile.close();
}
