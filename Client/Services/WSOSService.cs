using Client.Data;
using Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Client.Services;
namespace Client.Services
{
    public class WSOSService
    {
        private readonly DB appDBContext;
        private readonly SubSkillService subSkillService;

        public WSOSService(DB appDBContext, SubSkillService subSkillService)
        {
            this.appDBContext = appDBContext;
            this.subSkillService = subSkillService;

        }

        public async Task<HashSet<TreeItem>> GetWSOSWithoutNestingAsync()
        {

            var data = await appDBContext.WSOS.AsAsyncEnumerable()
                                                .Select((w, i) => new TreeItem()
                                                {
                                                    Name = w.SectionName,
                                                    Id = w.Id,
                                                    IsWSOS = true,
                                                    ViewNumber = (i + 1).ToString(),
                                                    //HasChild = true
                                                })
                                                .ToHashSetAsync();
            return data;
        }

        


        public async Task<bool> CreateWSOS(WSOS _WSOS)
        {
            try
            {
                await appDBContext.WSOS.AddAsync(_WSOS);
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<int> QuantityChildSubSkills(int _WSOSId)
        {
            var findedWSOS = await appDBContext.WSOS.Include(w => w.SubSkills).AsAsyncEnumerable().FirstOrDefaultAsync(w => w.Id == _WSOSId);

            var tasks = new List<Task<int>>();
            foreach (var item in findedWSOS.SubSkills)
            {
                tasks.Add(subSkillService.QuantityChildSubSkills(item));
            }
            await Task.WhenAll(tasks);
            var sum = findedWSOS.SubSkills.Count;
            foreach (var item in tasks)
            {
                sum += item.Result;
            }

            return sum;
        }

        public async Task<bool> RecursionDeleteWSOS(int _WSOSId)
        {

            var findedWSOS = await appDBContext.WSOS.Include(w => w.SubSkills).AsAsyncEnumerable().FirstOrDefaultAsync(w => w.Id == _WSOSId);
            var tasks = new List<bool?>() ;
            foreach (var item in findedWSOS.SubSkills)
            {
                tasks.Add(await subSkillService.DeleteSubSkill(item));
            }
            if (tasks.FirstOrDefault(t => t == false) == null)
            {
                try
                {
                    appDBContext.WSOS.Remove(findedWSOS);
                    await appDBContext.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                        
                }
            }
            else return false;

            }
 
        }
    }

