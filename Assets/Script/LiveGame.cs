using System.Collections.Generic;
using static EnumHelper;

public class LiveGame
{
    public Fixture fix;
    public int fixId;
    public string[] teamName = new string[2];
    public int attendance;
    public int[] subsLeft = new int[2];
    public int startedGame;
    public int stadiumEvent;
    public float[,] teamValues = new float[2, (int)GameTeamValue.GAME_TEAM_VALUE_END];
    public float homeAdvantage;
    public List<LiveGameUnit> units;
    public LiveGameStats stats;
    public LiveGameTeamState[] teamStates = new LiveGameTeamState[2];
    public int[] actionIds = new int[2];
}

public class LiveGameUnit
{
    public int possession;
    public int area;
    public int minute;
    public int time;
    public int[] result = new int[2];
    
    public LiveGameEvent gameEvent;
}

public class LiveGameTeamState
{
    public int structure;
    public int style;
    public bool boost;
    public int[] player_ids = new int[11];
}

public class LiveGameStats
{
    public float possession;
    public int[,] values = new int[2, (int)LiveGameStatValue.LIVE_GAME_STAT_VALUE_END];
    public Player[,] players = new Player[2, (int)LiveGameStatArray.LIVE_GAME_STAT_ARRAY_END];
}

public class LiveGameEvent
{
    public int id;
    public int verbosity;
    public int team;
    public int player;
    public int player2;
    public string comentary;
    public int comentaryId;
}

