#include "pch.h"
#include "BoreholeParams.h"
#include <stdexcept>
#include "RapidCsvEngine.h"

//std::vector<double> BoreholeParams::GetData(std::string csvIn)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}

void BoreholeParams::Read(std::string csvIn)
{
    auto rapidCsvEngine = RapidCsvEngine();
    auto inputs = rapidCsvEngine.GetCells(csvIn, _inputs, "VALUE", 0, 0, ' ', true);
}

//void BoreholeParams::Write(std::string csvOut)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}

//void BoreholeParams::UpdateModels(std::vector<double>& inputs, std::set<std::string> columnSet)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}
