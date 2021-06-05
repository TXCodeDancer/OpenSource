#include "pch.h"
#include "RapidCsvEngine.h"

std::vector<std::vector<double>> RapidCsvEngine::Run(std::string csvIn, std::set<std::string> columns)
{
    rapidcsv::Document doc(csvIn);

    std::set<std::string> ::iterator column;
    std::vector<std::vector<double>> data;
    for (column = columns.begin(); column != columns.end(); column++)
    {
        data.push_back(doc.GetColumn<double>(*column));
    }

    return data;
}
