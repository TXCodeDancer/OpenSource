#include "RapidCsvEngine.h"
#include <iomanip>

void RapidCsvEngine::Run(string csvIn, string csvOut, list<string> columns)
{
    rapidcsv::Document doc(csvIn);

    std::stringstream  ss;
    list <string> ::iterator column;
    vector<vector<double>> data;
    string separator = "";
    for (column = columns.begin(); column != columns.end(); column++)
    {
        ss << separator << *column;
        separator = ",";
        data.push_back(doc.GetColumn<double>(*column));
    }
    ss << '\n';

    auto count = data[0].size();
    vector<vector<double>> ::iterator vvItr;
    separator = "";
    for (size_t i = 0; i < count; i++)
    {
        for (vvItr = data.begin(); vvItr != data.end(); vvItr++)
        {
            auto col = *vvItr;
            ss << separator << setprecision(10) << col[i];
            separator = ",";
        }
        //auto x = data[i];
        //for (vector<double> row : data[i])
        //{
        //    ss << separator << row[i];
        //    separator = ",";
        //    //ss << angle[i] << ',' << setprecision(10) << radians[i] << '\n';
        //}
        ss << '\n';
        separator = "";
    }

    std::ofstream outFile(csvOut);
    outFile << ss.rdbuf();
    outFile.close();
}
