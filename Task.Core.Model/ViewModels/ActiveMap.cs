using System;
using System.Collections.Generic;
using System.Text;

public class ActiveMap
{
    public string date { get; set; }

    public int count { get; set; }

    public List<Todo> todos { get; set; }

    public ActiveMap() { }

    public ActiveMap(string date, int count,List<Todo> todos)
    {
        this.date = date;
        this.count = count;
        this.todos = todos;
    }
}
