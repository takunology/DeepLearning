using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSECEE
{
    public class Function
    {
        public double Sigmoid(double Input)
        {
            return 1 / (1 + Math.Exp(-Input));
        }

        public double ReLU(double Input)
        {
            if (Input > 0)
                return Input; //0を超えた場合はそのまま
            else 
                return 0; //0より小さい場合は0
        }

        public double Softmax(double Input, double ExpSum)
        {
            return Math.Exp(Input) / ExpSum;
        }
    }
}
