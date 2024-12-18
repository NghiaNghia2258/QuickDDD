using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.DAL;
using WebApi.BLL.Mapper;
using WebApi.BLL.Interfaces;
using WebApi.BLL.Services;
using WebApi.Domain.Abstractions.Repository.Identity;
using WebApi.DAL.Repostiroty;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
	);

builder.Services.AddAuthentication(ops =>
{
    ops.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    ops.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    ops.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(ops =>
{
    ops.SaveToken = true;
    ops.RequireHttpsMetadata = false;
    ops.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "User",
        ValidIssuer = "https://localhost:7112",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AVERYTOPSECRET123^%$"))
    };
});

builder.Services.AddScoped<IAuthService, IdentityServices>();
builder.Services.AddScoped<IAuthoziService, IdentityServices>();
builder.Services.AddScoped<IAuthenRepository, IdentityRepository>();
builder.Services.AddScoped<IAuthoziRepository, IdentityRepository>();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfile()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
