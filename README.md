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
