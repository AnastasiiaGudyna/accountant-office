using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.DepartmentBusinessCases;

public class CreateMethodUnitTests
{
    private readonly Cases.DepartmentBusinessCases cases;
    private readonly IRepository<Department> departmentRepository;
    private readonly IMapper mapper;
    private readonly IFixture fixture;

    public CreateMethodUnitTests()
    {
        mapper = Substitute.For<IMapper>();
        departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.DepartmentBusinessCases(departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Create_Returns_CreatedItemGuidFromRepo()
    {
        var department = fixture.Create<Department>();
        var departmentModel = fixture.Create<CreateDepartmentModel>();
        var expectedDepartmentId = fixture.Create<Guid>();
        mapper.Map<Department>(Arg.Any<CreateDepartmentModel>()).ReturnsForAnyArgs(department);
        departmentRepository.CreateItem(Arg.Any<Department>()).ReturnsForAnyArgs(expectedDepartmentId);
        
        var createdDepartmentId = cases.Create(departmentModel);

        createdDepartmentId.Should().Be(expectedDepartmentId);
    }
    
    [Fact]
    public void Create_Calls_DepartmentRepoAndMapperMethods()
    {
        var department = fixture.Create<Department>();
        var departmentModel = fixture.Create<CreateDepartmentModel>();
        var expectedDepartmentId = fixture.Create<Guid>();
        mapper.Map<Department>(Arg.Any<CreateDepartmentModel>()).ReturnsForAnyArgs(department);
        departmentRepository.CreateItem(Arg.Any<Department>()).ReturnsForAnyArgs(expectedDepartmentId);
        
        var createdDepartmentId = cases.Create(departmentModel);
        
        departmentRepository.Received().CreateItem(department);
        mapper.Received().Map<Department>(departmentModel);
    }
}