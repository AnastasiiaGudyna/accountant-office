using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>()
                .ForMember(d => d.AverageSalary, m => m.MapFrom(
                    s => s.Employees.Any() ? s.Employees.Average(e => e.Salary) : 0)
                )
                .ForMember(d => d.EmployeesCount, m => m.MapFrom(
                    s => s.Employees.Count()));
            CreateMap<CreateDepartmentModel, Department>();
            CreateMap<JobCategory, JobCategoryModel>();
            CreateMap<CreateJobCategoryModel, JobCategory>();
        }
    }
}