using System.Security.Claims;
using AccountantOffice.Api.Extensions;
using AutoFixture.AutoNSubstitute;

namespace AccountantOffice.Api.UnitTests;

public class ClaimsPrincipalExtensionsUnitTests
{
    private readonly IFixture fixture;

    public ClaimsPrincipalExtensionsUnitTests()
    {
        fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
        fixture.Register(() => 
            new Claim(fixture.Create<string>(), fixture.Create<string>()));
    }
    
    [Fact]
    public void CanViewSalary_ReturnsFalse_UserClaimSalaryVisibleIsFalse()
    {
        var claims = new List<Claim> { new("salary_visible", "false") };
        fixture.AddManyTo(claims);
        var user = Substitute.For<ClaimsPrincipal>();
        user.Claims.Returns(claims);

        user.CanViewSalary().Should().BeFalse();
    }
    
    [Fact]
    public void CanViewSalary_ReturnsFalse_UserClaimSalaryVisibleDoesntExist()
    {
        var user = Substitute.For<ClaimsPrincipal>();
        user.CanViewSalary().Should().BeFalse();
    }
    
    [Fact]
    public void CanViewSalary_ReturnsTrue_UserClaimSalaryVisibleIsTrue()
    {
        var claims = new List<Claim> { new("salary_visible", "true") };
        fixture.AddManyTo(claims);
        var user = Substitute.For<ClaimsPrincipal>();
        user.Claims.Returns(claims);

        user.CanViewSalary().Should().BeTrue();
    }
}