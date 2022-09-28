using BusReservations.Core.Abstract;
using BusReservations.Core.Abstract.Repository;
using BusReservations.Core.Commands;
using BusReservations.Core.Domain;
using BusReservations.Infrastructure.Data;
using BusReservations.Infrastructure.Data.Repository;
using BusReservations.WebAPI.Middleware;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

//add external services
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IBusDrivenRouteRepository, BusDrivenRouteRepository>();
builder.Services.AddScoped<IBusRepository, BusRepository>();
builder.Services.AddScoped<IDrivenRouteRepository, DrivenRouteRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<ITimeTableRepository, TimeTableRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(typeof(Bus).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddLogging();

builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "http://localhost:4200/",
        ValidIssuer = "https://localhost:7124/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("014257c5-7702-432f-b89f-68913e69fdcc"))
        //TO DO: add secret to appsettings.json
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administrator", policy =>
    {
        policy.RequireRole("admin");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusReservations.WebAPI");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseStaticFiles();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

