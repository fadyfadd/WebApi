using WebApi.DataTransferObjects;

namespace WebApi;

public interface IJwtTokenServices
{
        string CreateToken(UserDto user);
}
