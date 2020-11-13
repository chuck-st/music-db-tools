using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using music_db_tools.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace music_db_tools.Services {
    public interface ISQLiteService {
        public IEnumerable<Models.itunes.Track> GetTracks();
        public Task<Models.itunes.Track> GetTrackAsync(string id);
        public IEnumerable<Models.itunes.Playlist> GetPlaylistItems();
    }
    public class SQLiteService : ISQLiteService {
        private MyContext _context { get; set; }
        private ILogger _logger { get; set; }
        public SQLiteService(MyContext context, ILogger<SQLiteService> logger) {
            this._logger = logger;
            this._context = context;
        }

        public IEnumerable<Models.itunes.Track> GetTracks() {
            return _context.tracks.ToListAsync().Result;
        }
        public void CreateTracks(List<Models.google.Track> tracks) {

        }
        public void CreateTrack(Models.google.Track track) {

        }
        public void CreatePlaylists(List<Models.google.Playlist> playlists) {

        }
        public void CreatePlaylist(Models.google.Playlist playlist) {

        }
        public async Task<Models.itunes.Track> GetTrackAsync(string track_id) {
            try {
                return await _context.tracks.FirstOrDefaultAsync(x => x.track_id == track_id);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw;
            }
        }
        private void SaveChanges() {
            try {
                _context.SaveChanges();
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IEnumerable<Models.itunes.PlaylistItem> GetPlaylistItems() {
            return _context.playlist_items.ToListAsync().Result;
        }
        private Models.itunes.Track GoogleTrackToItunes(Models.google.Track track) {
            return new Models.itunes.Track {
                track_id = track.id.ToString(),
                    name = track.title,
                    artist = track.artist,
                    rating = track.rating,
                    album = track.album,
                    play_count = track.playCount
            };
        }
        private Models.itunes.Playlist GooglePlaylistToItunes(Models.google.Playlist playlist) {
            return new Models.itunes.Playlist {

            };
        }
    }
    public class MyContext : DbContext {
        //this context exists as boilerplate for Entity Framework relationship recognition
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<Models.itunes.Track> tracks { get; set; }
        public DbSet<Models.itunes.PlaylistItem> playlist_items { get; set; }
        //TODO turn the below into logic for playlists

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // modelBuilder.Entity<Models.itunes.Track>().HasMany(c => c.messages).WithOne().HasForeignKey(m => m.case_id);
            modelBuilder.Entity<Models.itunes.Track>().HasNoKey();
            modelBuilder.Entity<Models.itunes.PlaylistItem>().HasNoKey();
        }
    }
}
