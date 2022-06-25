#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <iostream>

using namespace std;

#ifdef CalculateDLL_EXPORTS
#define Calculate_EXPORTS __declspec(dllexport)
#else
#define Calculate_EXPORTS __declspec(dllimport)
#endif

extern "C" Calculate_EXPORTS int Add(int numberA, int numberB);

extern "C" Calculate_EXPORTS  int GetToken();

class CalculateData
{

public:
    CalculateData();
    ~CalculateData();

};
