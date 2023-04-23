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
}
