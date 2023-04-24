using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.DepartmentBusinessCases;

public class DeleteMethodUnitTests
{
    private readonly Cases.DepartmentBusinessCases cases;
    private readonly IRepository<Department> departmentRepository;
    private readonly IFixture fixture;

    public DeleteMethodUnitTests()
    {
        var mapper = Substitute.For<IMapper>();
        departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.DepartmentBusinessCases(departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Delete_Calls_DepartmentRepoMethods()
    {
        var department = fixture.Create<Department>();
        var departmentId = fixture.Create<Guid>();
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(department);
        departmentRepository.DeleteItem(Arg.Any<Department>()).ReturnsForAnyArgs(departmentId);
        
        var deletedDepartmentId = cases.Delete(departmentId);

        departmentRepository.Received().GetItemById(departmentId);
        departmentRepository.Received().DeleteItem(department);
    }
    
    [Fact]
    public void Delete_Returns_GuidFromDeleteItemMethod()
    {
        var department = fixture.Create<Department>();
        var expectedDepartmentId = fixture.Create<Guid>();
        departmentRepository.GetItemById(Arg.Any<Guid>()).ReturnsForAnyArgs(department);
        departmentRepository.DeleteItem(Arg.Any<Department>()).ReturnsForAnyArgs(expectedDepartmentId);
        
        var deletedDepartmentId = cases.Delete(fixture.Create<Guid>());

        deletedDepartmentId.Should().Be(expectedDepartmentId);
    }
}