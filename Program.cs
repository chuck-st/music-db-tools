using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Authentication;
using Couchbase.Configuration.Client;
using music_db_tools.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace music_db_tools {
    class Program {
        static void Main(string[] args) {
            var services = SetupServices();
            var sqlService = services.GetService<ISQLiteService>();
            //var held = sqlService.GetPlaylistItems();
            var tracks = sqlService.GetTracks().Where(t => t.podcast == 1 && t.artist != "BOILER ROOM" && t.location.ToLower().Contains("file:///Users/Ares/Music/iTunes/Podcasts/".ToLower())).OrderBy(t => t.album).ToList();
            Dictionary<string, bool> pathExists = new Dictionary<string, bool>();
            foreach (var track in tracks) {
                var path = WebUtility.UrlDecode(track.location.Substring(6));
                pathExists[path] = File.Exists(path);
            }
            foreach (var key in pathExists.Keys.ToList()) {
                if (pathExists[key]) {
                    File.Delete(key);
                    pathExists[key] = File.Exists(key);
                }
            }

            Console.WriteLine("Hello World!");

        }

        static ServiceProvider SetupServices() {
            var path = $"db-files/itunes.db";
            ClusterHelper.Initialize(new ClientConfiguration {
                Servers = new List<Uri> { new Uri("couchbase://localhost") }
            }, new PasswordAuthenticator("jayScrill", "password"));
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDbService, CouchbaseService>()
                .AddScoped<ISQLiteService, SQLiteService>()
                .AddDbContext<MyContext>(opt => opt.UseSqlite("Data Source=" + path))
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
