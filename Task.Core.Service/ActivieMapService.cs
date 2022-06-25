using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.IRepository.BASE;
using TaskManager.Core.IService;
using TaskManager.Core.Repository.BASE;

namespace TaskManager.Core.Service
{
    public class ActivieMapService:IActiveMapService
    {

        public IBaseRepository<Todo> baseDalTodo = new BaseRepository<Todo>();
        public IBaseRepository<Set> baseDalSet = new BaseRepository<Set>();
        [DllImport("Analysis.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static IntPtr Get(char[] date);
        public async Task<List<ActiveMap>> Query(string mail)
        {
            List<Todo> todos = await baseDalTodo.Query(d => d.State == 1 );
            List<Set> sets = await baseDalSet.Query(d => d.Creatermail == mail);
            List<string> setids = new List<string>();
            sets.ForEach((set) =>
            {
                setids.Add(set.Id);
            });
            List<ActiveMap> activeMaps = new List<ActiveMap>();
            todos.ForEach(todo =>
            {
                if (setids.Contains(todo.Setid))
                {
                    string date = todo.Finishtime.ToString("yyyy/MM/dd HH:mm:ss");
                    IntPtr pR = Get(date.ToCharArray());
                    string strR = Marshal.PtrToStringAnsi(pR);
                    var isExisted = activeMaps.Find(m => m.date == strR);
                    if (isExisted == null || isExisted.count == 0)
                    {
                        List<Todo> done = new List<Todo>();
                        done.Add(todo);
                        ActiveMap activeMap = new ActiveMap(strR, 1, done);
                        activeMaps.Add(activeMap);
                    }
                    else
                    {
                        isExisted.todos.Add(todo);
                        isExisted.count++;
                    }
                }
          
            });
/*            var isExisted = activeMaps.Find(m => m.date == "2001-01-01");*/
            return activeMaps;
        }

    }
}
