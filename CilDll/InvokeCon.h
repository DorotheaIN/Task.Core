#pragma once
#include <iostream>
#include "D:\yze\bachelor\third\courses\Next\.Net\期末\Task.Core\Task.Core.Token\CalculateData.h"//引用库声明对应文件路径

public ref class InvokeCon
{
public:
    InvokeCon();

    int AddCli(int numberA, int numberB);
    int SubtractCli(int numberA, int numberB);
    int MultiplicationCli(int numberA, int numberB);
    int DividedCli(int numberA, int numberB);
    int GetTokenCli();
};

