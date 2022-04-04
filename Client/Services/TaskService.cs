using Client.Data.Model;
using Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly AuthenticationStateProvider apiAuthenticationStateProvider;
        

        public TaskService(DB appDBContext, AuthenticationStateProvider apiAuthenticationStateProvider)
        {
            this.appDBContext = appDBContext;
            this.apiAuthenticationStateProvider = apiAuthenticationStateProvider;
        }

        public async Task<SubSkillTask?> GetSubSkillTask(int id)
        {
            var data = await appDBContext.SubSkillTasks.Include(s => s.TestProject).Include(s => s.Author).Include(s => s.SubSkill).FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }


        public async Task<SubSkillTaskResolving?> CurrentResolvingTask(SubSkillTask subSkillTask)
        {
            var idUser = int.Parse(apiAuthenticationStateProvider.GetAuthenticationStateAsync().Result.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var data = await appDBContext.SubSkillTaskResolvings.AsAsyncEnumerable().FirstOrDefaultAsync(r => r.CompetitorId == idUser && r.EndTime == null && r.SubSkillTask == subSkillTask);
            return data;
        }

        public async Task<SubSkillTaskResolving> StartTask(SubSkillTask subSkillTask, bool isFullResolving)
        {
            var idUser = int.Parse(apiAuthenticationStateProvider.GetAuthenticationStateAsync().Result.User.Claims.FirstOrDefault(c => c.Type == "Id").Value);
            var newTaskResolving = await appDBContext.AddAsync(new SubSkillTaskResolving() { StartTime = DateTime.Now, SubSkillTask = subSkillTask, CompetitorId = idUser, IsFullResolving = isFullResolving });
            await appDBContext.SaveChangesAsync();
            return newTaskResolving.Entity;

        }

    }
}
