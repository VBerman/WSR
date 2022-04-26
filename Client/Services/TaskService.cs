﻿using Client.Data.Model;
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
           
            var data = await appDBContext.SubSkillTasks.Include(s => s.Author).Include(s => s.SubSkill).FirstOrDefaultAsync(s => s.Id == id);
            return data;
        }
        

    }
}
