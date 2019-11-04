using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_NotLearningCLI
{
    public class NNFunction
    {
        public double Step(double x)
        {
            if(x > 0) { return 1; }
            else { return 0; }
        }
        
        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        public double ReLU(double x)
        {
            if(x > 0) { return x; }
            else { return 0; }
        }
    }
}
