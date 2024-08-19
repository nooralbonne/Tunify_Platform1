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

## Swagger UI Integration (Lab 14)

### Overview
In Lab 14, we have integrated Swagger UI into the Tunify Platform. Swagger UI provides an interactive interface to visualize and interact with the API's endpoints, making it easier to understand and test the API.

![SQLDatabaswAzure](https://github.com/nooralbonne/Tunify_Platform1/blob/master/SQLDatabaswAzure.jpg)
![SwaggerUI](https://github.com/nooralbonne/Tunify_Platform1/blob/master/SwaggerUI1.jpg)

### Setup and Configuration

1. **Install Swashbuckle.AspNetCore**
   - Open the NuGet Package Manager Console.
   - Run the following command to install the Swashbuckle.AspNetCore package:
     ```shell
     Install-Package Swashbuckle.AspNetCore
     ```

2. **Configure Swagger in Program.cs**
   - Add the Swagger services in `Program.cs`:
     ```csharp
     builder.Services.AddSwaggerGen(options =>
     {
         options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
         {
             Title = "Tunify API",
             Version = "v1",
             Description = "API for managing playlists, songs, and artists in the Tunify Platform"
         });
     });
     ```

   - Enable Swagger and Swagger UI in the `Program.cs` file:
     ```csharp
     app.UseSwagger(options =>
     {
         options.RouteTemplate = "api/{documentName}/swagger.json";
     });

     app.UseSwaggerUI(options =>
     {
         options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tunify API v1");
         options.RoutePrefix = "";
     });
     ```

3. **Test the Swagger UI**
   - Launch the application and navigate to the root URL to view the Swagger UI.
   - Use the Swagger UI to interact with your API endpoints, ensuring that all endpoints are documented and functional.

### Accessing and Using Swagger UI

- After starting the application, navigate to the root URL (e.g., `http://localhost:5000/`) to access the Swagger UI.
- The Swagger UI provides a user-friendly interface to interact with the API. You can test endpoints, view request/response models, and see example payloads.

### Benefits of Swagger UI

- **Interactive Documentation**: Swagger UI allows you to view and test API endpoints directly from the browser.
- **Ease of Use**: Developers can quickly understand the API structure and available operations without referring to separate documentation.
- **Auto-Generated**: Documentation is automatically generated from the API's codebase, ensuring it's always up to date.

### Conclusion

With Swagger UI integrated, the Tunify Platform now includes comprehensive, interactive API documentation that enhances the developer experience by providing a clear and accessible way to explore and test the API.

