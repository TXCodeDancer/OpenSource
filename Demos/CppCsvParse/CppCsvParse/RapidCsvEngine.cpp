#include "RapidCsvEngine.h"
#include <iomanip>
#include "UnitCircleModel.h"

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
                model.SetAngle(value);
            }
            else if (col == "Radians")
            {
                model.SetRadians(value);
            }
            else if (col == "X")
            {
                model.SetX(value);
            }
            else if (col == "Y")
            {
                model.SetY(value);
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
        ss << setprecision(10) << row.GetAngle();
        ss << separator << setprecision(10) << row.GetRadians();
        ss << separator << setprecision(10) << row.GetX();
        ss << separator << setprecision(10) << row.GetY();
        ss << '\n';
    }

    std::ofstream outFile(csvOut);
    outFile << ss.rdbuf();
    outFile.close();
}
