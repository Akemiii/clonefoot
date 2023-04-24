
using System.Collections.Generic;
using static EnumHelper;
using static Clonefoot;

public class Table
{
    public string name;
    public int clid;
    public int round;
    public List<TableElement> elements;

    public Table TableNew()
    {
        Table table = new Table();

        table.name = null;
        table.clid = -1;
        table.round = -1;
        elements = new List<TableElement>();

        return table;
    }

    public TableElement TableElementNew(Team team, int oldRank)
    {
        TableElement element = new TableElement();

        element.team = team;
        element.teamId = team.id;
        element.oldRank = oldRank;

        for (int i = 0; i < (int)TableElementValues.TABLE_END; i++)
        {
            element.values[i] = 0;
        }

        return element;
    }

    public void TableUpdate(Fixture fix)
    {
        int idx = (fix.result[0, 0] < fix.result[1, 0]) ? 1 : 0;
        TableElement[] elements = new TableElement[2] { null, null };

        TableUpdateGetElements(elements, fix);

        for (int i = 0; i < 2; i++)
        {
            elements[i].values[(int)TableElementValues.TABLE_PLAYED]++;
            elements[i].values[(int)TableElementValues.TABLE_GF] += fix.result[i, 0];
            elements[i].values[(int)TableElementValues.TABLE_GA] += fix.result[i == 0 ? 1 : 0, 0];
            elements[i].values[(int)TableElementValues.TABLE_GD] = elements[i].values[(int)TableElementValues.TABLE_GF] - elements[i].values[(int)TableElementValues.TABLE_GA];
        }

        if (fix.result[0, 0] == fix.result[1, 0])
        {
            for (int i = 0; i < 2; i++)
            {
                elements[i].values[(int)TableElementValues.TABLE_DRAW]++;
                elements[i].values[(int)TableElementValues.TABLE_PTS] += 1;
            }
        }
        else
        {
            elements[idx].values[(int)TableElementValues.TABLE_WON]++;
            elements[idx].values[(int)TableElementValues.TABLE_PTS] += 3;
            elements[1 - idx].values[(int)TableElementValues.TABLE_LOST]++;
        }
    }

    void TableUpdateGetElements(TableElement[] elements, Fixture fix)
    {
        Table table;

        if (fix.clid < ID_CUP_START)
        {
            table = league_from_clid(fix.clid).table;
            for (int i = 0; i < table.elements.Count; i++)
            {
                if (table.elements[i].team == fix.teams[0])
                    elements[0] = table.elements[i];
                else if (table.elements[i].team == fix.teams[1])
                    elements[1] = table.elements[i];
            }
        }
        else
        {
            for (int i = 0; i < cup_get_last_tables(fix.clid).Length; i++)
            {
                table = cup_get_last_tables(fix.clid)[i];

                if (elements[0] == null || elements[1] == null)
                {
                    for (int j = 0; j < table.elements.Count; j++)
                    {
                        if (table.elements[j].team == fix.teams[0])
                            elements[0] = table.elements[j];
                        else if (table.elements[j].team == fix.teams[1])
                            elements[1] = table.elements[j];
                    }
                }
            }
        }
    }

    bool QueryTablesInCountry()
    {
        for (int i = 0; i < Ligs.Count; i++)
        {
            if (Ligs[i].active)
            {
                return true;
            }
        }

        for (int i = 0; i < Cups.Count; i++)
        {
            if (CupHasTables(Cups[i].id) != -1)
            {
                return true;
            }
        }

        return false;
    }


}

public class TableElement
{
    public Team team;
    public int teamId;
    public int oldRank;
    public int[] values = new int[(int)TableElementValues.TABLE_END];

}
