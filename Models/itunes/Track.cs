namespace music_db_tools.Models.itunes {
    public class Track {
        public string track_id { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public string artist { get; set; }
        public int? rating { get; set; }
        public int? rating_computed { get; set; }
        public string album { get; set; }
        public string location { get; set; }
        public int? album_rating { get; set; }
        public int? album_rating_computed { get; set; }
        public int? play_count { get; set; }
        public int? podcast { get; set; }
    }
}
