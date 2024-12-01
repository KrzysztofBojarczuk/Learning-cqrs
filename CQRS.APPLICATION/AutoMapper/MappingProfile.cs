using AutoMapper;
using CQRS.APPLICATION.Dtos;
using CQRS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.APPLICATION.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDto, EmployeeEntity>();

            CreateMap<EmployeeEntity, EmployeeGetDto>();
        }
    }
}

