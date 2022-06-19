using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using TaskManager.Core.IRepository.BASE;

namespace TaskManager.Core.IRepository
{
    public interface ITaskReposotory:IBaseRepository<TaskSet>
    {
        int Sum(int i, int j);
        //int Add(TaskSet model);
        //bool Delete(TaskSet model);
        //bool Update(TaskSet model);
        //List<TaskSet> Query(Expression<Func<TaskSet, bool>> whereExpression);
    }
}
