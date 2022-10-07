using AmanTask.Api.Dto;
using AmanTask.Core.Model;
using AutoMapper;

namespace AmanTask.Api.Helper
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDtoWithName>()
                .ForMember(o => o.DepartmentName, p => p.MapFrom(e => e.Departments.Name))
                .ReverseMap();

            CreateMap<EmployeeDto, Employee>();
               

            CreateMap<Department, DepartmentDto>();
        }

    }
}
