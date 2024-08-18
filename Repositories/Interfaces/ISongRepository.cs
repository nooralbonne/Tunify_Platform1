﻿using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Interfaces
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllSongsAsync();
        Task<Song> GetSongByIdAsync(int id);
        Task AddSongAsync(Song song);
        Task UpdateSongAsync(Song song);
        Task DeleteSongAsync(int id);
    }
}
