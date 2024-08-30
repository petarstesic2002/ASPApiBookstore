using ASPProjekat.API;
using ASPProjekat.DataAccess;
using System.Data;
using Microsoft.Data.SqlClient;
using ASPProjekat.ApplicationLayer.UseCase;
using ASPProjekat.Implementation;
using ASPProjekat.Implementation.Validators;
using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.Implementation.UseCases.Commands;
using ASPProjekat.Implementation.Logging;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.Implementation.UseCases.Queries;
using ASPProjekat.API.Jwt;
using ASPProjekat.API.Jwt.TokenStorage;
using ASPProjekat.ApplicationLayer.Uploads;
using ASPProjekat.Implementation.Uploads;
using ASPProjekat.API.Extensions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ASPProjekat.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddLogger();
builder.Services.AddTransient<ASPContext>(x => new ASPContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));

builder.Services.AddTransient<CreateBookValidator>();
builder.Services.AddTransient<CreateEditionValidator>();
builder.Services.AddTransient<CreateOrderValidator>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<UpdateBookValidator>();
builder.Services.AddTransient<UpdateEditionValidator>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<IBase64Uploader, Base64Uploader>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<ASPContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, settings.Jwt.Issuer, settings.Jwt.SecretKey, settings.Jwt.DurationSeconds, tokenStorage);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nedelja 10", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
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
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                });
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUserUseCaseProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<ASPContext>();

    return new AuthorizationUserProvider(authHeader, context);
});
builder.Services.AddScoped<IUserUseCase>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];
    var data = header.ToString().Split("Bearer ");
    if (data.Length < 2)
    {
        return new UnauthorizedUser();
    }
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedUser();
    }
    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;

    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new UserImplementation
    {
        Id = int.Parse(id),
        AllowedUseCases = useCaseIds,
        Email = email
    };
});
builder.Services.AddTransient<UseCaseHandler>(x =>
{
    var user = x.GetService<IUserUseCase>();
    var logger = x.GetService<IUseCaseLogger>();
    var decoration = new UseCaseHandler(user,logger);

    return decoration;
});
builder.Services.AddTransient<IRegisterUser, EfRegisterUser>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
builder.Services.AddTransient<IGetBooks, EfGetBooks>();
builder.Services.AddTransient<IGetUsers, EfGetUsers>();
builder.Services.AddTransient<IGetUserOrders, EfGetUserOrders>();
builder.Services.AddTransient<ICheckBookAvailability, EfCheckBookAvailability>();
builder.Services.AddTransient<ICreateBook, EfCreateBook>();
builder.Services.AddTransient<ICreateEdition, EfCreateEdition>();
builder.Services.AddTransient<ICreateOrder, EfCreateOrder>();
builder.Services.AddTransient<IUpdateBook, EfUpdateBook>();
builder.Services.AddTransient<IUpdateEdition, EfUpdateEdition>();
builder.Services.AddJwt(settings);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
