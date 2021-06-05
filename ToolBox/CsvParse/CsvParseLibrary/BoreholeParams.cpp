#include "pch.h"
#include "BoreholeParams.h"
#include <stdexcept>
#include "RapidCsvEngine.h"

std::vector<float> BoreholeParams::GetData(std::string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    auto inputs = rapidCsvEngine.GetCells(csvIn, _inputs, "VALUE", 0, 0, ' ', true);
    return inputs;
}

void BoreholeParams::Read(std::string csvIn)
{
    auto inputs = GetData(csvIn);
    UpdateModels(inputs, _inputs);
}

//void BoreholeParams::Write(std::string csvOut)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}

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
