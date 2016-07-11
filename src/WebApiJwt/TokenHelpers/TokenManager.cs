using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

/// <summary>
/// Written by Andrew Delicata
/// https://github.com/Delie/WebApiJwt
/// </summary>
namespace WebApiJwt.TokenHelpers
{
	public class TokenManager
	{
		public static string CreateToken(string username) {
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			DateTime now = DateTime.UtcNow;

			Claim[] claims = new Claim[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, username),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString() , ClaimValueTypes.Integer64)
			};
			TokenConfig tc = new TokenConfig();
			JwtSecurityToken jwt = new JwtSecurityToken(
				issuer: tc.Issuer,
				audience: tc.Audience,
				claims: claims,
				notBefore: now,
				expires: now.AddMinutes(tc.MinutesUntilExpires),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tc.SecretKey)), SecurityAlgorithms.HmacSha256)
			);
			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}
	}
}
