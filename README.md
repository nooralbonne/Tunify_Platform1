# Tunify Platform

## Project Overview
Tunify Platform is a web application that allows users to manage their music library, including subscriptions, playlists, and song collections. The application integrates with a SQL Server database to handle data storage and management, as outlined in the Entity-Relationship Diagram (ERD).

## Entity-Relationship Diagram
![ERD Diagram](https://github.com/nooralbonne/Tunify-Platform1/blob/master/Tunify.png)

## Models and Relationships

- **User**: Represents a user of the platform.
  - **UserId**: Unique identifier for the user.
  - **Username**: User’s name.
  - **Email**: User’s email address.
  - **Join_Date**: Date when the user joined.
  - **SubscriptionId**: References the Subscription.
  - **Subscription**: Navigation property to the Subscription.
  - **Playlists**: Collection of Playlists created by the user.

- **Subscription**: Represents a user's subscription.
  - **SubscriptionId**: Unique identifier for the subscription.
  - **Subscription_Type**: Type of subscription.
  - **Price**: Subscription price.
  - **Users**: Collection of Users with this subscription.

- **Playlist**: Represents a music playlist created by a user.
  - **PlaylistId**: Unique identifier for the playlist.
  - **UserId**: References the User who created the playlist.
  - **User**: Navigation property to the User.
  - **Playlist_Name**: Name of the playlist.
  - **Created_Date**: Date when the playlist was created.
  - **PlaylistSongs**: Collection of PlaylistSongs associated with this playlist.

- **Song**: Represents a song in the library.
  - **SongId**: Unique identifier for the song.
  - **Title**: Song title.
  - **ArtistId**: References the Artist.
  - **Artist**: Navigation property to the Artist.
  - **AlbumId**: References the Album.
  - **Album**: Navigation property to the Album.
  - **Duration**: Length of the song.
  - **Genre**: Genre of the song.
  - **PlaylistSongs**: Collection of PlaylistSongs associated with this song.

- **Artist**: Represents a music artist.
  - **ArtistId**: Unique identifier for the artist.
  - **Name**: Artist’s name.
  - **Bio**: Artist’s biography.
  - **Songs**: Collection of Songs by this artist.
  - **Albums**: Collection of Albums by this artist.

- **Album**: Represents a music album.
  - **AlbumId**: Unique identifier for the album.
  - **Album_Name**: Name of the album.
  - **Release_Date**: Date when the album was released.
  - **ArtistId**: References the Artist.
  - **Artist**: Navigation property to the Artist.
  - **Songs**: Collection of Songs in this album.

- **PlaylistSongs**: Junction table linking playlists and songs.
  - **PlaylistSongsId**: Unique identifier for the PlaylistSongs entry.
  - **PlaylistId**: References the Playlist.
  - **Playlist**: Navigation property to the Playlist.
  - **SongId**: References the Song.
  - **Song**: Navigation property to the Song.

## Navigation and Routing (Lab 13)

### Navigation Properties

- **Playlist**: Added `ICollection<PlaylistSongs>` to manage songs in playlists.
- **Song**: Added `ICollection<PlaylistSongs>` to manage playlist associations.
- **Artist**: Added `ICollection<Song>` for songs by the artist.
- **Album**: Added `ICollection<Song>` for songs in the album.

### Routing

#### Playlist-Song Relationships

1. **Add a Song to a Playlist**

   - **Endpoint**: `POST api/playlists/{playlistId}/songs/{songId}`
   - **Controller Action**:

     ```csharp
     [HttpPost("playlists/{playlistId}/songs/{songId}")]
     public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
     {
         // Implementation
     }
     ```

2. **Retrieve Songs in a Playlist**

   - **Endpoint**: `GET api/playlists/{playlistId}/songs`
   - **Controller Action**:

     ```csharp
     [HttpGet("playlists/{playlistId}/songs")]
     public async Task<ActionResult<IEnumerable<Song>>> GetSongsForPlaylist(int playlistId)
     {
         // Implementation
     }
     ```

#### Artist-Song Relationships

1. **Add a Song to an Artist**

   - **Endpoint**: `POST api/artists/{artistId}/songs/{songId}`
   - **Controller Action**:

     ```csharp
     [HttpPost("artists/{artistId}/songs/{songId}")]
     public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
     {
         // Implementation
     }
     ```

2. **Retrieve Songs by an Artist**

   - **Endpoint**: `GET api/artists/{artistId}/songs`
   - **Controller Action**:

     ```csharp
     [HttpGet("artists/{artistId}/songs")]
     public async Task<ActionResult<IEnumerable<Song>>> GetSongsByArtist(int artistId)
     {
         // Implementation
     }
     ```

### Relationship Management

- **PlaylistService**: Added a method to handle adding a song to a playlist.
- **ArtistService**: Added a method to handle adding a song to an artist.

### Seeding Sample Data

- Updated the `OnModelCreating` method in `TunifyDbContext` to define composite keys for join tables and seed initial data for `Playlist`, `Song`, and `Artist` models.
- Applied the necessary migrations to update the database.
- Confirmed initial data was seeded successfully.

## Repository Design Pattern

### What is the Repository Design Pattern?
The Repository Design Pattern abstracts and encapsulates data access logic, promoting better organization and separation of concerns.

### Benefits

- **Separation of Concerns**: Keeps data access code separate from business logic.
- **Testability**: Simplifies unit testing by allowing repositories to be mocked.
- **Maintainability**: Centralizes data access logic for easier updates.
- **Flexibility**: Facilitates changes to data sources or methods.
- **Consistency**: Promotes consistent data access practices.

### How to Use

1. **Define Repository Interfaces**: Create interfaces for each entity.
2. **Implement Repository Services**: Implement the interfaces in the `Repositories/Services` folder.
3. **Refactor Controllers**: Use repository services instead of direct `DbContext` access.
4. **Register Services**: Register repository services in the `ConfigureServices` method of `Program.cs`.

## Final Steps

- Ensure all repositories are correctly implemented and controllers are refactored to use them.
- Update this `README.md` to include information on the Repository Design Pattern and its benefits.
