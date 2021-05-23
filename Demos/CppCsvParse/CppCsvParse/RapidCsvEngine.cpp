#include "RapidCsvEngine.h"
#include <iomanip>
#include "UnitCircleModel.h"

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

void RapidCsvEngine::Run(string csvIn, string csvOut, vector<string> columns)
{
    rapidcsv::Document doc(csvIn);

    std::stringstream  ss;
    vector <string> ::iterator column;
    vector<vector<double>> data;
    string separator = "";
    for (column = columns.begin(); column != columns.end(); column++)
    {
        ss << separator << *column;
        separator = ",";
        data.push_back(doc.GetColumn<double>(*column));
    }
    ss << '\n';

    const auto rows = data[0].size();
    const auto cols = data.size();
    auto models = list<UnitCircleModel>();
    vector<vector<double>> ::iterator vvItr;
    for (size_t i = 0; i < rows; i++)
    {
        auto model = UnitCircleModel();
        for (size_t j = 0; j < cols; j++)
        {
            string col = columns[j];
            auto value = data[j][i];
            if (col == "Angle")
            {
                model.Angle(value);
            }
            else if (col == "Radians")
            {
                model.Radians(value);
            }
            else if (col == "X")
            {
                model.X(value);
            }
            else if (col == "Y")
            {
                model.Y(value);
            }
            else
            {
                throw std::invalid_argument("Unknown column value");
            }
        }
        models.push_back(model);
    }

    separator = ",";
    list <UnitCircleModel> ::iterator model;
    for (model = models.begin(); model != models.end(); model++)
    {
        UnitCircleModel row = *model;
        ss << setprecision(10) << row.Angle();
        ss << separator << setprecision(10) << row.Radians();
        ss << separator << setprecision(10) << row.X();
        ss << separator << setprecision(10) << row.Y();
        ss << '\n';
    }

    std::ofstream outFile(csvOut);
    outFile << ss.rdbuf();
    outFile.close();
}
