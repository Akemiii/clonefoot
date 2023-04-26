using static EnumHelper;
using static Clonefoot;
using static Counters;
using static MathUtil;
using static Misc;

using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
    public int streakCount;

    public float skill;
    public float cskill;
    public float talent;
    public float[] etal;
    public float fitness;
    public float lsu;
    public float age;
    public float peakAge;
    public float peakRegion;
    public float contract;
    public float streakProb;


    public bool participation;

    public List<PlayerGamesGoals> gamesGoals;
    public List<PlayerCard> cards;
    public Team team;

    public int[] career = new int[(int)PlayerValue.END];

    public static bool QueryPlayerIsYouth(Player p)
    {
        return p.age <= PLAYER_AGE_LOWER;
    }

    public static bool QueryPlayerIsCpu(Player p)
    {
        return false; // TODO:: Ajustar aqui depois que criar a função TeamIsUser(Team t)
    }

    public static void PlayerStreakResetCount(Player p)
    {
        int randomValue = new System.Random().Next(PLAYER_STREAK_LOCK_LENGTH_LOWER, PLAYER_STREAK_LOCK_LENGTH_UPPER + 1);
        p.streakCount = -randomValue;
    }

    public Player New(Team t, float avarageTalent, bool newId)
    {
        float skillFactor = (float)new System.Random().NextDouble() * 1.5f - PLAYER_AVERAGE_TALENT_VARIANCE;

        Player p = new Player();

        name = (newId) ? team.names_file : null;
        id = (newId) ? GetNextID(CounterType.PLAYER_ID) : -1;
        pos = GetPositionFromStructure(team.structure, team.players.Count);
        curPos = pos;
        age = (float)MathGaussDist(PLAYER_AGE_LOWER, PLAYER_AGE_UPPER);
        peakAge = Rnd(PLAYER_PEAK_AGE_LOWER +
                    (pos == (int)PlayerPos.GOALIE ? PLAYER_PEAK_AGE_GOALIE_ADDITION : 0), PLAYER_PEAK_AGE_UPPER +
                    (pos == (int)PlayerPos.GOALIE ? PLAYER_PEAK_AGE_GOALIE_ADDITION : 0));
        peakRegion = (float)MathGaussDist(PLAYER_PEAK_REGION_LOWER, PLAYER_PEAK_REGION_UPPER);
        talent = Mathf.Clamp(avarageTalent * skillFactor, 0, PLAYER_MAX_SKILL);
        skill = PlayerSkillFromTalent(p);
        cskill = skill;
        PlayerEstimateTalent(p);    
        fitness = Rnd(PLAYER_FITNESS_LOWER, PLAYER_FITNESS_UPPER);
        health = recovery = 0;
        value = PlayerAssignValue(p);
        wage = PlayerAssignWage(p);
        contract = Rnd(PLAYER_CONTRACT_LOWER, PLAYER_CONTRACT_UPPER);
        lsu = Rnd(PLAYER_LSU_LOWER, PLAYER_LSU_UPPER);
        cards = new List<PlayerCard>();
        gamesGoals = new List<PlayerGamesGoals>();

        for (int i = 0; i < (int)PlayerValue.END; i++)
            career[i] = 0;

        team = t;
        participation = false;
        offers = 0;
        streak = (int)PlayerStreak.NONE;
        streakCount = 0;
        streakProb = 0;

        return p;
    }

    public void PlayerCompleteDef(Player p, float avarageTalent)
    {

    }

    public void PlayerEstimateTalent(Player pl)
    {
        float[] scountDeviance = new float[(int)QualityType.END];

        float[] devianceBound = new float[2]
            {pl.talent - pl.skill, PLAYER_MAX_SKILL - pl.talent};

        for (int i = 0; i < (int)QualityType.END; i++)
        {
            scountDeviance[i] = (i + 1) *PLAYER_MAX_SKILL *
                (PLAYER_ETAL_SCOUT_FACTOR / 100);

            for (int j = 0; j < 2; j++)
                devianceBound[j] = Math.Min(devianceBound[j], scountDeviance[i]);

            pl.etal[i] = Rnd(pl.talent - devianceBound[0],
                                   pl.talent + devianceBound[1]);
        }
    }

    public int PlayerAssignValue(Player pl)
    {
        float value = Mathf.Pow(PLAYER_VALUE_SKILL_WEIGHT * pl.skill +
                                (1 - PLAYER_VALUE_SKILL_WEIGHT) *
                                pl.talent * 0.7f, PLAYER_VALUE_POWER);

        if (pl.peakAge > pl.age)
        {
            value *= 1 + PLAYER_SKILL_UPDATE_YOUNGER_FACTOR *
                    (pl.peakAge - pl.age);
        }
        else
        {
            value *= 1 - PLAYER_SKILL_UPDATE_OLDER_FACTOR *
                    (pl.age - pl.peakAge);
        }

        return Mathf.RoundToInt(value);
    }

    public int PlayerAssignWage(Player pl)
    {
        float wage;
        
        wage = (float)Math.Round(pl.value * PLAYER_WAGE_VALUE_FACTOR *
            Rnd(1 - PLAYER_WAGE_RANDOM_DEV,
                 1 + PLAYER_WAGE_RANDOM_DEV), 1);

        return Mathf.RoundToInt(wage);
    }


    public float PlayerSkillFromTalent(Player pl)
    {
        float skill = pl.talent;
        float curAge = pl.peakAge;

        if (pl.age < pl.peakAge)
        {
            while (curAge > pl.age)
            {
                curAge -= (PLAYER_LSU_UPDATE_LIMIT + 2) * 0.0192f;
                if (pl.peakAge - curAge > pl.peakRegion)
                {
                    skill *= (1 - ((pl.peakAge - curAge) *
                        PLAYER_SKILL_UPDATE_YOUNGER_FACTOR +
                        PLAYER_SKILL_UPDATE_YOUNGER_ADD));
                }
            }
        }
        else
        {
            while (curAge < pl.age)
            {
                curAge += (PLAYER_LSU_UPDATE_LIMIT + 2) * 0.0192f;
                if (curAge - pl.peakAge > pl.peakRegion)
                {
                    skill *= (1 - ((curAge - pl.peakAge) *
                        PLAYER_SKILL_UPDATE_OLDER_FACTOR +
                        PLAYER_SKILL_UPDATE_OLDER_ADD));
                }
            }
        }

        if (skill > pl.talent)
        {
            skill = pl.talent;
        }

        return skill;
    }


    public int GetPositionFromStructure(int structure, int playerNumber)
    {
        int position = -1;

        int[] bound = new int[2]
        {
            GetPlace(structure, 3) + 1,
            GetPlace(structure, 3) + GetPlace(structure, 2) + 1
        };

        if (playerNumber == 0 || playerNumber == 11)
        {
            position = (int)PlayerPos.GOALIE;
        }
        else if (playerNumber < bound[0] ||
                (playerNumber > 10 &&
                playerNumber < (11 + (TEAM_CPU_PLAYERS - 11) *
                PLAYER_POS_BOUND1)))
        {
            position = (int)PlayerPos.DEFENDER;
        }
        else if (playerNumber < bound[1] || 
                (playerNumber > 10 &&
                playerNumber < (11 + (TEAM_CPU_PLAYERS - 11) *
                PLAYER_POS_BOUND2)))
        {

            position = (int)PlayerPos.MIDFIELDER;
        }
        else
        {
            position = (int)PlayerPos.FORWARD;
        }

            return position;
    }

    public int PlayerIdIndex(Team tm, int playerId)
    {
        for (int i = 0; i < tm.players.Count; i++)
        {
            if (tm.players[i].id == playerId)
            {
                return i;
            }
        }

        string errorMessage = string.Format("player_id_index: didn't find player with id {0} of team {1}",
                                            playerId, tm.name);
        Debug.LogWarning(errorMessage);
        return -1;
    }

    public Player PlayerOfIdxTeam(Team tm, int number)
    {
        if (tm.players.Count <= number)
        {
            string errorMessage = string.Format("player_of_idx_team: Player list of team {0} too short for number {1}.",
                                                tm.name, number);
            Debug.LogWarning(errorMessage);
        }

        return tm.players[number];
    }

    public static Player PlayerOfIdTeam(Team tm, int id)
    {
        for (int i = 0; i < tm.players.Count; i++)
        {
            if (tm.players[i].id == id)
            {
                return tm.players[i];
            }
        }

        string errorMessage = string.Format("player_of_id_team: didn't find player with id {0} of team {1}.",
                                            id, tm.name);
        Debug.LogWarning(errorMessage);

        return null;
    }

    public bool QueryPlayerIdInTeam(int playerId, Team tm)
    {
        for (int i = 0; i < tm.players.Count; i++)
        {
            if (tm.players[i].id == playerId)
            {
                return true;
            }
        }

        return false;
    }

    public int PlayerAllGamesGoals(Player pl, int type)
    {
        int sum = 0;

        for (int i = 0; i < pl.gamesGoals.Count; i++)
        {
            if (type == (int)PlayerValue.GOALS)
            {
                sum += pl.gamesGoals[i].goals;
            }
            else if (type == (int)PlayerValue.GAMES)
            {
                sum += pl.gamesGoals[i].games;
            }
            else if (type == (int)PlayerValue.SHOTS)
            {
                sum += pl.gamesGoals[i].shots;
            }
        }

        return sum;
    }

    public int PlayerAllCards(Player pl)
    {
        int sum = 0;

        for (int i = 0; i < pl.cards.Count; i++)
        {
            sum += pl.cards[i].yellow;
        }

        return sum;
    }

    public int PlayerCompare(Player a, Player b, object data)
    {
        int returnValue = 0;

        int type = (int)data;

        if(type == (int)PlayerCompareAttrib.GAME_SKILL)
        {
            returnValue = MiscFloatCompare(PlayerGetGameSkill(a, false, true), PlayerGetGameSkill(b, false, true));
        }
        else if (type == (int)PlayerCompareAttrib.POS)
        {
            if (Math.Min(PlayerIdIndex(a.team, a.id), PlayerIdIndex(b.team, b.id)) < 11 &&
             Math.Max(PlayerIdIndex(a.team, a.id), PlayerIdIndex(b.team, b.id)) >= 11)
            {
                returnValue = (PlayerIdIndex(a.team, a.id) > PlayerIdIndex(b.team, b.id)) ? 1 : -1;
            }
            else if (a.cskill == 0)
            {
                returnValue = (b.cskill == 0) ? 0 : 1;
            }
            else if (b.cskill == 0)
            {
                returnValue = (a.cskill == 0) ? 0 : -1;
            }
            else if (b.pos != a.pos)
            {
                returnValue = MiscIntCompare(b.pos, a.pos);
            }
            else
            {
                returnValue = 0;
            }   
        }
        else if(type == (int)PlayerCompareAttrib.LEAGUE_GOLS)
        {
            int goals1 = PlayerGamesGoalsGet(a, a.team.clid, (int)PlayerValue.GOALS);
            int games1 = PlayerGamesGoalsGet(a, a.team.clid, (int)PlayerValue.GAMES);
            int shots1 = PlayerGamesGoalsGet(a, a.team.clid, (int)PlayerValue.SHOTS);
            int goals2 = PlayerGamesGoalsGet(b, b.team.clid, (int)PlayerValue.GOALS);
            int games2 = PlayerGamesGoalsGet(b, b.team.clid, (int)PlayerValue.GAMES);
            int shots2 = PlayerGamesGoalsGet(b, b.team.clid, (int)PlayerValue.SHOTS);

            if(goals1 != goals2)
            {
                returnValue = MiscIntCompare(goals1, goals2);
            }else if (games1 != games2)
            {
                returnValue = MiscIntCompare(games2, games1);
            }
            else
            {
                returnValue = MiscIntCompare(shots2, shots1);
            }
        }
        return returnValue;
    }

    public int PlayerGamesGoalsGet(Player pl, int clid, int type)
    {
        int returnValue = 0;

        for (int i = 0; i < pl.gamesGoals.Count; i++)
        {
            PlayerGamesGoals item = pl.gamesGoals[i];

            if (item.clid == clid)
            {
                switch (type)
                {
                    case (int)PlayerValue.GAMES:
                        returnValue = item.games;
                        break;

                    case (int)PlayerValue.GOALS:
                        returnValue = item.goals;
                        break;

                    case (int)PlayerValue.SHOTS:
                        returnValue = item.shots;
                        break;

                    default:
                        Debug.LogWarning(string.Format("player_games_goals_get: unknown type {0}.", type));
                        break;
                }
            }
        }

        return returnValue;
    }

    public void PlayerGamesGoalsSet(Player pl, int clid, int type, int value)
    {
        int games_goals_value = 0;
        PlayerGamesGoals newPlayerGamesGoals = new PlayerGamesGoals();

        for (int i = 0; i < pl.gamesGoals.Count; i++)
        {
            if (pl.gamesGoals[i].clid == clid)
            {
                if (type == (int)PlayerValue.GAMES)
                    games_goals_value = pl.gamesGoals[i].games + value;
                else if (type == (int)PlayerValue.GOALS)
                    games_goals_value = pl.gamesGoals[i].goals + value;
                else if (type == (int)PlayerValue.SHOTS)
                    games_goals_value = pl.gamesGoals[i].shots + value;

                if (games_goals_value < 0)
                {
                    Console.WriteLine("player_games_goals_set: negative value; setting to 0\n");
                    games_goals_value = 0;
                }

                if (type == (int)PlayerValue.GAMES)
                    pl.gamesGoals[i].games = games_goals_value;
                else if (type == (int)PlayerValue.GOALS)
                    pl.gamesGoals[i].goals = games_goals_value;
                else if (type == (int)PlayerValue.SHOTS)
                    pl.gamesGoals[i].shots = games_goals_value;

                return;
            }
        }

        newPlayerGamesGoals.clid = clid;
        newPlayerGamesGoals.games = newPlayerGamesGoals.goals = newPlayerGamesGoals.shots = 0;

        pl.gamesGoals.Add(newPlayerGamesGoals);

        PlayerGamesGoalsSet(pl, clid, type, value);
    }


    public int PlayerCompareSubstituteFunc(IntPtr a, IntPtr b, IntPtr data)
    {
        var pl1 = Marshal.PtrToStructure<Player>(a);
        var pl2 = Marshal.PtrToStructure<Player>(b);
        int position = Marshal.ReadInt32(data);
        float skill_for_pos1 = PlayerGetCskill(pl1, position, false) *
            (float)Math.Pow(pl1.fitness, PLAYER_FITNESS_EXPONENT);
        float skill_for_pos2 = PlayerGetCskill(pl2, position, false) *
            (float)Math.Pow(pl2.fitness, PLAYER_FITNESS_EXPONENT);
        float game_skill1 = PlayerGetGameSkill(pl1, false, true);
        float game_skill2 = PlayerGetGameSkill(pl2, false, true);
        bool good_structure1 = pl1.team.structure.SubstitutionGoodStructure(position, pl1.pos);//TODO:: Ajuste quando finalizar a classe team
        bool good_structure2 = pl2.team.structure.SubstitutionGoodStructure(position, pl2.pos);//TODO:: Ajuste quando finalizar a classe team

        if (pl1.pos == position && pl2.pos == position)
        {
            return MiscFloatCompare(game_skill1, game_skill2);
        }
        else if (pl1.pos == position)
        {
            return -1;
        }
        else if (pl2.pos == position)
        {
            return 1;
        }
        else if (position != (int)PlayerPos.GOALIE)
        {
            if (good_structure1 && good_structure2)
            {
                return MiscFloatCompare(game_skill1, game_skill2);
            }
            else if (good_structure1)
            {
                return MiscFloatCompare(game_skill1, skill_for_pos2);
            }
            else if (good_structure2)
            {
                return MiscFloatCompare(skill_for_pos1, game_skill2);
            }
            else
            {
                return MiscFloatCompare(skill_for_pos1, skill_for_pos2);
            }
        }
        else
        {
            return MiscFloatCompare(skill_for_pos1, skill_for_pos2);
        }
    }

    public bool PlayerSubstitutionGoodStructure(int oldStructure, int oldPos, int playerPos)
    {
        int[] acceptedStructures = { 532, 442, 352, 433, 343 };
        int newPos = oldStructure - (int)Math.Round(Math.Pow(10, (int)PlayerPos.FORWARD - oldPos)) + (int)Math.Round(Math.Pow(10, (int)PlayerPos.FORWARD - playerPos));

        return QueryIntegerIsInArray(newPos, acceptedStructures, 5);
    }

    public void PlayerCopy(Player pl, Team tm, int insert_at)
    {
        Player newPlayer = pl;

        newPlayer.team = tm;

        tm.players.Insert(insert_at, newPlayer);

        if (insert_at < 11)
        {
            PlayerOfIdxTeam(tm, insert_at).curPos = GetPositionFromStructure(tm.structure, insert_at);
        }
        else
        {
            PlayerOfIdxTeam(tm, insert_at).curPos = PlayerOfIdxTeam(tm, insert_at).pos;
        }

        PlayerOfIdxTeam(tm, insert_at).cskill = PlayerGetCskill(
            PlayerOfIdxTeam(tm, insert_at),
            PlayerOfIdxTeam(tm, insert_at).curPos,
            true
        );
    }

    public void PlayerMove(Team tm1, int player_number, Team tm2, int insert_at)
    {
        Player pl = PlayerOfIdxTeam(tm1, player_number);

        pl.team = tm2;

        tm1.players.RemoveAt(player_number);

        tm2.players.Insert(insert_at, pl);
    }

    public void PlayerSwap(Team tm1, int playerNumber1, Team tm2, int playerNumber2)
    {
        int move = (tm1 == tm2 && playerNumber1 < playerNumber2) ? -1 : 1;

        if (stat0 == (int)Status0Value.LIVE_GAME_PAUSE)
        {
            if ((playerNumber1 < 11 && PlayerIsBanned(PlayerOfIdxTeam(tm1, playerNumber1)) > 0 &&
                PlayerOfIdxTeam(tm1, playerNumber1).participation) ||
               (playerNumber2 < 11 && PlayerIsBanned(PlayerOfIdxTeam(tm2, playerNumber2)) > 0 &&
                PlayerOfIdxTeam(tm2, playerNumber2).participation))
            {
                Debug.LogWarning("You can't replace a banned player.");
                return;
            }
        }

        PlayerMove(tm1, playerNumber1, tm2, playerNumber2);

        if (playerNumber2 < 11)
        {
            PlayerOfIdxTeam(tm2, playerNumber2).curPos = GetPositionFromStructure(tm2.structure, playerNumber2);
        }
        else
        {
            PlayerOfIdxTeam(tm2, playerNumber2).curPos = PlayerOfIdxTeam(tm2, playerNumber2).pos;
        }

        PlayerOfIdxTeam(tm2, playerNumber2).cskill = PlayerGetCskill(PlayerOfIdxTeam(tm2, playerNumber2), PlayerOfIdxTeam(tm2, playerNumber2).curPos, true);

        PlayerMove(tm2, playerNumber2 + move, tm1, playerNumber1);

        if(playerNumber1 < 11)
        {
            PlayerOfIdxTeam(tm1, playerNumber1).curPos = GetPositionFromStructure(tm1.structure, playerNumber1);
        }
        else
        {
            PlayerOfIdxTeam(tm1, playerNumber1).curPos = PlayerOfIdxTeam(tm1, playerNumber1).pos;
        }

        PlayerOfIdxTeam(tm1, playerNumber1).cskill = PlayerGetCskill(PlayerOfIdxTeam(tm1, playerNumber1), PlayerOfIdxTeam(tm1, playerNumber1).curPos, true);
    }

    public float PlayerGetCskill(Player pl, int position, bool check_health)
    {
        float cskill_factor;

        if (check_health &&
           (pl.health != (int)PlayerInjury.NONE ||
            PlayerIsBanned(pl) > 0))
            return 0;

        if (pl.pos != position)
        {
            if (position == (int)PlayerPos.GOALIE ||
               pl.pos == (int)PlayerPos.GOALIE)
                cskill_factor = 0.5f;
            else if (Math.Abs(position - pl.pos) == 2)
                cskill_factor = 0.65f;
            else
                cskill_factor = 0.75f;

            return Math.Min(pl.talent * cskill_factor, pl.skill);
        }
        else
            return pl.skill;
    }

    public int PlayerIsBanned(Player pl)
    {
        Fixture fix = Team.GetFixture(pl.team, false); //TODO:: Ajustar aqui após criar a classe fixture
        int yellowRed = -1, yellow, red;

        if (fix == null)
            return 0;

        if (fix.clid < ID_CUP_START)
            yellowRed = LeagueFromClid(fix.clid).yellow_red; //TODO:: Ajustar aqui após criar a classe league
        else
            yellowRed = CupFromClid(fix.clid).yellow_red; //TODO:: Ajustar aqui após criar a classe Cup

        yellow = PlayerCardGet(pl, fix.clid, (int)PlayerValue.CARD_YELLOW);
        red = PlayerCardGet(pl, fix.clid, (int)PlayerValue.CARD_RED);

        if (red > 0)
            return red;

        if (yellow == yellowRed - 1)
            return -1;

        return 0;
    }

    public int PlayerCardGet(Player pl, int clid, int card_type)
    {
        int return_value = 0;

        for (int i = 0; i < pl.cards.Count; i++)
        {
            if (pl.cards[i].clid == clid)
            {
                if (card_type == (int)PlayerValue.CARD_YELLOW)
                    return_value = pl.cards[i].yellow;
                else
                    return_value = pl.cards[i].red;

                break;
            }
        }

        return return_value;
    }

    public static void PlayerCardSet(Player pl, int clid, int card_type, int value, bool diff)
    {
        int i;
        int? card_value = null;
        PlayerCard newCard = new PlayerCard();

        for (i = 0; i < pl.cards.Count; i++)
        {
            if (pl.cards[i].clid == clid)
            {
                if (card_type == (int)PlayerValue.CARD_YELLOW)
                    card_value = pl.cards[i].yellow;
                else if (card_type == (int)PlayerValue.CARD_RED)
                    card_value = pl.cards[i].red;

                if (diff)
                    card_value += value;
                else
                    card_value = value;

                if (card_value < 0)
                {
                    Debug.LogWarning("PlayerCardSet: negative card value; setting to 0");
                    card_value = 0;
                }

                if (card_type == (int)PlayerValue.CARD_YELLOW)
                    pl.cards[i].yellow = card_value.Value;
                else if (card_type == (int)PlayerValue.CARD_RED)
                    pl.cards[i].red = card_value.Value;

                return;
            }
        }

        newCard.clid = clid;
        newCard.yellow = newCard.red = 0;
        pl.cards.Add(newCard);

        Player player = pl;

        PlayerCardSet(player, clid, card_type, value, diff);
    }



    public float PlayerGetGameSkill(Player pl, bool skill, bool count_special)
    {
        float boost = count_special ?
            1 + PLAYER_BOOST_SKILL_EFFECT * pl.team.boost : 1;
        float streak = count_special ?
            1 + pl.streak * PLAYER_STREAK_INFLUENCE_SKILL : 1;

        return (skill) ? pl.skill * boost * streak *
            (float)Math.Pow(pl.fitness, PLAYER_FITNESS_EXPONENT) :
            pl.cskill * boost * streak *
            (float)Math.Pow(pl.fitness, PLAYER_FITNESS_EXPONENT);
    }
    public void PlayerDecreseFitness(Player pl)
    {
        float goalie_factor = 1 - PLAYER_FITNESS_DECREASE_FACTOR_GOALIE * (pl.curPos == 0 ? 1 : 0);
        float boost_factor = 1 + pl.team.boost * PLAYER_BOOST_FITNESS_EFFECT;
        float streak_factor = 1 + pl.streak * PLAYER_STREAK_INFLUENCE_FITNESS_DECREASE;

        if (pl.age < pl.peakAge - pl.peakRegion)
        {
            pl.fitness -= ((pl.peakAge - pl.peakRegion - pl.age) *
                   PLAYER_FITNESS_DECREASE_YOUNGER_FACTOR +
                    PLAYER_FITNESS_DECREASE_ADD) *
                goalie_factor * boost_factor * streak_factor;
        }
        else if (pl.age > pl.peakAge + pl.peakRegion)
        {
            pl.fitness -= ((pl.age - pl.peakAge - pl.peakRegion) *
                    PLAYER_FITNESS_DECREASE_OLDER_FACTOR +
                    PLAYER_FITNESS_DECREASE_ADD) *
                goalie_factor * boost_factor * streak_factor;
        }
        else
        {
            pl.fitness -= PLAYER_FITNESS_DECREASE_ADD *
                goalie_factor * boost_factor * streak_factor;
        }

        pl.fitness = Math.Max(0, pl.fitness);
    }

    public void PlayerUpdateFitness(Player pl)
    {
        float variance = Rnd(
        1 - PLAYER_FITNESS_INCREASE_VARIANCE,
        1 + PLAYER_FITNESS_INCREASE_VARIANCE);
        float streak_factor =
        1 + (pl.streak * PLAYER_STREAK_INFLUENCE_FITNESS_INCREASE);
        if (pl.participation)
        {
            pl.participation = false;
            return;
        }

        if (pl.age < pl.peakAge - pl.peakRegion)
            pl.fitness += ((pl.peakAge - pl.peakRegion - pl.age) *
                             PLAYER_FITNESS_INCREASE_YOUNGER_FACTOR +
                             PLAYER_FITNESS_INCREASE_ADD) *
                            variance * streak_factor;
        else if (pl.age > pl.peakAge + pl.peakRegion)
            pl.fitness += ((pl.age - pl.peakAge - pl.peakRegion) *
                             PLAYER_FITNESS_INCREASE_OLDER_FACTOR +
                             PLAYER_FITNESS_INCREASE_ADD) *
                            variance * streak_factor;
        else
            pl.fitness += PLAYER_FITNESS_INCREASE_ADD *
                           variance * streak_factor;

        pl.fitness = Math.Min(pl.fitness, 1);

    }


    private float Rnd(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

}


    public class PlayerCard
    {
        public int clid;
        public int yellow;
        public int red;
    }

    public class PlayerGamesGoals
    {
        public int clid;
        public int games;
        public int goals;
        public int shots;
    }

    public class PlayerListAttribute
    {
        public bool[] onOff = new bool[(int)PlayerListAttributeValue.END];
    }