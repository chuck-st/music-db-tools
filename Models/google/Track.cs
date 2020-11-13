using System;

namespace music_db_tools.Models.google {
    public class Track {
        public string kind { get; set; }
        public Guid id { get; set; }
        public string creationTimestamp { get; set; }
        public string recentTimestamp { get; set; }
        public bool deleted { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string composer { get; set; }
        public string album { get; set; }
        public string albumArtist { get; set; }
        public int year { get; set; }
        public int trackNumber { get; set; }
        public int? playCount { get; set; }
        public int? rating { get; set; }
    }
}
