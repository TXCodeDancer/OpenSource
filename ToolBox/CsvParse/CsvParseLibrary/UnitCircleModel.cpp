#include "pch.h"
#include "UnitCircleModel.h"
#include "RapidCsvEngine.h"
#include <iomanip>

void UnitCircleModel::Read(string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    auto inputs = rapidCsvEngine.Run(csvIn, _inputs);

    UpdateModels(inputs, _inputs);
}

void UnitCircleModel::ReadAll(string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    set<string> all(_inputs);
    all.insert(_outputs.begin(), _outputs.end());
    auto inputs = rapidCsvEngine.Run(csvIn, all);

    UpdateModels(inputs, all);
}

void UnitCircleModel::Write(string csvOut)
{
    std::stringstream  ss;
    ss << "Angle,Radians,X,Y\n";
    string separator = ",";
    list <UnitCircleModel> ::iterator model;
    for (model = _models.begin(); model != _models.end(); model++)
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

void UnitCircleModel::Compute()
{
    auto models = list<UnitCircleModel>();
    list <UnitCircleModel> ::iterator itr;
    for (itr = _models.begin(); itr != _models.end(); itr++)
    {
        UnitCircleModel row = *itr;
        auto rads = (row.Angle() * PI) / 180;
        row.Radians(rads);
        row.X(cos(rads));
        row.Y(sin(rads));
        models.push_back(row);
    }

    _models.clear();
    _models = models;
}

vector<vector<double>> UnitCircleModel::GetIOData(string csvFile)
{
    auto rapidCsvEngine = RapidCsvEngine();
    set<string> all(_inputs);
    all.insert(_outputs.begin(), _outputs.end());
    auto data = rapidCsvEngine.Run(csvFile, all);
    return data;
}

void UnitCircleModel::UpdateModels(vector<vector<double>>& inputs, set<string> columnSet)
{
    if (inputs.size() != columnSet.size())
    {
        throw std::invalid_argument("Input column mismatch");
    }

    const auto rows = inputs[0].size();
    const auto cols = inputs.size();

    auto models = list<UnitCircleModel>();
    vector<string> columns{ columnSet.begin(), columnSet.end() };
    for (size_t i = 0; i < rows; i++)
    {
        auto model = UnitCircleModel();
        for (size_t j = 0; j < cols; j++)
        {
            auto value = inputs[j][i];
            switch (j)
            {
            case ((size_t)Columns::angle):
                model.Angle(value);
                break;
            case ((size_t)Columns::radians):
                model.Radians(value);
                break;
            case ((size_t)Columns::x):
                model.X(value);
                break;
            case ((size_t)Columns::y):
                model.Y(value);
                break;

            default:
                throw std::invalid_argument("Unknown column value");
                break;
            }
        }
        models.push_back(model);
    }

    _models.clear();
    _models = models;
}
