using AutoMapper;
using HRAPI.Entities;
using HRAPI.Models;

namespace HRAPI.MappingProfile
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<CreateDepartmentDto, Department>();

            CreateMap<UpdateDepartmentDto, Department>();
            CreateMap<Department, UpdateDepartmentDto>();
        }
    }
}
