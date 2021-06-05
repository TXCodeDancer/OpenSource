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

std::vector<float> RapidCsvEngine::GetCells(std::string csvIn, std::set<std::string> rows, std::string column, int colIdx, int rowIdx, char delimiter, bool ignoreConsecutiveDelimiters)
{
    rapidcsv::Document doc(csvIn, rapidcsv::LabelParams(colIdx, rowIdx), rapidcsv::SeparatorParams(delimiter, true, true, false, true, ignoreConsecutiveDelimiters));

    std::set<std::string> ::iterator row;
    std::vector<float> data;
    for (row = rows.begin(); row != rows.end(); row++)
    {
        data.push_back(doc.GetCell<float>(column, *row));
    }

    return data;
}
