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
                                                    ViewNumber = (i + 1).ToString(),
                                                    HasChild = true
                                                })
                                                .ToHashSetAsync();
            return data;
        }

        
    }
}
