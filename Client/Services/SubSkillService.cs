using Client.Data;
using Client.Data.Model;
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

        public SubSkillService(DB appDBContext)
        {
            this.appDBContext = appDBContext;
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
