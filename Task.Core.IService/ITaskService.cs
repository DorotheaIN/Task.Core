using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManager.Core.IService.BASE;

namespace TaskManager.Core.IService
{
    public interface ITaskService:IBaseService<TaskSet>
    {
        int Sum(int i, int j);
/*        int Add(TaskSet model);
        bool Delete(TaskSet model);
        bool Upate(TaskSet model);
        List<TaskSet> Query(Expression<Func<TaskSet, bool>> whereExpression);*/
    }
}
