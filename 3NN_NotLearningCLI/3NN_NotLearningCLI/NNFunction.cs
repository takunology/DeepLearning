using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_NotLearningCLI
{
    public class NNFunction
    {
        //ステップ関数
        public double Step(double x)
        {
            if(x > 0) { return 1; }
            else { return 0; }
        }
        
        //シグモイド関数
        public double Sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        //ReLU関数
        public double ReLU(double x)
        {
            if(x > 0) { return x; }
            else { return 0; }
        }

        //恒等関数
        public double Identity(double x)
        {
            return x;
        }

        public double Softmax(double sum, double value)
        {
            // sum 入力値の合計
            // value その層の値
            double Result = (Math.Exp(value) / Math.Exp(sum));
            return Result;
        }
    }
}
