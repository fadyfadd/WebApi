using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi;
using WebApi.DataTransferObjects;

namespace Infrastructure.WebApi;

public class JwtTokenServices : IJwtTokenServices
{

    private readonly SymmetricSecurityKey jwtTokenKey;
    public JwtTokenServices(IOptions<AppSettings> settings)
    {
        this.jwtTokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Value.JwtToken));
    }

       public JwtTokenServices(AppSettings settings)
    {
        this.jwtTokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtToken));
    }

    public string CreateToken(UserDto user)
    {
        var claims = new List<Claim>
        {
                  new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                  new Claim(ClaimTypes.Role , user.Role)
        };

        var creds = new SigningCredentials(jwtTokenKey, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);

    }




}
