#pragma once
#include <string>

using namespace std;

class IModel
{
public:
    virtual void ReadInputs(string csvIn) = 0;
    virtual void ReadAll(string csvIn) = 0;
    virtual void WriteAll(string csvOut) = 0;
};
