using AccountantOffice.Core.Entities;
using AccountantOffice.Data.Repositories;
using AccountantOffice.UseCases.Interfaces;
using AutoFixture.AutoNSubstitute;
using Microsoft.EntityFrameworkCore;

namespace AccountantOffice.Data.UnitTests;

public class RepositoryUnitTests
{
    public class TestClass : Entity
    {
        public string? TestProperty { get; set; }
    }
    private IRepository<TestClass> repo;
    private DbContext context;
    private IFixture fixture;

    public RepositoryUnitTests()
    {
        fixture = new Fixture();
        context = Substitute.For<DbContext>();
        repo = new Repository<TestClass>(context);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(4)]
    [InlineData(9)]
    public void GetList_ReturnsTenElements_IfRequestedNotLastPageAndTenItems(int page)
    {
        var items = 10;
        var testClasses = fixture.CreateMany<TestClass>(100);
        
        var sut = MockDbSet.GetQueryableMockDbSet(testClasses);
        context.Set<TestClass>().ReturnsForAnyArgs(sut);

        var result = repo.GetList(page, items);

        result.Should().HaveCount(10);
    }
    
    [Theory]
    [InlineData(1, 12, 14)]
    [InlineData(4, 5, 22)]
    public void GetList_ReturnsTwoElements_IfRequestedLastPageAndOnlyTwoItemsLeftOnLastPage(int page, int items, int collectionCount)
    {
        var testClasses = fixture.CreateMany<TestClass>(collectionCount);
        
        var sut = MockDbSet.GetQueryableMockDbSet(testClasses);
        context.Set<TestClass>().ReturnsForAnyArgs(sut);

        var result = repo.GetList(page, items);

        result.Should().HaveCount(2);
    }
    
    [Fact]
    public void GetList_ReturnsZeroElements_IfRequestedPageBiggerThenAvailableCountOfPages()
    {
        int page = 11;
        var items = 10;
        var testClasses = fixture.CreateMany<TestClass>(100);
        
        var sut = MockDbSet.GetQueryableMockDbSet(testClasses);
        context.Set<TestClass>().ReturnsForAnyArgs(sut);

        var result = repo.GetList(page, items);

        result.Should().BeEmpty();
    }
    
    [Fact]
    public void CreateItem_AddsCreateDateToTheNewItem()
    {
        var newItem = fixture.Customize(new AutoNSubstituteCustomization()).Create<TestClass>();
        
        var beforeDate = DateTime.UtcNow;
        try
        {
            var result = repo.CreateItem(newItem);
        }
        catch (NullReferenceException)
        {
            //entry.Entity.Id throws exception as entry can't be mocked properly
        }
        var afterDate = DateTime.UtcNow;

        newItem.CreateDate.Should().BeAfter(beforeDate).And.BeBefore(afterDate);
    }
}

