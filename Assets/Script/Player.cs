using static EnumHelper;
using static Clonefoot;
using System;

public class Player
{
    public string name;
    
    public int pos;
    public int curPos;
    public int health;
    public int recovery;
    public int id;
    public int value;
    public int wage;
    public int offers;
    public int streak;

    public float skill;
    public float cskill;
    public float talent;
    public float etal;
    public float fitness;
    public float lsu;
    public float age;
    public float peak_age;
    public float peak_region;
    public float contract;
    public float streak_prob;
    public int streak_count;

    public bool participation;

    public PlayerGamesGoals[] games_goals;
    public PlayerCard[] cards;
    public Team team;

    public int[] career = new int[(int)PlayerValue.PLAYER_VALUE_END];

    public static bool QueryPlayerIsYouth(Player p)
    {
        return p.age <= PlayerAgeLowerLimit;
    }

    public static bool QueryPlayerIsCpu(Player p)
    {
        return false; // TODO:: Ajustar aqui depois que criar a função TeamIsUser(Team t)
    }

    public static void PlayerStreakResetCount(Player p)
    {
        int randomValue = new Random().Next(PLAYER_STREAK_LOCK_LENGTH_LOWER, PLAYER_STREAK_LOCK_LENGTH_UPPER + 1);
        p.streak_count = -randomValue;
    }


}


public class PlayerCard
{
    /** Numerical id of the league or cup. */
    public int clid;
    public int yellow;
    public int red;
}

public class PlayerGamesGoals
{
    /** Numerical id of the league or cup. */
    public int clid;
    /** Number of games the player played. */
    public int games;
    /** Number of goals (scored for field players or conceded for goalies). */
    public int goals;
    /** Number of shots (taken or faced). */
    public int shots;
}

public class PlayerListAttribute
{
    public bool[] on_off = new bool[(int)PlayerListAttributeValue.PLAYER_LIST_ATTRIBUTE_END];
}