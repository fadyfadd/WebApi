using WebApi;
using WebApi.DataTransferObjects;
using WebApi.EntityFrameworkContext;

namespace Services.WebApi;

public class AccountService
{
    private IJwtTokenServices tokenServices;
    public AccountService(IJwtTokenServices tokenServices , SakilaDataContext sakilaDataContext) {
        this.tokenServices = tokenServices;
    }

    public UserDto AuthenticatedUser(LoginDto loginDto) {
        UserDto userDto = new UserDto() { Id="-1" , Username = loginDto.Username , Role="User" , Token = null };
        var token = tokenServices.CreateToken(userDto);
        userDto.Token = token;
        return userDto;
    }
}

