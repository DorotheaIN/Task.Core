using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.IService;
using TaskManager.Core.Service;
using System.Runtime.InteropServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.Core.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        [DllImport("Calculato.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int Sum(int a, int b);

        /// <summary>
        /// Sum接口
        /// </summary>
        /// <param name="i">参数i</param>
        /// <param name="j">参数j</param>
        /// <returns></returns>
        [HttpGet]
        public int Get(int i,int j)
        {
            return Sum(i,j);
        }
        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id">参数id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<List<TaskSet>> Get(int id)
        {
            ITaskService taskService = new TaskService();

            return await taskService.Query(d => d.Id == id);
        }
        /// <summary>
        /// 添加任务集
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createrId"></param>
        /// <param name="tag"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TaskSet>> Add(int id,string name,int createrId,string tag,DateTime time)
        {
            ITaskService taskService = new TaskService();
            TaskSet model = new TaskSet();
            model.Id = id;
            model.Name = name;
            model.CreaterId = createrId;
            model.tag = tag;
            model.CreateTime = time;
            await taskService.Add(model);
            return await taskService.Query(d => d.Id == id);
        }
    }
}
