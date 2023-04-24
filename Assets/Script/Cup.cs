using System.Collections.Generic;
using UnityEngine;
using static Clonefoot;
public class Cup 
{
    public string name;
    public string short_name;
    public string symbol;
    public string sid;

    public int id;
    public int group;
    public int lastWeek;
    public int weekGap;
    public int addWeek;
    public int yellowRed;
    public int nextFixtureUpdateWeek;
    public int nextFixtureUpdateWeekRound;

    public float talentDiff;

    public List<string> properties;
    public List<CupRound> rounds;
    public List<Team> byeTeams;
    public List<Team> teams;
    public List<Team> teamNames;
    public List<Fixture> fixtures;



    public int CupHasTables(int clid)
    {
        Cup cup = CupFromClid(clid);
        for (int i = cup.rounds.Count - 1; i >= 0; i--)
        {
            if (cup.rounds[i].tables.Count > 0)
            {
                return i;
            }
        }
        return -1;
    }

    public Cup CupFromClid(int clid)
    {
        foreach (Cup cp in Cups)
        {
            if (cp.id == clid)
            {
                return cp;
            }
        }

       Debug.LogWarning(string.Format("CupFromClid: didn't find cup with id {0}", clid));
        return null;    
    }

}

public class CupChooseTeam
{
    public string sid;
    public int numberOfTeams;
    public int startIdx;
    public int endIdx;
    public bool randomly;
    public bool generate;
}

public class CupRound
{
    public bool homeAway;
    public int replay;
    public bool neutral;
    public bool randomise_teams;
    public int roundRobinNumberOfGroups;   
    public int roundRobinNumberOfAdvance;
    public int roundRobinNumberOfBestAdvance;
    public int newTeams;
    public int byes;
    public int delay;
    public object[] twoMatchWeeks; // TODO:: review this shit
    public bool twoMatchweek;
    public List<Team> teams;
    public List<Team> teamsAdvance;
    public List<Team> chooseTeams; //TODO:: review this
    public List<Table> tables;
}
