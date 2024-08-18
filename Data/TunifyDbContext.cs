using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDbContext : DbContext

    {
        public TunifyDbContext(DbContextOptions<TunifyDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.User_Id);
            modelBuilder.Entity<Subscription>().HasKey(s => s.SubscriptionId);
            modelBuilder.Entity<Song>().HasKey(s => s.SongId);
            modelBuilder.Entity<PlaylistSong>().HasKey(ps => ps.PlaylistSongsId);
            modelBuilder.Entity<Playlist>().HasKey(p => p.PlaylistId);
            modelBuilder.Entity<Artist>().HasKey(a => a.ArtistId);
            modelBuilder.Entity<Album>().HasKey(al => al.AlbumId);

            // Seeded Data
            modelBuilder.Entity<User>().HasData(
                new User { User_Id = 1, Username = "Noor", Email = "Noorablonne@gmail.com", Join_Date = new DateTime(2024, 1, 15), Subscription_Id = 1 },
                new User { User_Id = 2, Username = "reem", Email = "reemablonne@gmail.com", Join_Date = new DateTime(2024, 1, 15), Subscription_Id = 2 }
            );


            modelBuilder.Entity<Song>().HasData(
            new Song { SongId = 1, AlbumId = 1, ArtistId = 1, Duration = TimeSpan.FromMinutes(3.5), Title = "Tunify", Genre = "1" }
            );

            modelBuilder.Entity<Playlist>().HasData(
           new Playlist { PlaylistId = 1, Created_Date = new DateTime(2024, 1, 15), Playlist_Name = "first song", UserId = 1 }
           );
        }
    }
}
