using static EnumHelper;
using static Clonefoot;
using static Counters;
using static MathUtil;

using System;
using UnityEngine;

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
        return p.age <= PLAYER_AGE_LOWER;
    }

    public static bool QueryPlayerIsCpu(Player p)
    {
        return false; // TODO:: Ajustar aqui depois que criar a função TeamIsUser(Team t)
    }

    public static void PlayerStreakResetCount(Player p)
    {
        int randomValue = new System.Random().Next(PLAYER_STREAK_LOCK_LENGTH_LOWER, PLAYER_STREAK_LOCK_LENGTH_UPPER + 1);
        p.streak_count = -randomValue;
    }

    public Player New(Team team, float average_talent, bool new_id)
    {
        int i;

        float skill_factor = (float)new System.Random().NextDouble() * 1.5f - PLAYER_AVERAGE_TALENT_VARIANCE;

        Player p = new Player();

        name = (new_id) ? team.names_file : null;
        id = (new_id) ? GetNextID(CounterType.COUNT_PLAYER_ID) : -1;
        pos = GetPositionFromStructure(team.structure, team.players.Length);
        curPos = pos;
        age = (float)MathGaussDist(PLAYER_AGE_LOWER, PLAYER_AGE_UPPER);
        peak_age = UnityEngine.Random.Range(PLAYER_PEAK_AGE_LOWER +
                    (pos == (int)PlayerPos.PLAYER_POS_GOALIE ? PLAYER_PEAK_AGE_GOALIE_ADDITION : 0), PLAYER_PEAK_AGE_UPPER +
                    (pos == (int)PlayerPos.PLAYER_POS_GOALIE ? PLAYER_PEAK_AGE_GOALIE_ADDITION : 0));
        peak_region = (float)MathGaussDist(PLAYER_PEAK_REGION_LOWER, PLAYER_PEAK_REGION_UPPER);
        talent = Mathf.Clamp(average_talent * skill_factor, 0, PLAYER_MAX_SKILL);
        skill = PlayerSkillFromTalent(p);
        cskill = skill;




        return p;
    }

    void player_estimate_talent(Player pl)
    {
        float[] scout_deviance = new float[(int)QualityType.QUALITY_END];

        /* the maximal deviance in both directions */
        float[] deviance_bound = new float[2]
            {pl.talent - pl.skill, PLAYER_MAX_SKILL - pl.talent};

        for (int i = 0; i < (int)QualityType.QUALITY_END; i++)
        {
            scout_deviance[i] = (i + 1) *PLAYER_MAX_SKILL *
                (const_float("float_player_etal_scout_factor") / 100);
            /* adjust deviance_bounds with regard to the scout's
               deviance */
            for (int j = 0; j < 2; j++)
                deviance_bound[j] = Math.Min(deviance_bound[j], scout_deviance[i]);

            pl.etal[i] = math_rnd(pl.talent - deviance_bound[0],
                                   pl.talent + deviance_bound[1]);
        }
    }

    public float PlayerSkillFromTalent(Player pl)
    {
        float skill = pl.talent;
        float cur_age = pl.peak_age;

        if (pl.age < pl.peak_age)
        {
            while (cur_age > pl.age)
            {
                cur_age -= (PLAYER_LSU_UPDATE_LIMIT + 2) * 0.0192f;
                if (pl.peak_age - cur_age > pl.peak_region)
                {
                    skill *= (1 - ((pl.peak_age - cur_age) *
                        PLAYER_SKILL_UPDATE_YOUNGER_FACTOR +
                        PLAYER_SKILL_UPDATE_YOUNGER_ADD));
                }
            }
        }
        else
        {
            while (cur_age < pl.age)
            {
                cur_age += (PLAYER_LSU_UPDATE_LIMIT + 2) * 0.0192f;
                if (cur_age - pl.peak_age > pl.peak_region)
                {
                    skill *= (1 - ((cur_age - pl.peak_age) *
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


    public int GetPositionFromStructure(int structure, int player_number)
    {
        int position = -1;

        int[] bound = new int[2]
        {
            GetPlace(structure, 3) + 1,
            GetPlace(structure, 3) + GetPlace(structure, 2) + 1
        };

        if (player_number == 0 || player_number == 11)
        {
            position = (int)PlayerPos.PLAYER_POS_GOALIE;
        }
        else if (player_number < bound[0] ||
                (player_number > 10 &&
                player_number < (11 + (TEAM_CPU_PLAYERS - 11) *
                PLAYER_POS_BOUND1)))
        {
            position = (int)PlayerPos.PLAYER_POS_DEFENDER;
        }
        else if (player_number < bound[1] || 
                (player_number > 10 &&
                player_number < (11 + (TEAM_CPU_PLAYERS - 11) *
                PLAYER_POS_BOUND2)))
        {

            position = (int)PlayerPos.PLAYER_POS_MIDFIELDER;
        }
        else
        {
            position = (int)PlayerPos.PLAYER_POS_FORWARD;
        }

            return position;
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