using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Peach_ActiviGo.Core.Interface;
using Peach_ActiviGo.Infrastructure.Data;
using Peach_ActiviGo.Infrastructure.Repositories;
using Peach_ActiviGo.Services;
using Peach_ActiviGo.Services.Auth;
using Peach_ActiviGo.Services.DTOs.AuthDto;
using Peach_ActiviGo.Services.DTOs.AuthDtos;
using Peach_ActiviGo.Services.DTOs.CategoryDtos;
using Peach_ActiviGo.Services.Interface;
using Peach_ActiviGo.Services.Mapping;
using Peach_ActiviGo.Services.Services;
using Peach_ActiviGo.Services.Validators;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = true;
    opt.Password.RequiredLength = 6;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase = true;
    opt.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddAutoMapper(cfg => { }, typeof(ActivityProfile).Assembly);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(cfg => { }, typeof(CategoryProfile).Assembly);


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Peach_ActiviGo API", Version = "v1" });

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    };

    c.AddSecurityDefinition("Bearer", jwtSecurityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { { jwtSecurityScheme, Array.Empty<string>() } });
});

builder.Services.AddCors(opt => opt.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

// --- Dependency Injection ---
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<JwtTokenService>();

//--- Jwt Authentication ---
var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwt["Issuer"],
        ValidAudience = jwt["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// --- Authorization ---
builder.Services.AddAuthorization(opt => opt.AddPolicy("AdminOnly", p => p.RequireRole("Admin")));

// --- Validators ---
builder.Services.AddScoped<IValidator<CategoryCreateDto>, CategoryCreateValidator>();
builder.Services.AddScoped<IValidator<CategoryUpdateDto>, CategoryUpdateValidator>();
builder.Services.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
builder.Services.AddScoped<IValidator<DeleteUserDto>, DeleteUserDtoValidator>();
builder.Services.AddScoped<IValidator<RefreshTokenDto>, RefreshTokenDtoValidator>();
builder.Services.AddScoped<IValidator<ReadLoginDto>, ReadLoginDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();

var app = builder.Build();

// --- Seed Identity & Domändata ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    // --- Kör migrationer ---
    var dbContext = services.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();

    // --- Seed Identity users & roles  ---
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await IdentitySeed.InitializeAsync(userManager, roleManager);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();