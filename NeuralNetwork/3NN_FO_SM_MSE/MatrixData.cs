using System;
using System.Collections.Generic;
using System.Text;

namespace _3NN_FO_SM_MSE
{
    //データ保持用クラス
    public class MatrixData
    {
        //レイヤ―数カウンタ
        static public int LayerCount = 0;

        //行列サイズ
        static public int ROW_IN = 1;
        static public int COL_IN = 1;

        static public int ROW_MIDDLE = 1;
        static public int COL_MIDDLE = 1;

        static public int ROW_WEIGHT = 1;
        static public int COL_WEIGHT = 1;

        static public int ROW_COPY = 1; //コピー行列サイズ
        static public int COL_COPY = 1; //コピー行列サイズ

        static public int ROW_OUT = 1;
        static public int COL_OUT = 1;

        //行列データ
        static public double[,] InputMatrix = new double[ROW_IN, COL_IN]; //入力層
        static public double[,] MiddleMatrix = new double[ROW_MIDDLE, COL_MIDDLE]; //中間層の結果
        static public double[,] WeightMatrix = new double[ROW_WEIGHT, COL_WEIGHT]; //重み行列
        static public double[,] CopyMatrix = new double[ROW_COPY, COL_COPY]; //コピー行列
        static public double[,] OutputMatrix = new double[ROW_OUT, COL_OUT]; //出力層
    }
}
