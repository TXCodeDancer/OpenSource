#pragma once
#include <string>
#include <vector>
#include <set>

using namespace std;

class IModel
{
public:
    virtual vector<vector<double>> GetIOData(string csvIn) = 0;

    void Run(string csvIn, string csvOut)
    {
        Read(csvIn);
        Compute();
        Write(csvOut);
    };

protected:
    virtual void Read(string csvIn) = 0;
    virtual void Write(string csvOut) = 0;
    virtual void Compute(void) = 0;
    virtual void UpdateModels(vector<vector<double>>& inputs, set<string> columnSet) = 0;
};
