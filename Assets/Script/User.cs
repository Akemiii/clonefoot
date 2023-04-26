using System.Collections.Generic;
using static Variables;

public class User
{
    public string name;
    public Team team;
    public int teamId;
    public OptionList options;
    public List<Event> events;
    public List<UserHistory> history;
    public int[] counters = new int[(int)CounterValue.COUNT_USER_END];
    public int money;
    public int debt;
    public int[,] moneyIn = new int[2,(int)MonIn.MON_IN_END];
    public int[,] moneyOut = new int[2, (int)MonOut.MON_OUT_END];
    public int scout;
    public int physio;
    public LiveGame liveGame;
    public UserSponsor userSponsor;
    public YouthAcademy youthAcademy;
    public string mMatchesFile;
    public List<string> mMatches;
    public Bet[] bets = new Bet[2];

    public static User Usr(int i) => users[i];
    public static User CurrentUser(int curUser) => Usr(curUser);

}

public class Event
{
    public User user;
    public int type;
    public int value1;
    public int value2;
    public object valuePointer;
    public string valueString;

}

public class MemMatch
{
    public string countryName;
    public string competitionName;
    public bool neutral;
    public int userTeam;
    public LiveGame lg;
}

public class UserHistory
{
    public int season;
    public int week;
    public int type;
    public string teamName;
    public string[] stringArray = new string[3];
}

public class UserSponsor
{
    public string name;
    public int benefit;
    public int contract;
}

public enum MonIn
{
    MON_IN_PRIZE = 0,
    MON_IN_TICKET,
    MON_IN_SPONSOR,
    MON_IN_BETS,
    MON_IN_TRANSFERS,
    MON_IN_END
}

public enum MonOut
{
    MON_OUT_WAGE = 0,
    MON_OUT_PHYSIO,
    MON_OUT_SCOUT,
    MON_OUT_YC,
    MON_OUT_YA,
    MON_OUT_JOURNEY,
    MON_OUT_COMPENSATIONS,
    MON_OUT_BETS,
    MON_OUT_BOOST,
    MON_OUT_TRANSFERS,
    MON_OUT_STADIUM_IMPROVEMENT,
    MON_OUT_STADIUM_BILLS,
    MON_OUT_TRAINING_CAMP,
    MON_OUT_END
}

public enum CounterValue
{
    COUNT_USER_LOAN = 0, /** How many weeks until user has to pay back his loan. */
    COUNT_USER_OVERDRAWN, /**< How often the user overdrew his bank account. */
    COUNT_USER_POSITIVE, /**< How many weeks until the bank account has to be positive
		       or at least not overdrawn). */
    COUNT_USER_SUCCESS, /**< How successful the user is. */
    COUNT_USER_WARNING, /**< Whether there was already a warning about rumours (new coach). */
    COUNT_USER_INC_CAP, /**< How many weeks until the stadium capacity is increased. */
    COUNT_USER_INC_SAF, /**< How often the stadium safety was increased (in a week). */
    COUNT_USER_STADIUM_CAPACITY, /**< Counter for building stadium seats. */
    COUNT_USER_STADIUM_SAFETY, /**< Counter for increasing stadium safety. */
    COUNT_USER_SHOW_RES, /**< Whether the latest result is shown when the main window gets refreshed. */
    COUNT_USER_TOOK_TURN, /**< Whether the user took his turn in a week round. */
    COUNT_USER_NEW_SPONSOR, /**< A new sponsor offer has to be shown. */
    COUNT_USER_END
}

public enum UserHistoryType
{
    USER_HISTORY_START_GAME = 0,
    USER_HISTORY_FIRE_FINANCE,
    USER_HISTORY_FIRE_FAILURE,
    USER_HISTORY_JOB_OFFER_ACCEPTED,
    USER_HISTORY_END_SEASON,
    USER_HISTORY_PROMOTED,
    USER_HISTORY_RELEGATED,
    USER_HISTORY_WIN_FINAL,
    USER_HISTORY_LOSE_FINAL,
    USER_HISTORY_REACH_CUP_ROUND,
    USER_HISTORY_CHAMPION,
    USER_HISTORY_END
}

public enum EventType
{
    EVENT_TYPE_WARNING = 0,
    EVENT_TYPE_PLAYER_LEFT,
    EVENT_TYPE_PAYBACK,
    EVENT_TYPE_OVERDRAW,
    EVENT_TYPE_JOB_OFFER,
    EVENT_TYPE_FIRE_FINANCE,
    EVENT_TYPE_FIRE_FAILURE,
    EVENT_TYPE_TRANSFER_OFFER_USER,
    EVENT_TYPE_TRANSFER_OFFER_CPU,
    EVENT_TYPE_TRANSFER_OFFER_REJECTED_BETTER_OFFER,
    EVENT_TYPE_TRANSFER_OFFER_REJECTED_FEE_WAGE,
    EVENT_TYPE_TRANSFER_OFFER_REJECTED_FEE,
    EVENT_TYPE_TRANSFER_OFFER_REJECTED_WAGE,
    EVENT_TYPE_TRANSFER_OFFER_MONEY,
    EVENT_TYPE_TRANSFER_OFFER_ROSTER,
    EVENT_TYPE_PLAYER_CAREER_STOP,
    EVENT_TYPE_CHARITY,
    EVENT_TYPE_END
}