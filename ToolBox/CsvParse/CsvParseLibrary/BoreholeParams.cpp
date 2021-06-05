#include "pch.h"
#include "BoreholeParams.h"
#include <stdexcept>
#include "RapidCsvEngine.h"
#include <iomanip>

std::vector<float> BoreholeParams::GetData(std::string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    auto colRow = (int)rapidCsvEngine.GetRowIdx(csvIn, "~PARAMETER", ' ') + 2;
    auto inputs = rapidCsvEngine.GetCells(csvIn, _inputs, "VALUE", colRow, 0, ' ', true);
    return inputs;
}

void BoreholeParams::Read(std::string csvIn)
{
    auto inputs = GetData(csvIn);
    UpdateModels(inputs, _inputs);
}

void BoreholeParams::Write(std::string csvOut)
{
    std::stringstream  ss;

    std::string separator = "";
    std::set<std::string> ::iterator itr;
    for (itr = _inputs.begin(); itr != _inputs.end(); itr++)
    {
        ss << separator << *itr;
        separator = ",";
    }
    ss << "\n";

    ss << std::setprecision(10) << _BHK;
    ss << separator << std::setprecision(10) << _BRTA;
    ss << separator << std::setprecision(10) << _BS;
    ss << separator << std::setprecision(10) << _DFD;
    ss << separator << std::setprecision(10) << _GR_MULTIPLIER;
    ss << '\n';

    std::ofstream outFile(csvOut);
    outFile << ss.rdbuf();
    outFile.close();
}

void BoreholeParams::UpdateModels(std::vector<float>& inputs, std::set<std::string> rowSet)
{
    if (inputs.size() != rowSet.size())
    {
        throw std::invalid_argument("Input size mismatch");
    }

    _BHK = inputs[(int)BoreholeParam::Bhk];
    _BRTA = inputs[(int)BoreholeParam::Brta];
    _BS = inputs[(int)BoreholeParam::Bs];
    _DFD = inputs[(int)BoreholeParam::Dfd];
    _GR_MULTIPLIER = inputs[(int)BoreholeParam::GRMultiplier];
}
