public static class EnumHelper
{
    public enum CounterType
    {
        AUTOSAVE = 0,
        AUTOSAVE_FILE,
        TEAM_ID,
        PLAYER_ID,
        CUP_ID,
        LEAGUE_ID,
        FIX_ID,
        LG_COMM_ID,
        SHOW_DEBUG,
        HINT_NUMBER,
        END
    }

    public enum QualityType
    {
        BEST = 0,
        GOOD,
        AVERAGE,
        BAD,
        END
    }

    public enum TeamCompare
    {
        LEAGUE_RANK = 0,
        LEAGUE_LAYER,
        UNSORTED,
        AV_SKILL,
        OFFENSIVE,
        DEFENSE,
        END
    }

    public enum PlayerPos
    {
        GOALIE = 0,
        DEFENDER,
        MIDFIELDER,
        FORWARD,
        ANY,
        END
    }

    public enum PlayerStreak
    {
        COLD = -1,
        NONE,
        HOT
    }

    public enum PlayerInjury
    {
        NONE = 0,
        CONCUSSION,
        PULLED_MUSCLE,
        HAMSTRING,
        GROIN,
        FRAC_ANKLE,
        RIB,
        LEG,
        BROK_ANKLE,
        ARM,
        SHOULDER,
        LIGAMENT,
        CAREER_STOP,
        END
    }

    public enum LeagueCupValue
    {
        NAME = 0,
        SHORT_NAME,
        SID,
        SYMBOL,
        ID,
        FIRST_WEEK,
        LAST_WEEK,
        WEEK_GAP,
        YELLOW_RED,
        AVERAGE_SKILL,
        AVERAGE_CAPACITY,
        SKILL_DIFF,
        END
    }

    public enum TeamAttribute
    {
        STYLE = 0,
        BOOST,
        END
    }

    public enum FinanceValueType
    {
        FIN_PRIZE = 0, /**< Prize money at the end of the season. */
        FIN_DEBTS, /**< User's debts. */
        FIN_MONEY, /**< User's money. */
        FIN_TICKETS, /**< Ticket income (weekly).  */
        FIN_JOURNEY, /**< Journey costs (weekly). */
        FIN_WAGES, /**< Wages (weekly). */
        FIN_SCOUT, /**< Scout wage (weekly). */
        FIN_PHYSIO, /**< Physio wage (weekly). */
        FIN_TRANSFERS_IN, /**< Transfer fees income (weekly). */
        FIN_TRANSFERS_OUT, /**< Transfer fees spent (weekly). */
        FIN_STADIUM, /**< Stadium improvement (weekly). */
        FIN_STAD_BILLS, /**< Bills for riots or fire or so (weekly). */
        FIN_END
    }

    public enum PlayerValue
    {
        GAMES = 0,
        GOALS,
        SHOTS,
        CARD_YELLOW,
        CARD_RED,
        END
    }

    public enum PlayerCompareAttrib
    {
        GAME_SKILL = 0,
        POS,
        LEAGUE_GOLS,
        END
    }

    public enum PlayerListAttributeValue
    {
        NAME = 0,
        CPOS,
        POS,
        CSKILL,
        SKILL,
        FITNESS,
        GAMES,
        SHOTS,
        GOALS,
        STATUS,
        CARDS,
        AGE,
        ETAL,
        VALUE,
        WAGE,
        CONTRACT,
        TEAM,
        LEAGUE_CUP,
        END
    }

    public enum PlayerInfoAttributeValue
    {
        NAME = 0,
        POS,
        CPOS,
        SKILL,
        CSKILL,
        FITNESS,
        ETAL,
        AGE,
        HEALTH,
        VALUE,
        WAGE,
        CONTRACT,
        GAMES_GOLS,
        YELLOW_CARDS,
        BANNED,
        STREAK,
        CAREER,
        OFFERS,
        END
    }

    public enum FixtureCompare
    {
        DATE = 0,
        END
    }

    public enum TableElementValues
    {
        PLAYED = 0,
        WON,
        DRAW,
        LOST,
        GF,
        GA,
        GD,
        PTS,
        END
    }

