
using System;

public static class MathUtil
{
    public static int GetPlace(int value, int place)
    {
        if (place < 10)
        {
            return ((value % (int)Math.Pow(10, place)) -
                (value % (int)Math.Pow(10, place - 1))) /
                (int)Math.Pow(10, place - 1);
        }
        else if (place < 20)
        {
            while (value >= (int)Math.Pow(10, place % 10))
            {
                value = (value - value % 10) / 10;
            }
            return value;
        }
        else
        {
            return value % (int)Math.Pow(10, place % 10);
        }
    }

    public static double MathGaussDist(double lower, double upper)
    {
        double result;

        result = (upper - lower) / 6 * MathGaussRand()
            + (upper + lower) / 2;

        if (result < lower)
            result = lower;

        if (result > upper)
            result = upper;

        return result;
    }


    public static double MathGaussRand()
    {
        double V1 = 0, V2 = 0, S = 0;
        int phase = 0;
        double X;

        if (phase == 0)
        {
            double U1, U2;
            do
            {
                U1 = new Random().NextDouble();
                U2 = new Random().NextDouble();

                V1 = 2 * U1 - 1;
                V2 = 2 * U2 - 1;
                S = V1 * V1 + V2 * V2;
            } while (S >= 1 || S == 0);

            X = V1 * Math.Sqrt(-2 * Math.Log(S) / S);
        }
        else
        {
            X = V2 * Math.Sqrt(-2 * Math.Log(S) / S);
        }

        phase = 1 - phase;

        return X;
    }




}
