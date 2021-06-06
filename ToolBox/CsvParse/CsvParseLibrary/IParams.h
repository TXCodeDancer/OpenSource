#pragma once
#include <string>
#include <vector>
#include <set>

class IParams
{
public:
    virtual std::vector<float> GetData(std::string csvIn) = 0;

    void Run(std::string csvIn, std::string csvOut)
    {
        //Load(csvIn);
        Write(csvOut);
    };

protected:
    virtual void Load(std::string csvIn) = 0;
    virtual void Write(std::string csvOut) = 0;
    virtual void UpdateModels(std::vector<float>& inputs, std::set<std::string> columnSet) = 0;
};
