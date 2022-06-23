using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.IRepository.BASE;
using TaskManager.Core.IService;
using TaskManager.Core.Repository.BASE;

namespace TaskManager.Core.Service
{
    public class DetailedSetService:IDetailedSetService
    {
        public IBaseRepository<Set> baseDalSet = new BaseRepository<Set>();
        public IBaseRepository<Todo> baseDalTodo = new BaseRepository<Todo>();
        public IBaseRepository<Collect> baseDalCollect = new BaseRepository<Collect>();
        public async Task<List<DetailedSet>> Query()
        {
            List<Set> sets = await baseDalSet.Query();
            return await Modify(sets);
        }

        public async Task<List<DetailedSet>> QueryByCreater(string creatermail)
        {
            List<Set> sets = await baseDalSet.Query(d => d.Creatermail == creatermail);
            return await Modify(sets);
        }

        public async Task<List<DetailedSet>> QueryByState(int state)
        {
            List<Set> sets = await baseDalSet.Query(d => d.State == state);
            return await Modify(sets);
        }

        public async Task<List<DetailedSet>> QueryCollectSet(string mail)
        {
            List<Collect> collects = await baseDalCollect.Query(d => d.Mail == mail);
            List<string> ids = new List<string>();
            collects.ForEach((c) =>
            {
                ids.Add(c.Setid);
            });
            List<Set> sets = await baseDalSet.QueryByIDs(ids.ToArray());
            return await Modify(sets);
        }

        public async Task<List<DetailedSet>> Modify(List<Set> sets)
        {
            List<DetailedSet> detailedSets = new List<DetailedSet>();
            foreach (Set set in sets)
            {
                DetailedSet detailedSet = new DetailedSet(set);
                List<Todo> todoArr = await baseDalTodo.Query(d => d.Setid == set.Id);
                detailedSet.todos = todoArr;
                detailedSets.Add(detailedSet);
            }
            return detailedSets;
        }
    }
}
