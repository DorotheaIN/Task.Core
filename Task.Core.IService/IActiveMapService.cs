using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.IService
{
    public interface IActiveMapService
    {
        Task<List<ActiveMap>> Query();
    }
}
