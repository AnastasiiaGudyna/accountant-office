using AccountantOffice.Api.Controllers;
using AccountantOffice.UseCases.Interfaces;

namespace AccountantOffice.Api.UnitTests;

public class DepartmentControllerUnitTests
{
    private IDepartmentBusinessCases _departmentBusinessCases;
    private IEmployeeBusinessCases _employeeBusinessCases;

    public DepartmentControllerUnitTests()
    {
        _departmentBusinessCases = Substitute.For<IDepartmentBusinessCases>();
        _employeeBusinessCases = Substitute.For<IEmployeeBusinessCases>();
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(8)]
    [InlineData(2015)]
    public void GetDepartments_ReturnedCountTheSameAsFromBusinessCase(int expectedDepartmentsCount)
    {
        _departmentBusinessCases.GetDepartmentsCount().ReturnsForAnyArgs(expectedDepartmentsCount);
        var sut = new DepartmentController(_departmentBusinessCases, _employeeBusinessCases);
        
        var result = sut.GetDepartments(0, 10);
        
        Assert.Equal(expectedDepartmentsCount,result.DepartmentsCount);
    }
}