#include "CalculateData.h"
#include <objbase.h>
#include <fstream>
#include <cstdlib>
#include <ctime>
#define Calculate_EXPORTS
Calculate_EXPORTS int Add(int numberA, int numberB)
{
    return numberA + numberB;
}

Calculate_EXPORTS int GetToken()
{
    srand((unsigned)time(NULL));
    return rand();
}

CalculateData::CalculateData()
{
}

CalculateData::~CalculateData()
{
}
