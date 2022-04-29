using AutoMapper;
using Client.Data.DTO;
using Client.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Data.Mapping
{
    public class SubSkillMappingProfile : Profile
    {
        public SubSkillMappingProfile()
        {
            CreateMap<UpdateSubSkillDto, SubSkill>();
            CreateMap<SubSkill, UpdateSubSkillDto>(); 
        }
    }
}
