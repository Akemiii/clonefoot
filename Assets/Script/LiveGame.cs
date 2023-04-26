using System.Collections.Generic;
using static EnumHelper;
using static Clonefoot;
using static Variables;
using static Option;
using static User;
using static Player;
using System;
using UnityEngine;

public class LiveGame
{
    public Fixture fix;
    public int fixId;
    public string[] teamName = new string[2];
    public int attendance;
    public int[] subsLeft = new int[2];
    public int startedGame;
    public int stadiumEvent;
    public float[,] teamValues = new float[2, (int)GameTeamValue.END];
    public float homeAdvantage;
    public List<LiveGameUnit> units;
    public LiveGameStats stats;
    public LiveGameTeamState[] teamStates = new LiveGameTeamState[2];
    public int[] actionIds = new int[2];

    public bool show;


    public LiveGame match = (LiveGame)statp;
    public List<LiveGameUnit> Unis() => match.units;
    public LiveGameUnit Uni(int i) => match.units[i];
    public LiveGameUnit LastUnit() => match.units[match.units.Count - 1];
    public Team[] Tms() => match.fix.teams;
    public Team TeamOne() => match.fix.teams[0];
    public Team TeamTwo() => match.fix.teams[1];
 
    public void LiveGameCalculateFixture(Fixture fix)
    {
        if (stat0 != (int)Status0Value.LIVE_GAME_PAUSE && stat0 != (int)Status0Value.LIVE_GAME_CHANGE)
        {
            LiveGameInitialize(fix);
        }
        else
        {
            stat0 = (int)Status0Value.SHOW_LIVE_GAME;
        }

        GameGetValues(match.fix, match.teamValues, match.homeAdvantage);


        do
        {
            LiveGameUnit liveGameUnit = LastUnit();

            LiveGameCreateUnit();
            LiveGameEvaluateUnit(liveGameUnit);

        } while (LastUnit().gameEvent.type != (int)LiveGameEventType.END_MATCH && stat0 != (int)Status0Value.LIVE_GAME_PAUSE && stat0 != (int)Status0Value.LIVE_GAME_CHANGE);

        if (LastUnit().gameEvent.type == (int)LiveGameEventType.END_MATCH)
        {
            if (stat2 != -1 || stat5 < -1000)
                LgComentaryFreeTokens();
            GamePostMatch(fix);
        }
        else if (stat0 != (int)Status0Value.LIVE_GAME_CHANGE)
        {
            LiveGameResume();
        }
    }

    private void LiveGameInitialize(Fixture fix)
    {
        stat2 = FixtureUserTeamInvolved(fix);

        statp = (stat2 != -1) ? Usr(stat2).liveGame : liveGameTemp;

        //TODO::: pensar em como será o arquivo de configuração do usuário
        show = (stat2 != -1 && (OptionInt("int_opt_user_show_live_game", Usr(stat2).options)) != -1);
                
        LiveGameReset(match, fix, true);

        if (show)
        {
            curUser = stat2;
        }

        GameInitialize(fix);
        match.attendance = fix.attenance;
    
        if(stat2 != -1 || stat5 < -1000)
        {
            LgCommentaryInitialize(fix);
        }    
    }

    public void LiveGameCreateUnit()
    {
        LiveGameUnit gameUnit = new LiveGameUnit();

        if(Unis().Count == 0)
        {
            LiveGameCreateStartUnit();
            return;
        }

        if(Uni(Unis().Count -1).gameEvent.type == (int)LiveGameEventType.END_MATCH)
        {
            Debug.LogWarning("live_game_create_unit: called after end of match.\n");
            return;
        }

        gameUnit.minute = LiveGameGetMinute();
        gameUnit.time = LiveGameGetTime(LastUnit());
        gameUnit.gameEvent.comentary = null;
        gameUnit.gameEvent.team = gameUnit.gameEvent.player = gameUnit.gameEvent.player2 = -1;
        gameUnit.area = LastUnit().area;
        gameUnit.result[0] = LastUnit().result[0];
        gameUnit.result[1] = LastUnit().result[1];

        if(LastUnit().gameEvent.type == (int)LiveGameEventType.HALF_TIME || 
            LastUnit().gameEvent.type == (int)LiveGameEventType.EXTRA_TIME)
        {
            LiveGameEventGeneral(true);
            return;
        }else if(QueryLiveGameEventIsBreak(gameUnit.minute, gameUnit.time))
        {
            gameUnit.gameEvent.type = LiveGameGetBreak();
            gameUnit.possession = LastUnit().possession;
            Unis().Add(gameUnit);
            return;
        }
        else if(gameUnit.time == (int)LiveGameEventType.PENALTIES)
        {
            gameUnit.gameEvent.type = (int)LiveGameEventType.PENALTY;
        }
        else
        {
            LiveGameFillNewUnit(gameUnit);
        }
        Unis().Add(gameUnit);
    }

