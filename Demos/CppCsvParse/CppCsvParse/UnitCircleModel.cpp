#include "UnitCircleModel.h"
#include "RapidCsvEngine.h"
#include <iomanip>

void UnitCircleModel::ReadInputs(string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    auto inputs = rapidCsvEngine.Run("CSVUnitCircle.csv", _inputs);

    UpdateModels(inputs, _inputs);
}

void UnitCircleModel::ReadAll(string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    set<string> all(_inputs);
    all.insert(_outputs.begin(), _outputs.end());
    auto inputs = rapidCsvEngine.Run("CSVUnitCircle.csv", all);

    UpdateModels(inputs, all);
}

void UnitCircleModel::WriteAll(string csvOut)
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
    throw std::logic_error("The method or operation is not implemented.");
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
    vector<vector<double>> ::iterator vvItr;
    for (size_t i = 0; i < rows; i++)
    {
        auto model = UnitCircleModel();
        for (size_t j = 0; j < cols; j++)
        {
            string col = columns[j];
            auto value = inputs[j][i];
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

    _models.clear();
    _models = models;
}
