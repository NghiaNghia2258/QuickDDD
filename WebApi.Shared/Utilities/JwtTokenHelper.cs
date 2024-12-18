﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Shared.Models;

namespace WebApi.Shared.Utilities;

public static class JwtTokenHelper
{
	public static string GenerateJwtToken(PayloadToken payloadToken, IConfiguration configuration)
	{
		if (payloadToken.Roles.Count() == 0)
		{
			throw new Exception("Unauthorized (Not login)");
		}
		var secretKey = configuration["JwtSettings:Key"];
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
		var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

		var claims = new List<Claim>();
		claims.Add(new Claim("UserLoginId", payloadToken.UserLoginId.ToString()));
		claims.Add(new Claim("FullName", payloadToken.FullName ?? "No name"));
		foreach (var item in payloadToken.Roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, item.Name));
		}

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddYears(1),
		signingCredentials: credentials);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
	public static PayloadToken GetPayloadToken(HttpContext httpContext, IConfiguration configuration)
	{
		string bearerToken = httpContext.Request.Headers["Authorization"];
		if (string.IsNullOrEmpty(bearerToken))
		{
			throw new Exception("Unauthorized (Not login)");
		}
		else
		{
			return VerifyJwtToken(bearerToken.Split(" ")[1], configuration);
		}
	}
	public static PayloadToken VerifyJwtToken(string token, IConfiguration configuration)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var secretKey = configuration["JwtSettings:Key"];
		var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
		var validationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = securityKey,
			ValidateLifetime = false
		};

		var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
		JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;

		PayloadToken payloadToken = new PayloadToken()
		{
			UserLoginId = int.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == "UserLoginId").Value),
			FullName = jwtToken.Claims.FirstOrDefault(c => c.Type == "FullName").Value,
		};

		return payloadToken;
	}
}
