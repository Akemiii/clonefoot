public class Misc
{
    public static int MiscFloatCompare(float first, float second)
    {
        if (first > second)
            return -1;
        else if (first < second)
            return 1;

        return 0;
    }

    public static int MiscIntCompare(int first, int second)
    {
        if (first > second)
            return -1;
        else if (first < second)
            return 1;

        return 0;
    }

    public static bool QueryIntegerIsInArray(int item, int[] array, int max)
    {
        for (int i = 0; i < max; i++)
        {
            if (item == array[i])
            {
                return true;
            }
        }

        return false;
    }



}
