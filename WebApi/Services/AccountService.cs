using Infrastructure.WebApi;
using Org.BouncyCastle.Asn1.Cms;
using WebApi;
using WebApi.DataTransferObjects;

namespace Services.WebApi;

public class AccountService
{
    private IJwtTokenServices tokenServices;
    public AccountService(IJwtTokenServices tokenServices) {
        this.tokenServices = tokenServices;
    }

    public UserDto AuthenticatedUser(LoginDto loginDto) {
        UserDto userDto = new UserDto() { Id="-1" , Username = loginDto.Username , Role="User" , Token = null };
        var token = tokenServices.CreateToken(userDto);
        userDto.Token = token;
        return userDto;
    }
}

