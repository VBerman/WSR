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
    public class TaskResolvingService
    {
        private readonly DB appDBContext;
        private readonly AuthenticationStateProvider apiAuthenticationStateProvider;

        public TaskResolvingService(DB appDBContext, AuthenticationStateProvider apiAuthenticationStateProvider)
        {
            this.appDBContext = appDBContext;
            this.apiAuthenticationStateProvider = apiAuthenticationStateProvider;
        }
        public async Task<SubSkillTaskResolving?> GetResolvingTask(int id)
        {
            var data = await appDBContext.SubSkillTaskResolvings.Include(s => s.SubSkillTask).Include(s => s.Competitor).FirstOrDefaultAsync(s => s.Id == id);
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
            var newTaskResolving = await appDBContext.AddAsync(new SubSkillTaskResolving() { StartTime = DateTime.Now, SubSkillTask = subSkillTask, CompetitorId = idUser, IsFullResolving = isFullResolving, Score = 0 });
            await appDBContext.SaveChangesAsync();

            return newTaskResolving.Entity;

        }
        public async Task<SubSkillTaskResolving> EndTask(SubSkillTaskResolving taskResolving)
        {
            taskResolving.EndTime = DateTime.Now;
            taskResolving.ResolvingDuration = taskResolving.EndTime - taskResolving.StartTime;
            await appDBContext.SaveChangesAsync();
            return taskResolving;
        }
    }
}
