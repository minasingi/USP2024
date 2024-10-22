namespace USP.API.Services;

public class UserService : IUserService
{
    public async Task<string> Get() => "Mina";

    public async Task<string> Create() => "Created!";
}