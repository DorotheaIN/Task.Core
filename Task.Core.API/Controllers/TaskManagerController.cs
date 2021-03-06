using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Core.IService;
using TaskManager.Core.Service;

namespace TaskManager.Core.API.Controllers
{
    [Route("")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        ISetService setService = new SetService();
        ITodoService todoService = new TodoService();
        IDetailedSetService detailedSetService = new DetailedSetService();
        IUserService userService = new UserService();
        ICollectService collectService = new CollectService();
        InvokeCon invokeCon = new InvokeCon();

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        [HttpGet("Login")]
        public async Task<LoginState> Login(string mail, string pass)
        {
            User model = await userService.QueryByID(mail);
            LoginState loginState = new LoginState();
            if (pass == model.Password)
            {
                loginState.token = invokeCon.GetTokenCli().ToString();
                loginState.name = model.Name;
                loginState.avator = model.Avator;
                return loginState;
            }
            else
            {
                loginState.token = "";
                return loginState;
            }
        }
        /// <summary>
        /// 根据邮箱获取用户信息
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [HttpGet("GetUserByMail")]
        public async Task<User> GetUserByMail(string mail)
        {
            return await userService.QueryByID(mail);
        }
/*        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        [HttpGet("amul")]
        public int Mmul(int a, int b)
        {
            return invokeCon.MultiplicationCli(a, b);
        }
*/


        /// <summary>
        /// 获取所有任务集
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllSet")]
        public async Task<List<DetailedSet>> GetAllSet()
        {
            return await detailedSetService.Query();
        }

        /// <summary>
        /// 根据用户获取所有任务集
        /// </summary>
        /// <param name="creatermail">用户邮箱</param>
        /// <returns></returns>
        [HttpGet("GetSetByCreater")]
        public async Task<List<DetailedSet>> GetSetByCreater(string creatermail)
        {
            return await detailedSetService.QueryByCreater(creatermail);
        }

        /// <summary>
        /// 获取所有公开任务集
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllPublicSet")]
        public async Task<List<DetailedSet>> GetAllPublicSet()
        {
            return await detailedSetService.QueryByState(1);
        }

        /// <summary>
        /// 创建任务集
        /// </summary>
        /// <param name="id">任务id</param>
        /// <param name="name">任务名</param>
        /// <param name="createtime">创建时间</param>
        /// <param name="tag">标签</param>
        /// <param name="ddl">截止日期</param>
        /// <param name="creatermail">创建者邮箱</param>
        /// <param name="state">状态：0 私人 1 公开</param>
        /// <returns></returns>
        [HttpPost("AddSet")]
        public async Task<int> AddSet(string id,string name,DateTime createtime,string tag,DateTime ddl,string creatermail,int state)
        {
            Set model = new Set(id,name,createtime,tag,ddl, creatermail, state);

            return await setService.Add(model);
        }
        /// <summary>
        /// 删除任务集
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteSet")]
        public async Task<bool> DeleteSet(string id)
        {
            return await setService.DeleteById(id);
        }
        /// <summary>
        /// 更新任务集
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="createtime"></param>
        /// <param name="tag"></param>
        /// <param name="ddl"></param>
        /// <param name="creatermail"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost("UpdateSet")]
        public async Task<bool> UpdateSet(string id, string name, DateTime createtime, string tag, DateTime ddl, string creatermail, int state)
        {
            Set model = new Set(id, name, createtime, tag, ddl, creatermail, state);
            return await setService.Update(model);
        }

        /// <summary>
        /// 获取某任务集的所有任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetTodoBySet")]
        public async Task<List<Todo>> GetTodosBySet(string id)
        {
            return await todoService.Query(d => d.Setid == id);
        }

        /// <summary>
        /// 创建新任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="deadline"></param>
        /// <param name="finishtime"></param>
        /// <param name="state"></param>
        /// <param name="setid"></param>
        /// <returns></returns>
        [HttpPost("AddTodo")]
        public async Task<int> AddTodo(string id,string name,DateTime deadline,DateTime finishtime,int state, string setid)
        {
            Todo model = new Todo(id, name, deadline, finishtime, state, setid);
            return await todoService.Add(model);
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("DeleteTodo")]
        public async Task<bool> DeleteTodo(string id)
        {
            return await todoService.DeleteById(id);
        }
        
        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="deadline"></param>
        /// <param name="finishtime"></param>
        /// <param name="state"></param>
        /// <param name="setid"></param>
        /// <returns></returns>
        [HttpPost("UpdateTodo")]
        public async Task<bool> UpdateTodo(string id, string name, DateTime deadline, DateTime finishtime, int state, string setid)
        {
            Todo model = new Todo(id, name, deadline, finishtime, state, setid);
            return await todoService.Update(model);
        }
        
        /// <summary>
        /// 收藏任务集
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="setid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost("CollectSet")]
        public async Task<int> CollectSet(string mail, string setid, DateTime time)
        {
            Collect model = new Collect(mail, setid, time);
            return await collectService.Add(model);
        }
        /// <summary>
        /// 取消收藏任务集
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="setid"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpPost("UncollectSet")]
        public async Task<bool> UncollectSet(string mail, string setid, DateTime time)
        {
            Collect model = new Collect(mail, setid, time);
            return await collectService.Delete(model);
        }
        /// <summary>
        /// 获取收藏状态
        /// </summary>
        /// <param name="mail"></param>
        /// <param name="setid"></param>
        /// <returns></returns>
        [HttpGet("GetCollectState")]
        public async Task<bool> GetCollectState(string mail,string setid)
        {
            List<Collect> collects = await collectService.Query(d => d.Mail == mail);
            var isExisted = collects.Find(m => m.Setid == setid);
            if(isExisted == null || isExisted.Setid == "string")
            {
                return false;
            }else
            {
                return true;
            }
        }
        /// <summary>
        /// 获取活动图
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [HttpGet("GetActiveMap")]
        public async Task<List<ActiveMap>> GetActiveMap (string mail)
        {
            IActiveMapService activeMapService = new ActivieMapService();
            return await activeMapService.Query(mail);
        }
        /// <summary>
        /// 获取收藏的任务集
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        [HttpGet("GetCollectSet")]
        public async Task<List<DetailedSet>> GetCollectSet(string mail)
        {
            return await detailedSetService.QueryCollectSet(mail);
        }

    }
}
