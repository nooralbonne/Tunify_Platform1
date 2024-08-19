using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Repositories.Interfaces;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<TunifyDbContext>(options => options.UseSqlServer(connectionString));

            // Register services
            builder.Services.AddScoped<IUserRepository, UserService>();
            builder.Services.AddScoped<ISongRepository, SongService>();
            builder.Services.AddScoped<IPlaylistRepository, PlaylistService>();
            builder.Services.AddScoped<IArtistRepository, ArtistService>();



            //==============Lab 14=============//
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

            // call swagger service
            app.UseSwagger(
              options =>
              {
                  options.RouteTemplate = "api/{documentName}/swagger.json";
              });

            // call swagger UI
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/tunifyApi/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });

            //================================//
            //app.MapGet("/", () => "Hello World!");
            app.MapControllers();

            app.Run();
        }
    }
}
