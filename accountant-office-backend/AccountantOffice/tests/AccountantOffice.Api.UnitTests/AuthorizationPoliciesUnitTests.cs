using AutoFixture.AutoNSubstitute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AccountantOffice.Api.UnitTests;

public class AuthorizationPoliciesUnitTests
{

    private readonly IFixture fixture;

    public AuthorizationPoliciesUnitTests()
    {
        fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
    }
    
    [Fact]
    public void ConfigurePolicies_AddsReadPolicy()
    {
        var options = fixture.Create<AuthorizationOptions>();
        
        AuthorizationPolicies.ConfigurePolicies(options);
        var policy = options.GetPolicy(AuthorizationPolicies.Read);
        
        policy.Should().NotBeNull();
        policy.Requirements.Should()
            .Contain(requirement => requirement is DenyAnonymousAuthorizationRequirement)
            .And
            .ContainEquivalentOf(
                 new ClaimsAuthorizationRequirement(
                    AuthorizationPolicies.ScopeClaimType,
                    new List<string>{"accountant_office.read", "admin"}));
    }

    [Fact]
    public void ConfigurePolicies_AddsChangePolicy()
    {
        var options = fixture.Create<AuthorizationOptions>();
        
        AuthorizationPolicies.ConfigurePolicies(options);
        var policy = options.GetPolicy(AuthorizationPolicies.Change);
        
        policy.Should().NotBeNull();
        policy.Requirements.Should()
            .Contain(requirement => requirement is DenyAnonymousAuthorizationRequirement)
            .And
            .ContainEquivalentOf(
                new ClaimsAuthorizationRequirement(
                    AuthorizationPolicies.ScopeClaimType,
                    new List<string>{"accountant_office.write", "admin"}));
    }
    
    [Fact]
    public void ConfigurePolicies_AddsDeletePolicy()
    {
        var options = fixture.Create<AuthorizationOptions>();
        
        AuthorizationPolicies.ConfigurePolicies(options);
        var policy = options.GetPolicy(AuthorizationPolicies.Delete);
        
        policy.Should().NotBeNull();
        policy.Requirements.Should()
            .Contain(requirement => requirement is DenyAnonymousAuthorizationRequirement)
            .And
            .ContainEquivalentOf(
                new ClaimsAuthorizationRequirement(
                    AuthorizationPolicies.ScopeClaimType,
                    new List<string> { "accountant_office.delete", "admin" }));
    }
}