using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManager.Core.Service.BASE;
using TaskManager.Core.IService;

namespace TaskManager.Core.Service
{
    public class UserService:BaseService<User>,IUserService
    {
    }
}
