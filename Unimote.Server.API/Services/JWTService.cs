using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Unimote.Server.API.Models.Users;

namespace Unimote.Server.API.Services
{
	public static class JWTService
	{
		public static string GenerateJWTToken(UserModel user, string secret, int tokenLifetime)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secret);
			var tokenLife = tokenLifetime;
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.UserName)
				}),
				Expires = DateTime.UtcNow.AddMinutes(tokenLife),
				//SigningCredentials = new SigningAudienceCertificate().GetAudienceSigningKey(_privateKey)
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			foreach (var allowedSection in user.AllowedSections)
				tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, allowedSection.Name.Split(";")[0].Trim()));
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
