using System;
using System.Collections.Generic;
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
    public const float PLAYER_BOOST_FITNESS_EFFECT = .8F;
    public const float PLAYER_BOOST_SKILL_EFFECT = 1.25f; 
    public const float PLAYER_CONTRACT_LOWER = 1F;
    public const float PLAYER_CONTRACT_UPPER = 4F;
    public const float PLAYER_ETAL_SCOUT_FACTOR = 70;
    public const float PLAYER_FITNESS_DECREASE_ADD = 12f;
    public const float PLAYER_FITNESS_DECREASE_YOUNGER_FACTOR = 3f;
    public const float PLAYER_FITNESS_DECREASE_OLDER_FACTOR = 7f;
    public const float PLAYER_FITNESS_DECREASE_FACTOR_GOALIE = .5f;
    public const float PLAYER_FITNESS_INCREASE_ADD = .15F;
    public const float PLAYER_FITNESS_INCREASE_YOUNGER_FACTOR = -.0085F;
    public const float PLAYER_FITNESS_INCREASE_OLDER_FACTOR = -.014f;
    public const float PLAYER_FITNESS_INCREASE_VARIANCE = .25F;
    public const float PLAYER_FITNESS_EXPONENT = .25F;
    public const float PLAYER_FITNESS_LOWER = .85F;
    public const float PLAYER_FITNESS_UPPER = 1;
    public const float PLAYER_BOOST_INJURY_EFFECT = .8f;

    public const float LIVE_GAME_FOUL = .11f;
    public const float LIVE_GAME_INJURY = .01f;
    public const float LIVE_GAME_EVENT_GENERAL = .5F;
    public const float LIVE_GAME_POSSESSION_CHANGES = .2F;
    public const float LIVE_GAME_POSSESSION_TEAM_EXPONENT = 4F;
    public const float LIVE_GAME_STADIUM_EVENT_EXPONENT = .0013F;
    public const float LIVE_GAME_SCORING_CHANCE = .3F;
    public const float LIVE_GAME_SCORING_CHANCE_TEAM_EXPONENT = 1.25F;
    public const float LIVE_GAME_FOUL_BY_POSSESSION = .2F;
    public const float LIVE_GAME_FOUL_RED_INJURY = .015F;
    public const float LIVE_GAME_FOUL_RED = .038F;
    public const float LIVE_GAME_FOUL_YELLOW = .28F;


    float_live_game_foul_yellow	28000

    public const float PLAYER_LSU_UPDATE_LIMIT = 15;
    public const float PLAYER_LSU_LOWER = 2f;
    public const float PLAYER_LSU_UPPER = 10f;
    public const float PLAYER_MAX_SKILL = 99;
    public const float PLAYER_PEAK_AGE_GOALIE_ADDITION = 2;
    public const float PLAYER_PEAK_AGE_LOWER = 29;
    public const float PLAYER_PEAK_AGE_UPPER = 32;
    public const float PLAYER_PEAK_REGION_LOWER = 1.5F;
    public const float PLAYER_PEAK_REGION_UPPER = 4;
    public const float PLAYER_POS_BOUND1 = .37550f;
    public const float PLAYER_POS_BOUND2 = .75100f;
    public const float PLAYER_SKILL_UPDATE_YOUNGER_FACTOR = .00250f;
    public const float PLAYER_SKILL_UPDATE_YOUNGER_ADD = .00250f;
    public const float PLAYER_SKILL_UPDATE_OLDER_FACTOR = .00300F;
    public const float PLAYER_SKILL_UPDATE_OLDER_ADD = .00250F;
    public const float PLAYER_STREAK_INFLUENCE_FITNESS_DECREASE = -.12F;
    public const float PLAYER_STREAK_INFLUENCE_FITNESS_INCREASE = .12F;
    public const float PLAYER_STREAK_INFLUENCE_SKILL = .07F;
    public const float PLAYER_VALUE_SKILL_WEIGHT = .65f;
    public const float PLAYER_VALUE_POWER = 3.5f;
    public const float PLAYER_WAGE_VALUE_FACTOR = .01F;
    public const float PLAYER_WAGE_RANDOM_DEV = .15f;

    public const float TEAM_BOOST_FOUL_FACTOR = .4f;

    public static int stat0 = (int)Status0Value.NONE;
    public static int stat1 = (int)Status0Value.MAIN;
    public static int stat2 = (int)Status0Value.SHOW_LIVE_GAME;
    public static int stat3 = (int)Status0Value.LIVE_GAME_PAUSE;
    public static int stat4 = (int)Status0Value.LIVE_GAME_CHANGE;
    public static int stat5 = (int)Status0Value.SHOW_TEAM_LIST;

    public static Country country;

    public static List<League> Ligs => country.leagues;
    public static List<Cup> Cups => country.cups;
    public static List<object> AllCups => country.allcups;

    public static League League(int index) => country.leagues[index];
    public static Cup Cup(int index) => country.cups[index];
    public static object AllCup(int index) => country.allcups[index];


}

public class Country
{
    public string name;      // Name of the country.
    public string symbol;    // Symbol of the country, eg a flag pixmap.
    public string sid;       // Id of the country, eg 'england'.
    public int rating;       // A rating point from 0-10 telling us how good the first league of the country is. Spain, for instance, has rating 10, whereas Ireland has only 5.

    public List<League> leagues;   // Leagues array.
    public List<Cup> cups;      // Cups array.
    public List<object> allcups;// Pointer array holding all cups.

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