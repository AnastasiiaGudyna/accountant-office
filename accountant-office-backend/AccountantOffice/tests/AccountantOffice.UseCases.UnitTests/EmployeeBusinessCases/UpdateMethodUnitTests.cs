using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.EmployeeBusinessCases;

public class UpdateMethodUnitTests
{
    private readonly Cases.EmployeeBusinessCases cases;
    private readonly IRepository<Employee> employeeRepository;
    private readonly IFixture fixture;

    public UpdateMethodUnitTests()
    {
        employeeRepository = Substitute.For<IRepository<Employee>>();
        var mapper = Substitute.For<IMapper>();
        var departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.EmployeeBusinessCases(employeeRepository, departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void Update_Calls_UpdateItemFromRepo()
    {
        var employee = fixture.Create<Employee>();

        var actualEmployeeId = cases.Update(employee);

        employeeRepository.Received().UpdateItem(employee);
    }
    
    [Fact]
    public void Update_Returns_EmployeeIdFromRepo()
    {
        var employee = fixture.Create<Employee>();
        var expectedEmployeeId = fixture.Create<Guid>();
        employeeRepository.UpdateItem(Arg.Any<Employee>()).ReturnsForAnyArgs(expectedEmployeeId);

        var actualEmployeeId = cases.Update(employee);

        actualEmployeeId.Should().Be(expectedEmployeeId);
    }
}