using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.IService
{
    public interface IDetailedSetService
    {
        Task<List<DetailedSet>> Query();

        Task<List<DetailedSet>> QueryByCreater(string creatermail);

        Task<List<DetailedSet>> Modify(List<Set> sets);

        Task<List<DetailedSet>> QueryByState(int state);

        Task<List<DetailedSet>> QueryCollectSet(string mail);
    }
}
