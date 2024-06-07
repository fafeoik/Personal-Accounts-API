using Microsoft.EntityFrameworkCore;
using PersonalAccounts2._0.DTO;
using PersonalAccounts2._0.Service.Interfaces;
using PersonalAccounts2._0.Service;
using PersonalAccounts2._0.DataAccess;
using PersonalAccounts2._0.Repository;
using PersonalAccounts2._0.Repository.Implementation;
using PersonalAccounts.MappingConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterMapsterConfiguration();

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{ options.UseSqlite(builder.Configuration.GetConnectionString("AccountRepo"), b => b.MigrationsAssembly("PersonalAccounts2.0.DataAccess")); });

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
