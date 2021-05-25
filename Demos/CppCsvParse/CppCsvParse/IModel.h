#pragma once
#include <string>
#include <vector>
#include <set>

using namespace std;

class IModel
{
public:
    virtual void ReadInputs(string csvIn) = 0;
    virtual void ReadAll(string csvIn) = 0;
    virtual void WriteAll(string csvOut) = 0;
    virtual void Compute(void) = 0;

    void Run(string csvIn, string csvOut)
    {
        ReadInputs(csvIn);
        Compute();
        WriteAll(csvOut);
    };

protected:
    virtual void UpdateModels(vector<vector<double>>& inputs, set<string> columnSet) = 0;
};
