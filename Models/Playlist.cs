﻿namespace Tunify_Platform.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public int UserId { get; set; }
        public string Playlist_Name { get; set; }
        public DateTime Created_Date { get; set; }
    }
}
