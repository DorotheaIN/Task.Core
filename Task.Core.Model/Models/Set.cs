using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 任务集
/// </summary>
public class Set
{

    public string Id { get; set; }

    public string Name { get; set; }

    public DateTime Createdtime { get; set; }

    public string Tag { get; set; }

    public DateTime Deadline { get; set; }

    public string Creatermail { get; set; }

    public int State { get; set; }

    public Set() { }
    public Set(string id, string name, DateTime createtime, string tag, DateTime ddl, string creatermail,int state)
    {
        this.Id = id;
        this.Name = name;
        this.Createdtime = createtime;
        this.Tag = tag;
        this.Deadline = ddl;
        this.Creatermail = creatermail;
        this.State = state;
    }
}
