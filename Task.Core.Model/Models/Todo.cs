using System;
using System.Collections.Generic;
using System.Text;

public class Todo
{
    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime Deadline { get; set; }

    public DateTime Finishtime { get; set; }

    public int State { get; set; }

    public string Setid { get; set; }

    public Todo() { }

    public Todo(string id, string name, DateTime deadline, DateTime finishtime, int state, string setid)
    {
        this.Id = id;
        this.Name = name;
        this.Deadline = deadline;
        this.Finishtime = finishtime;
        this.State = state;
        this.Setid = setid;
    }
}
