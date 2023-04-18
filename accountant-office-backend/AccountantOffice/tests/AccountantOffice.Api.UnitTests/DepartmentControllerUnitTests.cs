using AccountantOffice.Api.Controllers;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;

namespace AccountantOffice.Api.UnitTests;

public class DepartmentControllerUnitTests
{
    private readonly IDepartmentBusinessCases departmentBusinessCases;
    private readonly IEmployeeBusinessCases employeeBusinessCases;
    private readonly Fixture fixture = new Fixture();

    public DepartmentControllerUnitTests()
    {
        departmentBusinessCases = Substitute.For<IDepartmentBusinessCases>();
        employeeBusinessCases = Substitute.For<IEmployeeBusinessCases>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(8)]
    [InlineData(2015)]
    public void GetDepartments_ReturnedCountTheSameAsFromBusinessCase(int expectedDepartmentsCount)
    {
        departmentBusinessCases.GetDepartmentsCount().ReturnsForAnyArgs(expectedDepartmentsCount);
        var sut = new DepartmentController(departmentBusinessCases, employeeBusinessCases);
        
        var result = sut.GetDepartments(0, 10);
        
        result.DepartmentsCount.Should().Be(expectedDepartmentsCount);
    }
    
    [Fact]
    public void GetDepartments_ReturnedDepartmentsTheSameAsFromBusinessCase()
    {
        var listOfDepartments = fixture.Create<IEnumerable<DepartmentModel>>();
        departmentBusinessCases.GetDepartments(0, 10).ReturnsForAnyArgs(listOfDepartments);
        var sut = new DepartmentController(departmentBusinessCases, employeeBusinessCases);
        
        var result = sut.GetDepartments(0, 10);

        result.Departments.Should().BeEquivalentTo(listOfDepartments);
    }
}