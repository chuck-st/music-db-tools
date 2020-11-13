using System;
using System.Collections.Generic;

namespace music_db_tools.Models.google {
    public class Playlist {
        Guid id { get; set; }
        string creationTimestamp { get; set; }
        string recentTimestamp { get; set; }
        string name { get; set; }
        string type { get; set; }
        string shareToken { get; set; }
        string ownerName { get; set; }
        bool accessControlled { get; set; }
        public List<Track> tracks { get; set; }
    }
}
