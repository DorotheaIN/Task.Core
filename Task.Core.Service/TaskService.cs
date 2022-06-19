using System;
using TaskManager.Core.IService;
using TaskManager.Core.IRepository;
using TaskManager.Core.Repository;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManager.Core.Service.BASE;

namespace TaskManager.Core.Service
{
    public class TaskService : BaseService<TaskSet>,ITaskService
    {
        public ITaskReposotory dal = new TaskRepository();

        /*public int Add(TaskSet model)
        {
            return dal.Add(model);
        }

        public bool Delete(TaskSet model)
        {
            return dal.Delete(model);
        }

        public List<TaskSet> Query(Expression<Func<TaskSet, bool>> whereExpression)
        {
            return dal.Query(whereExpression);
        }*/

        public int Sum(int i, int j)
        {
            return dal.Sum(i, j);
        }

        /*public bool Upate(TaskSet model)
        {
            return dal.Update(model);
        }*/
    }
}
