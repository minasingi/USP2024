using System.Net;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.BaseTests;

namespace USP.UnitTests.Users.Queries;

public class GetTestMethodTests : Base
{
    [Fact]
    public async Task User_Get_Test()
    {
        
        
        var response = await AnonymousClient.GetAsync("api/User/Test");
        
        using var _ = new AssertionScope();
        
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}