using AccountantOffice.Core.Entities;
using AccountantOffice.UseCases.Interfaces;
using AccountantOffice.UseCases.Models;
using AutoMapper;

namespace AccountantOffice.UseCases.UnitTests.DepartmentBusinessCases;

public class GetDepartmentsMethodUnitTests
{
    private readonly Cases.DepartmentBusinessCases cases;
    private readonly IRepository<Department> departmentRepository;
    private readonly IMapper mapper;
    private readonly IFixture fixture;

    public GetDepartmentsMethodUnitTests()
    {
        mapper = Substitute.For<IMapper>();
        departmentRepository = Substitute.For<IRepository<Department>>();

        cases = new Cases.DepartmentBusinessCases(departmentRepository, mapper);
        fixture = new Fixture();
        fixture.Register(() => fixture.Build<Employee>().Without(e => e.Department).Create());
    }
    
    [Fact]
    public void GetDepartments_Calls_GetListFromDepartmentRepo()
    {
        var expectedDepartments = fixture.Create<IEnumerable<Department>>().AsQueryable();
        departmentRepository.GetList(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedDepartments);
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var actualDepartments = cases.GetDepartments(page, items);

        departmentRepository.Received().GetList(page, items);
        mapper.Received().ProjectTo<DepartmentModel>(expectedDepartments);
    }
    
    [Fact]
    public void GetDepartments_Returns_ListOfItemsMapped()
    {
        var expectedDepartments = fixture.Create<IEnumerable<Department>>().AsQueryable();
        var expectedDepartmentModels = fixture.Create<IEnumerable<DepartmentModel>>().AsQueryable();
        departmentRepository.GetList(Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(expectedDepartments);
        mapper.ProjectTo<DepartmentModel>(Arg.Any<IQueryable<Department>>(), Arg.Any<object>())
            .ReturnsForAnyArgs(expectedDepartmentModels);
        var page = fixture.Create<int>();
        var items = fixture.Create<int>();

        var actualDepartments = cases.GetDepartments(page, items);

        actualDepartments.Should().BeEquivalentTo(expectedDepartmentModels);
    }
    
    [Fact]
    public void GetDepartmentsCount_Returns_GetListRepoCount()
    {
        var expectedDepartments = fixture.Create<IEnumerable<Department>>().AsQueryable();
        departmentRepository.GetList().ReturnsForAnyArgs(expectedDepartments);
        var expectedDepartmentsCount = expectedDepartments.Count();
        
        var actualDepartmentsCount = cases.GetDepartmentsCount();

        actualDepartmentsCount.Should().Be(expectedDepartmentsCount);
    }
}