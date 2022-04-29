using AutoMapper;
using Client.Data;
using Client.Data.DTO;
using Client.Data.Model;
using Client.Data.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services
{
    public class SubSkillService
    {
        private readonly DB appDBContext;
        private readonly IMapper mapper;
        public SubSkillService(DB appDBContext, IMapper mapper)
        {
            this.appDBContext = appDBContext;
            this.mapper = mapper;
        }

        public async Task<HashSet<TreeItem>> LoadSubSkillsData(TreeItem treeItem)
        {

            if (treeItem.IsWSOS)
            {
                var WSOS = await appDBContext.WSOS.Include(w => w.SubSkills).FirstOrDefaultAsync(w => w.Id == treeItem.Id);
                return WSOS.SubSkills
                            .Select((s, i) => new TreeItem()
                            {
                                Name = s.Name,
                                Id = s.Id,
                                IsWSOS = false,
                                //HasChild = appDBContext.SubSkills.Count(a => s.Id == a.ParentSubSkillId) != 0,
                                ViewNumber = treeItem.ViewNumber + "." + (i + 1).ToString()
                            })
                            .ToHashSet();
            }
            else
            {
                var SubSkill = await appDBContext.SubSkills
                                                    .Include(s => s.InverseParentSubSkill)
                                                    .FirstOrDefaultAsync(s => s.Id == treeItem.Id);
                var result = SubSkill.InverseParentSubSkill
                                .Select((s, i) => new TreeItem()
                                {
                                    Name = s.Name,
                                    Id = s.Id,
                                    IsWSOS = false,
                                    ViewNumber = treeItem.ViewNumber + "." + (i + 1).ToString()
                                })
                                .ToHashSet();
                return result;
            }
        }

        public async Task<SubSkill?> LoadSubSkillFromTreeItem(TreeItem treeItem)
        {
            if (treeItem.IsWSOS)
            {
                return null;
            }
            else
            {
                var data = await appDBContext.SubSkills.Include(s => s.SubSkillTasks).ThenInclude(ss => ss.Author)
                                                        .Include(s => s.SubSkillCriteria).AsQueryable()
                                                        .FirstOrDefaultAsync(s => s.Id == treeItem.Id);
                return data;
            }
        }

        public async Task<bool> DeleteSubSkill(SubSkill subSkill)
        {
            try
            {
                await RecursionDeleteSubSkill(subSkill);
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task RecursionDeleteSubSkill(SubSkill subSkill)
        {

            subSkill = appDBContext.SubSkills.Include(s => s.InverseParentSubSkill).FirstOrDefault(s => s.Id == subSkill.Id);

            foreach (var item in subSkill.InverseParentSubSkill)
            {
                await RecursionDeleteSubSkill(item);
            }
            appDBContext.SubSkills.Remove(subSkill);
        }

        public async Task<int> QuantityChildSubSkills(SubSkill subSkill)
        {
            var quantity = 0;
            subSkill = appDBContext.SubSkills.Include(s => s.InverseParentSubSkill).FirstOrDefault(s => s.Id == subSkill.Id);
            foreach (var item in subSkill.InverseParentSubSkill)
            {
                quantity += await QuantityChildSubSkills(item);
            }
            quantity += subSkill.InverseParentSubSkill.Count;
            return quantity;
        }

        public async Task<bool> CreateSubSkill(UpdateSubSkillDto updateSubSkillDto)
        {
            var subSkill = mapper.Map<SubSkill>(updateSubSkillDto);
            try
            {
                appDBContext.Add(subSkill);
                await appDBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                appDBContext.ChangeTracker.Clear();
                return false;
            }
        }

        public async Task<bool> UpdateSubSkill(UpdateSubSkillDto updateSubSkillDto)
        {
            var oldSubSkill = await appDBContext.SubSkills.AsAsyncEnumerable().FirstOrDefaultAsync(s => s.Id == updateSubSkillDto.Id);
            mapper.Map(updateSubSkillDto, oldSubSkill);
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

        public async Task<SubSkill> GetSubSkill(int id)
        {
            var va = await appDBContext.SubSkills.AsAsyncEnumerable().FirstOrDefaultAsync(s => s.Id == id);
            return va;
        }

        public async Task<bool> SaveChangesAsync()
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

        public async Task<IEnumerable<SubSkill>> SearchContainName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return await Task.Run(() => appDBContext.SubSkills.ToEnumerable());
            }
            return await Task.Run(() => appDBContext.SubSkills.ToEnumerable().Where(s => s.Name.Contains(value)));
        }

        public async Task<IEnumerable<SubSkill>> GetAllSubSkills()
        {
            return await Task.Run(() => appDBContext.SubSkills.ToEnumerable());
        }
    }
}