    public void LiveGameFillNewUnit(LiveGameUnit newUnit)
    {
        LiveGameUnit oldUnit = LastUnit();
        float rndom = UnityEngine.Random.Range(0, 1);
        float stadiumEvent = 1 - Mathf.Pow(TeamOne().stadium.safety, LIVE_GAME_STADIUM_EVENT_EXPONENT);
        float possessionChange;
        float scoringChance = 0;
        float injuryEventProb;
        float foulEventProb;

        possessionChange = LIVE_GAME_EVENT_GENERAL * LIVE_GAME_POSSESSION_CHANGES /
            LiveGamePitTeams(oldUnit, LIVE_GAME_POSSESSION_TEAM_EXPONENT);

        //TODO::: add multiplyer probs for teams
        injuryEventProb = LIVE_GAME_INJURY * (1 + PLAYER_BOOST_INJURY_EFFECT);

        foulEventProb = LIVE_GAME_FOUL * (1 + (TeamOne().boost + TeamTwo().boost) * TEAM_BOOST_FOUL_FACTOR);

        newUnit.possession = oldUnit.possession;

        if(oldUnit.gameEvent.type == (int)LiveGameEventType.GENERAL)
        {
            newUnit.area = LiveGameGetArea(newUnit);
        }

        if (newUnit.area == (int)LiveGameUnitArea.ATTACK)
            scoringChance = LIVE_GAME_SCORING_CHANCE * LiveGamePitTeams(newUnit, LIVE_GAME_SCORING_CHANCE_TEAM_EXPONENT);

        if (rndom < foulEventProb)
            newUnit.gameEvent.type = (int)LiveGameEventType.FOUL;
        else if (rndom < foulEventProb + injuryEventProb)
            newUnit.gameEvent.type = (int)LiveGameEventType.INJURY;
        else if (rndom < foulEventProb + injuryEventProb + stadiumEvent && match.stadiumEvent == -1)
            newUnit.gameEvent.type = (int)LiveGameEventType.STADIUM;
        else if (rndom < foulEventProb + injuryEventProb + stadiumEvent + possessionChange)
        {
            newUnit.gameEvent.type = (int)LiveGameEventType.LOST_POSSESSION;
            newUnit.possession = oldUnit.possession == 1 ? 2 : 1;//TODO:: check values
            if (newUnit.area == (int)LiveGameUnitArea.ATTACK)
            {
                newUnit.area = (int)LiveGameUnitArea.DEFEND;
            }
            else if(newUnit.area == (int)LiveGameUnitArea.DEFEND)
            {
                newUnit.area = (int)LiveGameUnitArea.ATTACK;
            }
        }
        else if(rndom < foulEventProb + injuryEventProb + stadiumEvent + possessionChange + scoringChance)
        {
            newUnit.gameEvent.type = (int)LiveGameEventType.SCORING_CHANCE;
        }
        else
        {
            newUnit.gameEvent.type = (int)LiveGameEventType.GENERAL;
        }

    }

    public void LiveGameCreateStartUnit()
    {
        LiveGameUnit newUnit = null;

        newUnit.gameEvent.player = newUnit.gameEvent.player2 = -1;

        newUnit.minute = 0;
        newUnit.gameEvent.comentary = null;
        newUnit.time = (int)LiveGameUnitTime.FIRST_HALF;
        newUnit.possession = UnityEngine.Random.Range(0, 1);
        newUnit.area = (int)LiveGameUnitArea.MIDFIELD;
        match.startedGame = newUnit.possession;
        newUnit.result[0] = newUnit.result[1] = 0;
        newUnit.gameEvent.type = (int)LiveGameEventType.START_MATCH;
        newUnit.gameEvent.team = newUnit.possession;

        Unis().Add(newUnit);
    }

