using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.DepartmentBusinessCases;

public class GetMethodUnitTests
{
    private readonly Cases.DepartmentBusinessCases cases;
    private readonly IRepository<Department> departmentRepository;
    private readonly IMapper mapper;
    private readonly IFixture fixture;

    public GetMethodUnitTests()
    {
        mapper = Substitute.For<IMapper>();
        departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.DepartmentBusinessCases(departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Get_Calls_GetFromRepoAndMapperMethods()
    {
        var expectedDepartment = fixture.Create<Department>();
        var expectedDepartmentModel = fixture.Create<DepartmentModel>();
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(expectedDepartment);
        mapper.Map<DepartmentModel>(Arg.Any<Department>()).ReturnsForAnyArgs(expectedDepartmentModel);
        var id = fixture.Create<Guid>();

        var actualDepartment = cases.Get(id);

        departmentRepository.Received().GetItemById(id);
        mapper.Received().Map<DepartmentModel>(expectedDepartment);
    }
    
    [Fact]
    public void Get_Returns_DepartmentFromRepo()
    {
        var expectedDepartment = fixture.Create<Department>();
        var expectedDepartmentModel = fixture.Create<DepartmentModel>();
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(expectedDepartment);
        mapper.Map<DepartmentModel>(Arg.Any<Department>()).ReturnsForAnyArgs(expectedDepartmentModel);
        var id = fixture.Create<Guid>();

        var actualDepartment = cases.Get(id);

        actualDepartment.Should().BeEquivalentTo(expectedDepartmentModel);
    }
}