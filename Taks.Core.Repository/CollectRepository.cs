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
    public class CollectRepository:BaseRepository<Collect>,ICollectRepository
    {
    }
}
