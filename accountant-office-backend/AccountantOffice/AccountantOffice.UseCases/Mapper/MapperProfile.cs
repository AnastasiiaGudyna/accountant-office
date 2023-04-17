using System.Linq;
using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        bool showSalary = false;
        CreateMap<Employee, EmployeeModel>()
            .ForMember(d => d.Salary, m => m.MapFrom(s => showSalary ? s.Salary : 0))
            .ReverseMap();
        CreateMap<Department, DepartmentModel>()
            .ForMember(d => d.AverageSalary, m => m.MapFrom(
                s => s.Employees.Any() ? s.Employees.Average(e => e.Salary) : 0)
            )
            .ForMember(d => d.EmployeesCount, m => m.MapFrom(
                s => s.Employees.Count()));
        CreateMap<CreateDepartmentModel, Department>();
            
        CreateMap<CatalogValues, JobCategoryModel>()
            .ForMember(d => d.Name, m => m.MapFrom(
                s => s.Value));
        CreateMap<CreateJobCategoryModel, CatalogValues>()
            .ForMember(d => d.Value, m => m.MapFrom(
                s => s.Name));

        CreateMap<Catalog, CatalogModel>();
        CreateMap<CatalogValues, CatalogValueModel>();
    }
}