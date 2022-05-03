using Client.Data.Enums;
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
        private readonly UserService userService;

        public TaskResolvingService(DB appDBContext, UserService userService)
        {
            this.appDBContext = appDBContext;
            this.userService = userService;
        }
        public async Task<SubSkillTaskResolving?> GetResolvingTask(int id)
        {
            var data = await appDBContext.SubSkillTaskResolvings.Include(s => s.SubSkillTask).Include(s => s.Competitor).FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }


        public async Task<SubSkillTaskResolving?> CurrentResolvingTask(SubSkillTask subSkillTask)
        {
            var idUser = await userService.GetUserId();
            var data = await appDBContext.SubSkillTaskResolvings.AsAsyncEnumerable()
                        .FirstOrDefaultAsync(r => r.CompetitorId == idUser &
                                            (r.Status != ResolvingStatus.Checking | r.Status != ResolvingStatus.Checked) &
                                            r.SubSkillTask == subSkillTask);
            return data;
        }

        public async Task<SubSkillTaskResolving> StartTask(SubSkillTask subSkillTask, bool isFullResolving)
        {
            var idUser = await userService.GetUserId();
            var newTaskResolving = await appDBContext.AddAsync(new SubSkillTaskResolving() { StartSolvingTime = DateTime.Now, SubSkillTask = subSkillTask, CompetitorId = idUser, IsFullResolving = isFullResolving, Score = 0 });
            await appDBContext.SaveChangesAsync();

            return newTaskResolving.Entity;

        }
        public async Task<SubSkillTaskResolving> EndTask(SubSkillTaskResolving taskResolving)
        {
            taskResolving.Status = ResolvingStatus.Solved;
            await appDBContext.SaveChangesAsync();
            return taskResolving;
        }
    }
}
