using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MM.GeekShopping.Email.MessageConsumer;
using MM.GeekShopping.Email.Model.Context;
using MM.GeekShopping.Email.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration["MySqlConnection:MySqlConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.
    UseMySql(connection,
            new MySqlServerVersion(
                new Version(8, 0, 5))));

var builder2 = new DbContextOptionsBuilder<MySQLContext>();

builder2.UseMySql(connection,
            new MySqlServerVersion(
                new Version(8, 0, 5)));
builder.Services.AddSingleton(new EmailRepository(builder2.Options));
builder.Services.AddScoped<IEmailRepository, EmailRepository>();
builder.Services.AddHostedService<RabbitMQPaymentConsumer>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "geek_shopping");
    });
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MM.GeekShopping.Email", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"Enter 'Bearer' [space] and your token!",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In= ParameterLocation.Header
                        },
                        new List<string> ()
                    }
                });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
