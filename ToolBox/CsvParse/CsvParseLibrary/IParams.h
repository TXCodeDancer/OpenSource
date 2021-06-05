#pragma once
#include <string>
#include <vector>
#include <set>

class IParams
{
public:
    virtual std::vector<std::vector<double>> GetIOData(std::string csvIn) = 0;

    void Run(std::string csvIn, std::string csvOut)
    {
        Read(csvIn);
        Compute();
        Write(csvOut);
    };

protected:
    virtual void Read(std::string csvIn) = 0;
    virtual void Write(std::string csvOut) = 0;
    virtual void Compute(void) = 0;
    virtual void UpdateModels(std::vector<std::vector<double>>& inputs, std::set<std::string> columnSet) = 0;
};