    public enum Status0Value
    {
        NONE = 0,
        MAIN,
        SHOW_LIVE_GAME,
        LIVE_GAME_PAUSE,
        LIVE_GAME_CHANGE,
        SHOW_TEAM_LIST,
        SHOW_PLAYER_INFO,
        BROWSE_TEAMS,
        TEAM_SELECTION,
        SHOW_LAST_MATCH,
        SHOW_LAST_MATCH_PAUSE,
        SHOW_LAST_MATCH_ABORT,
        SHOW_LAST_MATCH_STATS,
        SHOW_FIXTURES,
        SHOW_FIXTURES_WEEK,
        SHOW_TABLES,
        SHOW_FINANCES,
        SHOW_TRANSFER_LIST,
        SHOW_USER_HISTORY,
        GET_LOAN,
        PAY_LOAN,
        SHOW_EVENT,
        JOB_OFFER_SUCCESS,
        JOB_OFFER_FIRE_FINANCE,
        JOB_OFFER_FIRE_FAILURE,
        TRANSFER_OFFER_USER,
        TRANSFER_OFFER_CPU,
        CUSTOM_STRUCTURE,
        SHOW_LEAGUE_RESULTS,
        SHOW_SEASON_RESULTS,
        SHOW_LEAGUE_STATS,
        SHOW_SEASON_HISTORY,
        SHOW_PLAYER_LIST,
        FIRE_PLAYER,
        USER_MANAGEMENT,
        SHOW_PREVIEW,
        SAVE_GAME,
        LOAD_GAME,
        LOAD_GAME_SPLASH,
        QUERY_UNFIT,
        QUERY_QUIT,
        QUERY_USER_NO_TURN,
        GENERATE_TEAMS,
        SPONSOR_CONTINUE,
        SHOW_YA,
        SET_YA_PERCENTAGE,
        QUERY_KICK_YOUTH,
        SELECT_MM_FILE_LOAD,
        SELECT_MM_FILE_ADD,
        SELECT_MM_FILE_IMPORT,
        SELECT_MM_FILE_EXPORT,
        PLACE_BET,
        SHOW_JOB_EXCHANGE,
        JOB_EXCHANGE_SHOW_TEAM,
        SPLASH,
        END
    }


    /** 
     * Live Game
     * **/
    public enum LiveGameEventType
    {
        /** This is the 'main' event, nothing in
        particular is happening; one of the teams
        is in possession of the ball. */
        GENERAL = 0, /* 0 */
        START_MATCH, /* 1 */
        HALF_TIME, /* 2 */
        EXTRA_TIME, /* 3 */
        END_MATCH, /* 4 */
        LOST_POSSESSION, /* 5 */
        SCORING_CHANCE, /* 6 */
        HEADER, /* 7 */
        PENALTY, /* 8 */
        FREE_KICK, /* 9 */
        GOAL, /* 10 */
        OWN_GOAL, /* 11 */
        POST, /* 12 */
        MISS, /* 13 */
        SAVE, /* 14 */
        CROSS_BAR, /* 15 */
        FOUL, /* 16 */
        FOUL_YELLOW, /* 17 */
        FOUL_RED, /* 18 */
        FOUL_RED_INJURY, /* 19 */
        SEND_OFF, /* 20 */
        INJURY, /* 21 */
        /** An injury that permits the player to
        continue after some brief time. */
        TEMPO_INJURY, /* 22 */
        PENALTIES, /* 23 */
        STADIUM, /* 24 */
        STADIUM_BREAKDOWN, /* 25 */
        STADIUM_RIOTS, /* 26 */
        STADIUM_FIRE, /* 27 */
        SUBSTITUTION, /* 28 */
        STRUCTURE_CHANGE, /* 29 */
        STYLE_CHANGE_ALL_OUT_DEFEND, /* 30 */
        STYLE_CHANGE_DEFEND, /* 31 */
        STYLE_CHANGE_BALANCED, /* 32 */
        STYLE_CHANGE_ATTACK, /* 33 */
        STYLE_CHANGE_ALL_OUT_ATTACK, /* 34 */
        BOOST_CHANGE_ANTI, /* 35 */
        BOOST_CHANGE_OFF, /* 36 */
        BOOST_CHANGE_ON, /* 37 */
        END
    }

    public enum LiveGameUnitArea
    {
        DEFEND = 0,
        MIDFIELD,
        ATTACK,
        END
    }

    public enum LiveGameUnitTime
    {
        FIRST_HALF = 0,
        SECOND_HALF,
        EXTRA_TIME,
        PENALTIES,
        END
    }

    public enum LiveGameStatValue
    {
        GOALS_REGULAR = 0,
        SHOTS,
        SHOT_PERCENTAGE,
        POSSESSION,
        PENALTIES,
        FOULS,
        CARDS,
        REDS,
        INJURIES,
        END
    }

    public enum LiveGameStatArray
    {
        SCORERS = 0,
        YELLOWS,
        REDS,
        INJURED,
        END
    }

    public enum GameTeamValue
    {
        GOALIE = 0,
        DEFEND,
        MIDFIELD,
        ATTACK,
        END
    }


}
