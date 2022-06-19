using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TaskManager.Core.Repository.sugar;
using TaskManager.Core.IRepository;
using TaskManager.Core.Repository.sugar;
using TaskManager.Core.Repository.BASE;

namespace TaskManager.Core.Repository
{
    public class TaskRepository : BaseRepository<TaskSet>, ITaskReposotory
    {
/*        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<TaskSet> entityDB;

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public TaskRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            DbContext.DbType = DbType.MySql;
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<TaskSet>(db);
        }
        public int Add(TaskSet model)
        {
            var i = db.Insertable(model).ExecuteReturnBigIdentity();
            return i.ObjToInt();
        }

        public bool Delete(TaskSet model)
        {
            var i = db.Deleteable(model).ExecuteCommand();
            return i > 0;
        }

        public List<TaskSet> Query(Expression<Func<TaskSet, bool>> whereExpression)
        {
            return entityDB.GetList(whereExpression);
        }*/

        public int Sum(int i, int j)
        {
            return i + j;
        }

/*        public bool Update(TaskSet model)
        {
            var i = db.Updateable(model).ExecuteCommand();
            return i > 0;
        }*/
    }
}

