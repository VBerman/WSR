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
        public async Task<SubSkillTaskResolving> GetResolvingTask(int id)
        {
            var data = await appDBContext.SubSkillTaskResolvings.Include(s => s.SubSkillTask).Include(s => s.Competitor).FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }


        public async Task<SubSkillTaskResolving> CurrentResolvingTask(SubSkillTask subSkillTask)
        {
            var idUser = await userService.GetUserId();
            var data = await appDBContext.SubSkillTaskResolvings.AsAsyncEnumerable()
                        .FirstOrDefaultAsync(r => r.CompetitorId == idUser &
                                            (int) r.Status < 3 &
                                            r.SubSkillTask == subSkillTask);
            return data;
        }

        public async Task<SubSkillTaskResolving> AppointingTask(SubSkillTask subSkillTask, int competitorId, int appointingUserId)
        {
            try
            {
                var newTaskResolving = await appDBContext.SubSkillTaskResolvings.AddAsync(
                    new SubSkillTaskResolving(subSkillTask, competitorId, appointingUserId)
                    );
                await appDBContext.SaveChangesAsync();
                return newTaskResolving.Entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

  
        public async Task<bool> SaveChanges()
        {
            try
            {
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        
    }
}
