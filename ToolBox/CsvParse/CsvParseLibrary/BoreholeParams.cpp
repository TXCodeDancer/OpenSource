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
    auto inputs = rapidCsvEngine.ParamsRun(csvIn, _inputs);
}

//void BoreholeParams::Write(std::string csvOut)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}

//void BoreholeParams::UpdateModels(std::vector<double>& inputs, std::set<std::string> columnSet)
//{
//    throw std::logic_error("The method or operation is not implemented.");
//}
