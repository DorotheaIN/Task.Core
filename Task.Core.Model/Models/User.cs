using System;
using System.Collections.Generic;
using System.Text;
public class User
{
    /// <summary>
    /// 用户邮箱
    /// </summary>
    public string Mail { get; set; }
    /// <summary>
    /// 用户名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 用户密码
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// 用户介绍
    /// </summary>
    public string Intro { get; set; }
    /// <summary>
    /// 用户创建时间
    /// </summary>
    public DateTime Time { get; set; }
}