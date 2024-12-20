using DmlStarterkit.Domain.Entities;
using DmlStarterkit.Application;
using DmlStarterkit.Infrastructure;
using DmlStarterkit.Persistance;
using DmlStarterkit.Infrastructure.Security.JwtToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using DmlStarterkit.Infrastructure.Errors.Middleware;

var builder = WebApplication.CreateBuilder(args);

// NOTE: Appsettings degerleri uygulama baslayinca Entity Classa map edilir.
builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>();
builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

// JWT TOKEN kullanmak icin eklenen kodlar
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidIssuer = TokenOptions.Issuer,
                      ValidAudience = TokenOptions.Audience,
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new JwtHelper().CreateSecurityKey()
                  };
              });

// Add services to the container.
builder.Configuration.GetSection("ApplicationSettings").Get<ApplicationSettings>();
builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "API Swagger",
        Description = "Api Swagger Documentation",
        TermsOfService = new Uri("http://swagger.io/terms/"),
        Contact = new OpenApiContact
        {
            Name = "Mustafa Ozkan"

        }
    });
    // To Enable authorization using Swagger (JWT)  
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

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

app.UseCors(builder => builder.WithOrigins("https://ard-digital.site", "http://localhost:4200", "http://localhost:7035", "http://localhost").AllowAnyHeader().AllowAnyMethod());

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
