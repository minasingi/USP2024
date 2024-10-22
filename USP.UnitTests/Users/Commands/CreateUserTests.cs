using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using USP.BaseTests;
using USP.BaseTests.Builders.Commands;
using USP.BaseTests.Builders.Dto;

namespace USP.UnitTests.Users.Commands;

public class CreateUserTests : Base
{
    [Fact]
    public async Task CreateUserCommand_User_UserCreated()
    {
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Mina")
            .WithLastName("Prezime")
            .WithEmail("mina@mejl.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidFirstName_BadRequest()
    {
        var dto = new EditUserDtoBuilder()
            .WithLastName("Prezime")
            .WithEmail("mina@mejl.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidLastName_BadRequest()
    {
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Mina")
            .WithEmail("mina@mejl.rs")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreateUserCommand_InvalidEmail_BadRequest()
    {
        var dto = new EditUserDtoBuilder()
            .WithFirstName("Mina")
            .WithLastName("Prezime")
            .Build();

        var command = new EditUserCommandBuilder()
            .WithDto(dto)
            .Build();
        
        var json = JsonSerializer.Serialize(command);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        
        var response = await AnonymousClient.PostAsync("api/User/Edit", content);
        
        using var _ = new AssertionScope();

        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}