# Tunify Platform

## Project Overview
Tunify Platform is a web application that allows users to manage their music library, including subscriptions, playlists, and song collections. The application integrates with a SQL Server database to handle data storage and management, as outlined in the Entity-Relationship Diagram (ERD).

## Entity-Relationship Diagram
![ERD Diagram](https://github.com/nooralbonne/Tunify-Platform1/blob/master/Tunify.png)

## Models and Relationships

- **User**: Represents a user of the platform.
  - **Id**: Unique identifier for the user.
  - **Name**: User’s name.
  - **Email**: User’s email address.

- **Subscription**: Represents a user's subscription.
  - **Id**: Unique identifier for the subscription.
  - **UserId**: References the User.
  - **StartDate**: Start date of the subscription.
  - **EndDate**: End date of the subscription.

- **Playlist**: Represents a music playlist created by a user.
  - **Id**: Unique identifier for the playlist.
  - **Name**: Playlist name.
  - **UserId**: References the User who created the playlist.

- **Song**: Represents a song in the library.
  - **Id**: Unique identifier for the song.
  - **Title**: Song title.
  - **Artist**: Song artist.
  - **Album**: Album name.

- **Artist**: Represents a music artist.
  - **Id**: Unique identifier for the artist.
  - **Name**: Artist’s name.

- **Album**: Represents a music album.
  - **Id**: Unique identifier for the album.
  - **Title**: Album title.
  - **ArtistId**: References the Artist.

- **PlaylistSongs**: Junction table linking playlists and songs.
  - **PlaylistId**: References the Playlist.
  - **SongId**: References the Song.

## Getting Started

### Clone the Repository
```bash
git clone https://github.com/your-username/Tunify-Platform.git
cd Tunify-Platform

## Repository Design Pattern

### What is the Repository Design Pattern?
The Repository Design Pattern is a design pattern that abstracts and encapsulates data access logic. It separates the data access layer from the business logic layer, promoting better organization and separation of concerns.

### Benefits of the Repository Design Pattern

#### Separation of Concerns
- **Modularity**: Keeps data access code separate from business logic, making the application more organized and easier to maintain.
- **Encapsulation**: Data access details are hidden within repositories, reducing the complexity of the business logic.

#### Testability
- **Mocking**: Simplifies unit testing by allowing repositories to be mocked, thus enabling tests of business logic in isolation from the data layer.

#### Maintainability
- **Centralization**: Centralizes data access logic, so changes to data access strategies or sources are confined to the repository classes.

#### Flexibility
- **Adaptability**: Facilitates changes to data sources or data access methods without impacting the business logic.

#### Consistency
- **Standardization**: Promotes consistent data access practices throughout the application, reducing the likelihood of errors.

### How to Use the Repository Pattern

1. **Define Repository Interfaces:**
   - Create interfaces for each entity (e.g., `IUserRepository`, `IPlaylistRepository`) in the `Repositories/Interfaces` folder.

2. **Implement Repository Services:**
   - Implement the repository interfaces in the `Repositories/Services` folder.

3. **Refactor Controllers:**
   - Refactor controllers to use repository services instead of direct `DbContext` access.

4. **Register Services:**
   - Register repository services in the `ConfigureServices` method of `Program.cs`.

### Final Steps
- Ensure that all repositories are correctly implemented and controllers are refactored to use them.
- Update this `README.md` to include information on the Repository Design Pattern and its benefits.