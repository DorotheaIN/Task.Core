using System;
using System.Collections.Generic;
using System.Text;

public class Collect
{
    public string Mail { get; set; }

    public string Setid { get; set; }

    public DateTime Time { get;set; }

    public Collect() { }

    public Collect(string mail, string setid, DateTime time)
    {
        this.Mail = mail;
        this.Setid = setid;
        this.Time = time;
    }
}