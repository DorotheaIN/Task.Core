using System;
using System.Collections.Generic;
using System.Text;

public class DetailedSet:Set
{
    public List<Todo> todos { get; set; }

    public DetailedSet() { }

    public DetailedSet(Set set)
    {
        this.Id = set.Id;
        this.Name = set.Name;
        this.Createdtime = set.Createdtime;
        this.Tag = set.Tag;
        this.Deadline = set.Deadline;
        this.Creatermail = set.Creatermail;
        this.State = set.State;
    }
}
