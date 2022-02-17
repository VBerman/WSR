using Client.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public class TaskService
    {
        private readonly DB appDBContext;

        public TaskService(DB appDBContext)
        {
            this.appDBContext = appDBContext;

        }

        public async Task<SubSkillTask?> GetSubSkillTask(int id)
        {
            var data = await appDBContext.SubSkillTasks.Include(s => s.TestProject).Include(s => s.Author).Include(s => s.SubSkill).FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }
    }
}
