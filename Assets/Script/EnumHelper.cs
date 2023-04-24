public static class EnumHelper
{
    public enum CounterType
    {
        COUNT_AUTOSAVE = 0,
        COUNT_AUTOSAVE_FILE,
        COUNT_TEAM_ID,
        COUNT_PLAYER_ID,
        COUNT_CUP_ID,
        COUNT_LEAGUE_ID,
        COUNT_FIX_ID,
        COUNT_LG_COMM_ID,
        COUNT_SHOW_DEBUG,
        COUNT_HINT_NUMBER,
        COUNT_END
    }

    public enum QualityType
    {
        QUALITY_BEST = 0,
        QUALITY_GOOD,
        QUALITY_AVERAGE,
        QUALITY_BAD,
        QUALITY_END
    }

    public enum TeamCompare
    {
        TEAM_COMPARE_LEAGUE_RANK = 0,
        TEAM_COMPARE_LEAGUE_LAYER,
        TEAM_COMPARE_UNSORTED,
        TEAM_COMPARE_AV_SKILL,
        TEAM_COMPARE_OFFENSIVE,
        TEAM_COMPARE_DEFENSE,
        TEAM_COMPARE_END
    }

    public enum PlayerPos
    {
        PLAYER_POS_GOALIE = 0,
        PLAYER_POS_DEFENDER,
        PLAYER_POS_MIDFIELDER,
        PLAYER_POS_FORWARD,
        PLAYER_POS_ANY,
        PLAYER_POS_END
    }

    public enum PlayerStreak
    {
        PLAYER_STREAK_COLD = -1,
        PLAYER_STREAK_NONE,
        PLAYER_STREAK_HOT
    }

    public enum PlayerInjury
    {
        PLAYER_INJURY_NONE = 0,
        PLAYER_INJURY_CONCUSSION,
        PLAYER_INJURY_PULLED_MUSCLE,
        PLAYER_INJURY_HAMSTRING,
        PLAYER_INJURY_GROIN,
        PLAYER_INJURY_FRAC_ANKLE,
        PLAYER_INJURY_RIB,
        PLAYER_INJURY_LEG,
        PLAYER_INJURY_BROK_ANKLE,
        PLAYER_INJURY_ARM,
        PLAYER_INJURY_SHOULDER,
        PLAYER_INJURY_LIGAMENT,
        PLAYER_INJURY_CAREER_STOP,
        PLAYER_INJURY_END
    }

    public enum LeagueCupValue
    {
        LEAGUE_CUP_VALUE_NAME = 0,
        LEAGUE_CUP_VALUE_SHORT_NAME,
        LEAGUE_CUP_VALUE_SID,
        LEAGUE_CUP_VALUE_SYMBOL,
        LEAGUE_CUP_VALUE_ID,
        LEAGUE_CUP_VALUE_FIRST_WEEK,
        LEAGUE_CUP_VALUE_LAST_WEEK,
        LEAGUE_CUP_VALUE_WEEK_GAP,
        LEAGUE_CUP_VALUE_YELLOW_RED,
        LEAGUE_CUP_VALUE_AVERAGE_SKILL,
        LEAGUE_CUP_VALUE_AVERAGE_CAPACITY,
        LEAGUE_CUP_VALUE_SKILL_DIFF,
        LEAGUE_CUP_VALUE_END
    }

    public enum TeamAttribute
    {
        TEAM_ATTRIBUTE_STYLE = 0,
        TEAM_ATTRIBUTE_BOOST,
        TEAM_ATTRIBUTE_END
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
        PLAYER_VALUE_GAMES = 0,
        PLAYER_VALUE_GOALS,
        PLAYER_VALUE_SHOTS,
        PLAYER_VALUE_CARD_YELLOW,
        PLAYER_VALUE_CARD_RED,
        PLAYER_VALUE_END
    }

    public enum PlayerCompareAttrib
    {
        PLAYER_COMPARE_ATTRIBUTE_GAME_SKILL = 0,
        PLAYER_COMPARE_ATTRIBUTE_POS,
        PLAYER_COMPARE_ATTRIBUTE_LEAGUE_GOALS,
        PLAYER_COMPARE_ATTRIBUTE_END
    }

    public enum PlayerListAttributeValue
    {
        PLAYER_LIST_ATTRIBUTE_NAME = 0,
        PLAYER_LIST_ATTRIBUTE_CPOS,
        PLAYER_LIST_ATTRIBUTE_POS,
        PLAYER_LIST_ATTRIBUTE_CSKILL,
        PLAYER_LIST_ATTRIBUTE_SKILL,
        PLAYER_LIST_ATTRIBUTE_FITNESS,
        PLAYER_LIST_ATTRIBUTE_GAMES,
        PLAYER_LIST_ATTRIBUTE_SHOTS,
        PLAYER_LIST_ATTRIBUTE_GOALS,
        PLAYER_LIST_ATTRIBUTE_STATUS,
        PLAYER_LIST_ATTRIBUTE_CARDS,
        PLAYER_LIST_ATTRIBUTE_AGE,
        PLAYER_LIST_ATTRIBUTE_ETAL,
        PLAYER_LIST_ATTRIBUTE_VALUE,
        PLAYER_LIST_ATTRIBUTE_WAGE,
        PLAYER_LIST_ATTRIBUTE_CONTRACT,
        PLAYER_LIST_ATTRIBUTE_TEAM,
        PLAYER_LIST_ATTRIBUTE_LEAGUE_CUP,
        PLAYER_LIST_ATTRIBUTE_END
    }

    public enum PlayerInfoAttributeValue
    {
        PLAYER_INFO_ATTRIBUTE_NAME = 0,
        PLAYER_INFO_ATTRIBUTE_POS,
        PLAYER_INFO_ATTRIBUTE_CPOS,
        PLAYER_INFO_ATTRIBUTE_SKILL,
        PLAYER_INFO_ATTRIBUTE_CSKILL,
        PLAYER_INFO_ATTRIBUTE_FITNESS,
        PLAYER_INFO_ATTRIBUTE_ETAL,
        PLAYER_INFO_ATTRIBUTE_AGE,
        PLAYER_INFO_ATTRIBUTE_HEALTH,
        PLAYER_INFO_ATTRIBUTE_VALUE,
        PLAYER_INFO_ATTRIBUTE_WAGE,
        PLAYER_INFO_ATTRIBUTE_CONTRACT,
        PLAYER_INFO_ATTRIBUTE_GAMES_GOALS,
        PLAYER_INFO_ATTRIBUTE_YELLOW_CARDS,
        PLAYER_INFO_ATTRIBUTE_BANNED,
        PLAYER_INFO_ATTRIBUTE_STREAK,
        PLAYER_INFO_ATTRIBUTE_CAREER,
        PLAYER_INFO_ATTRIBUTE_OFFERS,
        PLAYER_INFO_ATTRIBUTE_END
    }

    public enum FixtureCompare
    {
        FIXTURE_COMPARE_DATE = 0,
        FIXTURE_COMPARE_END
    }

    public enum TableElementValues
    {
        TABLE_PLAYED = 0,
        TABLE_WON,
        TABLE_DRAW,
        TABLE_LOST,
        TABLE_GF,
        TABLE_GA,
        TABLE_GD,
        TABLE_PTS,
        TABLE_END
    }

    public enum Status0Value
    {
        STATUS_NONE = 0,
        STATUS_MAIN,
        STATUS_SHOW_LIVE_GAME,
        STATUS_LIVE_GAME_PAUSE,
        STATUS_LIVE_GAME_CHANGE,
        STATUS_SHOW_TEAM_LIST,
        STATUS_SHOW_PLAYER_INFO,
        STATUS_BROWSE_TEAMS,
        STATUS_TEAM_SELECTION,
        STATUS_SHOW_LAST_MATCH,
        STATUS_SHOW_LAST_MATCH_PAUSE,
        STATUS_SHOW_LAST_MATCH_ABORT,
        STATUS_SHOW_LAST_MATCH_STATS,
        STATUS_SHOW_FIXTURES,
        STATUS_SHOW_FIXTURES_WEEK,
        STATUS_SHOW_TABLES,
        STATUS_SHOW_FINANCES,
        STATUS_SHOW_TRANSFER_LIST,
        STATUS_SHOW_USER_HISTORY,
        STATUS_GET_LOAN,
        STATUS_PAY_LOAN,
        STATUS_SHOW_EVENT,
        STATUS_JOB_OFFER_SUCCESS,
        STATUS_JOB_OFFER_FIRE_FINANCE,
        STATUS_JOB_OFFER_FIRE_FAILURE,
        STATUS_TRANSFER_OFFER_USER,
        STATUS_TRANSFER_OFFER_CPU,
        STATUS_CUSTOM_STRUCTURE,
        STATUS_SHOW_LEAGUE_RESULTS,
        STATUS_SHOW_SEASON_RESULTS,
        STATUS_SHOW_LEAGUE_STATS,
        STATUS_SHOW_SEASON_HISTORY,
        STATUS_SHOW_PLAYER_LIST,
        STATUS_FIRE_PLAYER,
        STATUS_USER_MANAGEMENT,
        STATUS_SHOW_PREVIEW,
        STATUS_SAVE_GAME,
        STATUS_LOAD_GAME,
        STATUS_LOAD_GAME_SPLASH,
        STATUS_QUERY_UNFIT,
        STATUS_QUERY_QUIT,
        STATUS_QUERY_USER_NO_TURN,
        STATUS_GENERATE_TEAMS,
        STATUS_SPONSOR_CONTINUE,
        STATUS_SHOW_YA,
        STATUS_SET_YA_PERCENTAGE,
        STATUS_QUERY_KICK_YOUTH,
        STATUS_SELECT_MM_FILE_LOAD,
        STATUS_SELECT_MM_FILE_ADD,
        STATUS_SELECT_MM_FILE_IMPORT,
        STATUS_SELECT_MM_FILE_EXPORT,
        STATUS_PLACE_BET,
        STATUS_SHOW_JOB_EXCHANGE,
        STATUS_JOB_EXCHANGE_SHOW_TEAM,
        STATUS_SPLASH,
        STATUS_END
    }


    /** 
     * Live Game
     * **/
    public enum LiveGameEventType
    {
        /** This is the 'main' event, nothing in
        particular is happening; one of the teams
        is in possession of the ball. */
        LIVE_GAME_EVENT_GENERAL = 0, /* 0 */
        LIVE_GAME_EVENT_START_MATCH, /* 1 */
        LIVE_GAME_EVENT_HALF_TIME, /* 2 */
        LIVE_GAME_EVENT_EXTRA_TIME, /* 3 */
        LIVE_GAME_EVENT_END_MATCH, /* 4 */
        LIVE_GAME_EVENT_LOST_POSSESSION, /* 5 */
        LIVE_GAME_EVENT_SCORING_CHANCE, /* 6 */
        LIVE_GAME_EVENT_HEADER, /* 7 */
        LIVE_GAME_EVENT_PENALTY, /* 8 */
        LIVE_GAME_EVENT_FREE_KICK, /* 9 */
        LIVE_GAME_EVENT_GOAL, /* 10 */
        LIVE_GAME_EVENT_OWN_GOAL, /* 11 */
        LIVE_GAME_EVENT_POST, /* 12 */
        LIVE_GAME_EVENT_MISS, /* 13 */
        LIVE_GAME_EVENT_SAVE, /* 14 */
        LIVE_GAME_EVENT_CROSS_BAR, /* 15 */
        LIVE_GAME_EVENT_FOUL, /* 16 */
        LIVE_GAME_EVENT_FOUL_YELLOW, /* 17 */
        LIVE_GAME_EVENT_FOUL_RED, /* 18 */
        LIVE_GAME_EVENT_FOUL_RED_INJURY, /* 19 */
        LIVE_GAME_EVENT_SEND_OFF, /* 20 */
        LIVE_GAME_EVENT_INJURY, /* 21 */
        /** An injury that permits the player to
        continue after some brief time. */
        LIVE_GAME_EVENT_TEMP_INJURY, /* 22 */
        LIVE_GAME_EVENT_PENALTIES, /* 23 */
        LIVE_GAME_EVENT_STADIUM, /* 24 */
        LIVE_GAME_EVENT_STADIUM_BREAKDOWN, /* 25 */
        LIVE_GAME_EVENT_STADIUM_RIOTS, /* 26 */
        LIVE_GAME_EVENT_STADIUM_FIRE, /* 27 */
        LIVE_GAME_EVENT_SUBSTITUTION, /* 28 */
        LIVE_GAME_EVENT_STRUCTURE_CHANGE, /* 29 */
        LIVE_GAME_EVENT_STYLE_CHANGE_ALL_OUT_DEFEND, /* 30 */
        LIVE_GAME_EVENT_STYLE_CHANGE_DEFEND, /* 31 */
        LIVE_GAME_EVENT_STYLE_CHANGE_BALANCED, /* 32 */
        LIVE_GAME_EVENT_STYLE_CHANGE_ATTACK, /* 33 */
        LIVE_GAME_EVENT_STYLE_CHANGE_ALL_OUT_ATTACK, /* 34 */
        LIVE_GAME_EVENT_BOOST_CHANGE_ANTI, /* 35 */
        LIVE_GAME_EVENT_BOOST_CHANGE_OFF, /* 36 */
        LIVE_GAME_EVENT_BOOST_CHANGE_ON, /* 37 */
        LIVE_GAME_EVENT_END
    }

    public enum LiveGameUnitArea
    {
        LIVE_GAME_UNIT_AREA_DEFEND = 0,
        LIVE_GAME_UNIT_AREA_MIDFIELD,
        LIVE_GAME_UNIT_AREA_ATTACK,
        LIVE_GAME_UNIT_AREA_END
    }

    public enum LiveGameUnitTime
    {
        LIVE_GAME_UNIT_TIME_FIRST_HALF = 0,
        LIVE_GAME_UNIT_TIME_SECOND_HALF,
        LIVE_GAME_UNIT_TIME_EXTRA_TIME,
        LIVE_GAME_UNIT_TIME_PENALTIES,
        LIVE_GAME_UNIT_TIME_END
    }

    public enum LiveGameStatValue
    {
        LIVE_GAME_STAT_VALUE_GOALS_REGULAR = 0,
        LIVE_GAME_STAT_VALUE_SHOTS,
        LIVE_GAME_STAT_VALUE_SHOT_PERCENTAGE,
        LIVE_GAME_STAT_VALUE_POSSESSION,
        LIVE_GAME_STAT_VALUE_PENALTIES,
        LIVE_GAME_STAT_VALUE_FOULS,
        LIVE_GAME_STAT_VALUE_CARDS,
        LIVE_GAME_STAT_VALUE_REDS,
        LIVE_GAME_STAT_VALUE_INJURIES,
        LIVE_GAME_STAT_VALUE_END
    }

    public enum LiveGameStatArray
    {
        LIVE_GAME_STAT_ARRAY_SCORERS = 0,
        LIVE_GAME_STAT_ARRAY_YELLOWS,
        LIVE_GAME_STAT_ARRAY_REDS,
        LIVE_GAME_STAT_ARRAY_INJURED,
        LIVE_GAME_STAT_ARRAY_END
    }

    public enum GameTeamValue
    {
        GAME_TEAM_VALUE_GOALIE = 0,
        GAME_TEAM_VALUE_DEFEND,
        GAME_TEAM_VALUE_MIDFIELD,
        GAME_TEAM_VALUE_ATTACK,
        GAME_TEAM_VALUE_END
    }


}
