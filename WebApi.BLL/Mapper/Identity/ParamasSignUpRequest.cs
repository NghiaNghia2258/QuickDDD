﻿namespace WebApi.BLL.Mapper.Identity;

public class ParamasSignUpRequest
{
	public string Username { get; set; } = null!;

	public string Password { get; set; } = null!;

	public int RoleGroupId { get; set; }
}
