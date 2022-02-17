using Client.Data;
using Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Client.Services
{
    public class WSOSService
    {
        private readonly DB appDBContext;

        public WSOSService(DB appDBContext)
        {
            this.appDBContext = appDBContext;

        }

        public async Task<HashSet<TreeItem>> GetAllWSOSAsync()
        {

            var data = await appDBContext.WSOS.AsAsyncEnumerable()
                                                .Select((w, i) => new TreeItem()
                                                {
                                                    Name = w.SectionName,
                                                    Id = w.Id,
                                                    IsWSOS = true,
                                                    ViewNumber = (i + 1).ToString()
                                                })
                                                .ToHashSetAsync();
            return data;
        }

        public async Task<HashSet<TreeItem>> LoadSubskillsData(TreeItem treeItem)
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
                                ViewNumber = treeItem.ViewNumber + "." + (i + 1).ToString()
                            })
                            .ToHashSet();
            }
            else
            {
                var SubSkill = await appDBContext.SubSkills
                                                    .Include(s => s.InverseParentSubSkill)
                                                    .FirstOrDefaultAsync(s => s.Id == treeItem.Id);
                return SubSkill.InverseParentSubSkill
                                .Select((s, i) => new TreeItem()
                                {
                                    Name = s.Name,
                                    Id = s.Id,
                                    IsWSOS = false,
                                    ViewNumber = treeItem.ViewNumber + "." + (i + 1).ToString()
                                })
                                .ToHashSet();

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
                var data = await appDBContext.SubSkills.Include(s => s.SubSkillTasks).ThenInclude(ss => ss.Author).AsQueryable().FirstOrDefaultAsync(s => s.Id == treeItem.Id);
                return data;
            }
        }
    }
}
