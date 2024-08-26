using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;
using Tunify_Platform.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Get the connection string settings 
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add DbContext with SQL Server
            builder.Services.AddDbContext<TunifyDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add Identity Service with ApplicationUser and ApplicationRole
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<TunifyDbContext>()
                .AddDefaultTokenProviders();

            // Register services
            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<ISongRepository, SongService>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistService>();
            builder.Services.AddScoped<IArtistRepository, ArtistService>();
            builder.Services.AddScoped<IAccount, IdentityAccountService>();


            builder.Services.AddScoped<JwtTokenService>();

            // add auth service to the app using jwt
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                });

            // Add Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("tunifyApi", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            // Call Swagger service
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/{documentName}/swagger.json";
            });

            // Call Swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/tunifyApi/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });

            app.MapControllers();
            app.MapGet("/newpage", () => "Hello World! from the new page");

            app.Run();
        }
    }
}

// for test

//{
//    "id": "1",
//  "userName": "noor",
//  "email": "noor@gmail.com",
//  "password": "dsldsSASA423423$$$$$$$$$$$$$$$$$$$$655656"
//}