using Microsoft.AspNetCore.Identity;
using Photify.Domain.Identity;
using Photify.Infrastructure;
using Photify.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContexts(builder.Configuration);
builder.Services.AddIdentity<User, Role>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequireLowercase = false,
        RequireUppercase = false,
        RequiredUniqueChars = 0,
        RequireNonAlphanumeric = false,
        RequiredLength = 8
    };
    options.Tokens.ChangeEmailTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
}).AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

var app = builder.Build();

app.MigrateDbContext<IdentityContext>((_, __) => { });
app.MigrateDbContext<PhotifyDbContext>((_, __) => { });
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