    public void LiveGameEvaluateUnit(LiveGameUnit unit)
    {
        int type = unit.gameEvent.type;

        if (type == (int)LiveGameEventType.FOUL)
        {
            LiveGameEventFoul();
        }
        else if (type == (int)LiveGameEventType.LOST_POSSESSION)
        {
            LiveGameEventLostPossession();
        }
        else if (type == (int)LiveGameEventType.INJURY)
        {
            LiveGameEventInjury(-1, -1, false);
        }
        else if (type == (int)LiveGameEventType.STADIUM)
        {
            LiveGameEventStadium();
        }
        else if (type == (int)LiveGameEventType.SCORING_CHANCE)
        {
            LiveGameEventScoringChance();
        }
        else if (type == (int)LiveGameEventType.PENALTY)
        {
            LiveGameEventPenalty();
        }
        else if (type == (int)LiveGameEventType.GENERAL)
        {
            LiveGameEventGeneral(false);
        }
        else if (type == (int)LiveGameEventType.START_MATCH)
        {
            LiveGameFinishUnit();
        }
        else if (type == (int)LiveGameEventType.HALF_TIME || type == (int)LiveGameEventType.EXTRA_TIME ||
            type == (int)LiveGameEventType.PENALTIES || type == (int)LiveGameEventType.END_MATCH)
        {
            LiveGameFinishUnit();

            //TODO:: Add user options
            if(type != (int)LiveGameEventType.END_MATCH && show)
            {
                MiscCallbackPauseLiveGame();
            }
        }
    }

    public void LiveGameEventFoul()
    {
        float rndom = UnityEngine.Random.Range(0, 1);
        int type;
        int fouledPlayer;
        int foulPlayer;
        int foulTeam;

        if (UnityEngine.Random.Range(0, 1) > LIVE_GAME_FOUL_BY_POSSESSION *
            GameGetFoulPossessionFactor(Tms()[LastUnit().possession].boost, Tms()[LastUnit().possession == 1 ? 1 : 0].boost))
        {
            foulTeam = LastUnit().gameEvent.team = LastUnit().possession == 1 ? 1 : 0;
            if(Uni(Unis().Count - 2).gameEvent.type == (int)LiveGameEventType.GENERAL)
            {
                fouledPlayer = LastUnit().gameEvent.player = Uni(Unis().Count - 2).gameEvent.player;
            }
            else
            {
                fouledPlayer = LastUnit().gameEvent.player = GameGetPlayer(Tms()[LastUnit().possession], LastUnit().area, 0, -1, false);
            }
            foulPlayer = LastUnit().gameEvent.player2 = GameGetPlayer(Tms()[LastUnit().possession == 1 ? 1 : 0], LastUnit().area, 0, -1, false);
        }
        else
        {
            foulTeam = LastUnit().gameEvent.team = LastUnit().possession;
            fouledPlayer = LastUnit().gameEvent.player = GameGetPlayer(Tms()[LastUnit().possession == 1 ? 1 : 0], LastUnit().area, 0, -1, false);
            foulPlayer = LastUnit().gameEvent.player2 = GameGetPlayer(Tms()[LastUnit().possession], LastUnit().area, 0, -1, false);
        }

        if (rndom < LIVE_GAME_FOUL_RED_INJURY)
            type = (int)LiveGameEventType.FOUL_RED_INJURY;
        else if (rndom < LIVE_GAME_FOUL_RED)
            type = (int)(LiveGameEventType.FOUL_RED);
        else if (rndom < LIVE_GAME_FOUL_YELLOW)
        {
            type = (int)(LiveGameEventType.FOUL_YELLOW);
            PlayerCardSet(PlayerOfIdTeam(Tms()[foulTeam], foulPlayer), match.fix.clid, PlayerValue.CARD_YELLOW)
        }
    }

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
    public int[,] values = new int[2, (int)LiveGameStatValue.END];
    public Player[,] players = new Player[2, (int)LiveGameStatArray.END];
}

public class LiveGameEvent
{
    public int type;
    public int verbosity;
    public int team;
    public int player;
    public int player2;
    public string comentary;
    public int comentaryId;
}

