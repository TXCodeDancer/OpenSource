#include "RapidCsvEngine.h"
#include <iomanip>

vector<vector<double>> RapidCsvEngine::Run(string csvIn, set<string> columns)
{
    rapidcsv::Document doc(csvIn);

    set <string> ::iterator column;
    vector<vector<double>> data;
    for (column = columns.begin(); column != columns.end(); column++)
    {
        data.push_back(doc.GetColumn<double>(*column));
    }

    return data;
}
