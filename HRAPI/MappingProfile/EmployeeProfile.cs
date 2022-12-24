using AutoMapper;
using HRAPI.Entities;
using HRAPI.Models.EmployeeDtos;

namespace HRAPI.MappingProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();

            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, UpdateEmployeeDto>();
        }
    }
}
