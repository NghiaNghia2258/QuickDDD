namespace WebApi.Shared.Models;

public class TokenLogin
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public int? UserLoginId { get; set; }
    public int? RoleGroupId { get; set; }
}
