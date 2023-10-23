using Infrastructure.WebApi;
using WebApi;
using WebApi.DataTransferObjects;
using WebApi.EntityFrameworkContext;

namespace Services.WebApi;

public class AccountService
{
    private IJwtTokenServices tokenServices;
    public AccountService(IJwtTokenServices tokenServices, SakilaDataContext sakilaDataContext)
    {
        this.tokenServices = tokenServices;
    }

    public UserDto AuthenticatedUser(LoginDto loginDto)
    {

        if (loginDto.Username == "admin" && loginDto.Password == "admin")
        {
            UserDto userDto = new UserDto() { Id = "2", Username = loginDto.Username, Role = "User", Token = null };
            var token = tokenServices.CreateToken(userDto);
            userDto.Token = token;
            return userDto;
        }
        else if (loginDto.Username == "user" && loginDto.Password == "user")
        {
            UserDto userDto = new UserDto() { Id = "2", Username = loginDto.Username, Role = "User", Token = null };
            var token = tokenServices.CreateToken(userDto);
            userDto.Token = token;
            return userDto;
        }
        else
        {
            throw new ApplicationError("User Authentication Failed");
        }


    }
}

