using AutoMapper;
using HRAPI.Entities;
using HRAPI.Models.DepartmentDtos;

namespace HRAPI.MappingProfile
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentDto>();

            CreateMap<CreateDepartmentDto, Department>();
            CreateMap<Department, CreateDepartmentDto>();

            CreateMap<UpdateDepartmentDto, Department>();  
            CreateMap<Department, UpdateDepartmentDto>();
        }
    }
}
