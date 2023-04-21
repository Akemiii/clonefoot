using System;
using static EnumHelper;

public static class Clonefoot
{
    public const string VERSAO = "0.0.1";
    public const string ANO = "2023";

    public const int ID_LEAGUE_START = 1000;
    public const int ID_CUP_START = 7000;
    public const int PLAYER_STREAK_LOCK_LENGTH_LOWER = 3;
    public const int PLAYER_STREAK_LOCK_LENGTH_UPPER = 6;
    public const int TEAM_CPU_PLAYERS = 20;


    public const float PLAYER_AGE_LOWER = 18;
    public const float PLAYER_AGE_UPPER = 36;
    public const float PLAYER_AVERAGE_TALENT_VARIANCE = 0.75f;
    public const float PLAYER_POS_BOUND1 = .37550f;
    public const float PLAYER_POS_BOUND2 = .75100f;
    public const float PLAYER_PEAK_AGE_GOALIE_ADDITION = 2;
    public const float PLAYER_PEAK_AGE_LOWER = 29;
    public const float PLAYER_PEAK_AGE_UPPER = 32;
    public const float PLAYER_PEAK_REGION_LOWER = 1.5F;
    public const float PLAYER_PEAK_REGION_UPPER = 4;
    public const float PLAYER_MAX_SKILL = 99;
    public const float PLAYER_LSU_UPDATE_LIMIT = 15;
    public const float PLAYER_SKILL_UPDATE_YOUNGER_FACTOR = .00250f;
    public const float PLAYER_SKILL_UPDATE_YOUNGER_ADD = .00250f;
    public const float PLAYER_SKILL_UPDATE_OLDER_FACTOR = .00300F;
    public const float PLAYER_SKILL_UPDATE_OLDER_ADD = .00250F;
    public const float PLAYER_ETAL_SCOUT_FACTOR = 70;

}
public static class Counters
{
    private static int[] counters = new int[Enum.GetValues(typeof(CounterType)).Length];

    public static int GetNextID(CounterType counterType)
    {
        int counterIndex = (int)counterType;
        return counters[counterIndex]++;
    }
}