using System;
using System.Collections.Generic;
using System.Text;

public class TaskSet
{
    /// <summary>
    /// 任务集主键
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 任务集名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 创造者id
    /// </summary>
    public int CreaterId { get; set; }
    /// <summary>
    /// 标签
    /// </summary>
    public string tag { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;
}
