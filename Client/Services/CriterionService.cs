using Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public class CriterionService
    {
        private readonly DB appDBContext;
        public CriterionService(DB appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        public async Task<bool> CreateCritetion(SubSkillCriterion subSkillCriterion)
        {
            try
            {
                await appDBContext.SubSkillCriteria.AddAsync(subSkillCriterion);
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> UpdateCritetion()
        {
            try
            {
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                appDBContext.ChangeTracker.Clear();
                return false;
            }
        }

        public async Task<bool> DeleteCriterion(int criterionId)
        {
            try
            {
                appDBContext.SubSkillCriteria.Remove(await appDBContext.SubSkillCriteria.FirstOrDefaultAsync(c => c.Id == criterionId));
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
