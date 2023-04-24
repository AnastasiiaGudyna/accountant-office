using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.DepartmentBusinessCases;

public class UpdateMethodUnitTests
{
    private readonly Cases.DepartmentBusinessCases cases;
    private readonly IRepository<Department> departmentRepository;
    private readonly IFixture fixture;

    public UpdateMethodUnitTests()
    {
        var mapper = Substitute.For<IMapper>();
        departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.DepartmentBusinessCases(departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Update_Calls_UpdateItemFromRepo()
    {
        var department = fixture.Create<Department>();

        var actualDepartmentId = cases.Update(department);

        departmentRepository.Received().UpdateItem(department);
    }
    
    [Fact]
    public void Update_Returns_DepartmentIdFromRepo()
    {
        var department = fixture.Create<Department>();
        var expectedId = fixture.Create<Guid>();
        departmentRepository.UpdateItem(Arg.Any<Department>()).ReturnsForAnyArgs(expectedId);

        var actualDepartmentId = cases.Update(department);

        actualDepartmentId.Should().Be(expectedId);
    }
}