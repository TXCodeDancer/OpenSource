#pragma once
#include <string>
#include <vector>
#include <set>

class IParams
{
public:
    //virtual std::vector<double> GetData(std::string csvIn) = 0;

    //void Run(std::string csvIn, std::string csvOut)
    //{
    //    Read(csvIn);
    //    Write(csvOut);
    //};

protected:
    virtual void Read(std::string csvIn) = 0;
    //virtual void Write(std::string csvOut) = 0;
    //virtual void UpdateModels(std::vector<double>& inputs, std::set<std::string> columnSet) = 0;
};
