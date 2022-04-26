using Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public class SkillService
    {
        private readonly DB appDBContext;

        public SkillService(DB appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<HashSet<Skill>> GetSkills()
        {
            return await appDBContext.Skills.ToHashSetAsync();
        }

    }
}
