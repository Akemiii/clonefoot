using System.Collections.Generic;

public class Team
{
    public string name;
    public string symbol;
    public string names_file;
    public string def_file;
    public string strategy_sid;

    public int clid;
    public int id;
    public int structure;
    public int style;
    public int boost;

    public float average_talent;
    public float luck;

    public Stadium stadium;

    public List<Player> players;
}
public class Stadium
{
    public string name;
    public int capacity;
    public int average_attendance;
    public int possible_attendance;
    public int games;

    public float safety;

}