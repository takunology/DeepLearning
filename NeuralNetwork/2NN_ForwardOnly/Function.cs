using System;
using System.Collections.Generic;
using System.Text;

namespace _2NN_ForwardOnly
{
    public class Function
    {
        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double ReLU(double x)
        {
            if (x > 0)
                return x; //0を超えた場合はそのまま
            else 
                return 0; //0より小さい場合は0
        }
    }
}
