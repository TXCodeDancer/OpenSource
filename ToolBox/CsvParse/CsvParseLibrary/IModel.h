#pragma once
#include <string>
#include <vector>
#include <set>

using namespace std;

class IModel
{
public:
    virtual void Read(string csvIn) = 0;
    virtual void ReadAll(string csvIn) = 0;
    virtual void Write(string csvOut) = 0;
    virtual void Compute(void) = 0;
    virtual vector<vector<double>> GetAllData(string csvFile) = 0;

    void Run(string csvIn, string csvOut)
    {
        Read(csvIn);
        Compute();
        Write(csvOut);
    };

    void WriteInputs(string csvIn, string csvOut)
    {
        ReadAll(csvIn);
        Write(csvOut);
    };

protected:
    virtual void UpdateModels(vector<vector<double>>& inputs, set<string> columnSet) = 0;
};
